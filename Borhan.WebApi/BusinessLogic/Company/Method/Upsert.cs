using BusinessLogic.Account.Method;
using DataAccess.Company.Commands;
using DataAccess.Company.Queries;
using DataAccess.DocumentFile.Commands;
using DataAccess.DocumentFile.Queries;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;
using DataModel.Enum;

namespace BusinessLogic.Company.Method
{
  

    public partial class Company_BL
    {
        public async Task<ActionResult> Upsert([FromBody] Upsert_SVM<DataModel.DomainClasses.Company> inputModel)
        {
            try
            {

                BaseResult_VM methodResult = _account_BL.Authentication(inputModel.Data.AuthorId,DataModel.Enum.ActionPermission.CompanyOP_Insert);
                if (methodResult.ErrorCode!=0)
                {
                    return Ok(methodResult);
                }
                if (inputModel.Data.AuthorId <= 0)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 100,
                        ErrorMessage = "کاربر گرامی، جهت درج یا بروزرسانی تحلیل ابتدا وارد حساب کاربری خود شوید.",
                    });
                }

                if (string.IsNullOrEmpty(inputModel.Data.Title))
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 100,
                        ErrorMessage = "لطفا عنوان تحلیل را وارد نمایید."
                    });
                }

                DataModel.DomainClasses.Company Company;
                if (inputModel.Data.Id == 0)
                {
                    // عملیات درج
                    Company = new DataModel.DomainClasses.Company
                    {
                        Text = inputModel.Data.Text,
                        Title = inputModel.Data.Title,
                        AuthorId = inputModel.Data.AuthorId,
                        CreateDate = DateTime.Now,
                        KeyWord=inputModel.Data.KeyWord,
                    };

                    if (inputModel.FileVM != null && !string.IsNullOrEmpty(inputModel.FileVM.FileExtention))
                    {
                        Company.Document = new DataModel.DomainClasses.DocumentFile
                        {
                            FileContent = inputModel.FileVM.FileContent,
                            FileExtention = inputModel.FileVM.FileExtention,
                            FileName = inputModel.FileVM.FileName,
                            DocumentTypeInt = (int)DocumentType.Picture,
                        };
                    }
                    await _mediator.Send(new Company_Insert.Command { Company = Company });

                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 0,
                        ErrorMessage = "عملیات با موفقیت انجام گردید."
                    });
                }

                // عملیات بروزرسانی
                Company = _mediator.Send(new Company_GetById.Query { PointerID = inputModel.Data.Id }).Result.Company;
                if (Company == null)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 100,
                        ErrorMessage = "کد یکتای انتخاب شده معتبر نمی باشد."
                    });
                }
                Company.Text = inputModel.Data.Text;
                Company.Title = inputModel.Data.Title;
                Company.KeyWord = inputModel.Data.KeyWord;
                if (!string.IsNullOrEmpty(inputModel.FileVM.FileExtention))
                {
                    if (Company.Document == null)
                    {
                        Company.Document = new DataModel.DomainClasses.DocumentFile
                        {
                            FileContent = inputModel.FileVM.FileContent,
                            FileExtention = inputModel.FileVM.FileExtention,
                            FileName = inputModel.FileVM.FileName,
                            DocumentTypeInt = (int)DocumentType.Picture,
                        };
                    }
                    else
                    {
                        Company.Document.Id = Company.Document != null ? Company.Document.Id : 0;
                        Company.Document.FileContent = inputModel.FileVM.FileContent;
                        Company.Document.FileExtention = inputModel.FileVM.FileExtention;
                        Company.Document.FileName = inputModel.FileVM.FileName;
                        Company.Document.DocumentTypeInt = (int)DocumentType.Picture;
                    }
                }

                await _mediator.Send(new Company_Update.Command { Company = Company });

                return Ok(new BaseResult_VM
                {
                    ErrorCode = 0,
                    ErrorMessage = "عملیات با موفقیت انجام گردید."
                });

            }
            catch (Exception ex)
            {
                return Ok(new BaseResult_VM
                {
                    ErrorCode = -1000,
                    ErrorMessage = "کاربر گرامی، خطایی رخ داده است لطفا با مدیر سیستم تماس بگیرید.",
                    Result=JsonConvert.SerializeObject(ex)
                });
            }

        }

    }
}
