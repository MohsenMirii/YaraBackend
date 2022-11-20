using CrossCuttingService.Password;
using DataAccess.Account.Commands;
using DataAccess.Account.Queries;
using DataAccess.AccountPermission.Commands;
using DataAccess.Permission.Queries;
using DataModel.DomainClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataModel.Account;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Account.Method
{
    public partial class Account_BL
    {
        public async Task<ActionResult> RegisterAccount([FromBody] RegisterAccount_VM inputModel)
        {
            BaseResult_VM _methodResult = Authentication(inputModel.AccountId, ActionPermission.AdminOP_RegisterAccount);
            if (_methodResult.ErrorCode!=0)
            {
                return Ok(_methodResult);
            }

            var accounts = _mediator.Send(new Account_GetByUserName.Query { Username = inputModel.Account.Username }).Result.Account;
            if (accounts != null)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، شما قبلا ثبت نام کرده اید"
                });
            }


            if (inputModel.AccountPermissions.Count == 0)
            {
                return BadRequest(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، لطفا دسترسی های کاربر را وارد نمایید."
                });
            }

            DataModel.DomainClasses.Account account = new DataModel.DomainClasses.Account
            {
                Email=inputModel.Account.Email,
                FullName=inputModel.Account.FullName,
                Username=inputModel.Account.Username,
                InsertDate=DateTime.Now,
                UpdateDate=DateTime.Now
            };
            byte[] salt = null;
            account.Password = inputModel.Account.Password.HashPassword(ref salt);
            account.AccountStatus = (int)AccountStatus.DeActive;
            account.Salt = salt;

            if (string.IsNullOrEmpty(inputModel.Account.FullName))
            {
                account.FullName = inputModel.Account.Username;
            }
            using (TransactionScope scope=new TransactionScope())
            {
                long _accountId = _mediator.Send(new Account_Insert.Command { Account = account }).Result.PointerID;

                _methodResult = SetAccountAccess(inputModel, _accountId);
                if (_methodResult.ErrorCode != 0)
                {
                    return Ok(_methodResult);
                }

                scope.Complete();
            }

            string token = CreateToken(account);

            return Ok(new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "ثبت نام با موفقیت انجام گردید."
            });
        }

        private string CreateToken(DataModel.DomainClasses.Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("Id", account.Id.ToString()));
            claims.AddClaim(new Claim("Username", account.Username));
            claims.AddClaim(new Claim("FullName", account.FullName));
            //foreach (var permission in account.AccountPermission)
            //{
            //    claims.AddClaims(new[]
            //    {
            //        new Claim(Permissions.Permission, permission.Permission.ActionName)
            //    });
            //}
            //foreach (var role in account.AccountRole.ToList())
            //{
            //    var RolePermission = _mediator.Send(new RolePermission_Search.Query { InputModel = new DomainClasses.Role.RolePermission { RoleId = role.RoleId } }).Result.RolePermission;
            //    foreach (var permission in RolePermission)
            //    {
            //        if (!account.AccountPermission.Any(x => x.Permission.Id == permission.PermissionId))
            //        {
            //            claims.AddClaims(new[]
            //            {
            //            new Claim(Permissions.Permission, permission.Permission.ActionName)
            //        });
            //        }
            //    }
            //}

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private  BaseResult_VM SetAccountAccess([FromBody] RegisterAccount_VM inputModel, long accountId)
        {
            
            foreach (var item in inputModel.AccountPermissions)
            {
                var Permission = _mediator.Send(new Permission_GetById.Query { PointerID = item }).Result.Permission;
                if (Permission == null)
                {
                    return new BaseResult_VM
                    {
                        ErrorCode = -1000,
                        ErrorMessage = "کاربر گرامی، اطلاعات وارد شده معتبر نمی باشد، لطفا با مدیر سیستم تماس بگیرید."
                    };
                }

                AccountPermission _accountPermission = new AccountPermission
                {
                    AccountId = accountId,
                    PermissionId = item,
                    Status = (int)AccountPermissionStatus.Active,
                    InsertDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                 var PointerID = _mediator.Send(new AccountPermission_Insert.Command { AccountPermission = _accountPermission }).Result.PointerID;
            }


            return new BaseResult_VM
            {
                ErrorCode = 0,
                ErrorMessage = "عملیات با موفقیت انجام گردید."
            };
        }
    }
}
