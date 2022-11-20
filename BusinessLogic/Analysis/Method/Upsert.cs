using BusinessLogic.Account.Method;
using DataAccess.Analysis.Commands;
using DataAccess.Analysis.Queries;
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

namespace BusinessLogic.Analysis.Method
{
  

    public partial class Analysis_BL
    {
        public async Task<ActionResult> Upsert([FromBody] Upsert_SVM<DataModel.DomainClasses.Analysis> inputModel)
        {
            try
            {

                BaseResult_VM methodResult = _account_BL.Authentication(inputModel.Data.AuthorId,DataModel.Enum.ActionPermission.AnalysisOP_Insert);
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

                DataModel.DomainClasses.Analysis analysis;
                if (inputModel.Data.Id == 0)
                {
                    // عملیات درج
                    analysis = new DataModel.DomainClasses.Analysis
                    {
                        Text = inputModel.Data.Text,
                        Title = inputModel.Data.Title,
                        AuthorId = inputModel.Data.AuthorId,
                        CreateDate = DateTime.Now,
                        KeyWord=inputModel.Data.KeyWord,
                    };

                    if (inputModel.FileVM != null && !string.IsNullOrEmpty(inputModel.FileVM.FileExtention))
                    {
                        analysis.Document = new DataModel.DomainClasses.DocumentFile
                        {
                            FileContent = inputModel.FileVM.FileContent,
                            FileExtention = inputModel.FileVM.FileExtention,
                            FileName = inputModel.FileVM.FileName,
                            DocumentTypeInt = (int)DocumentType.Picture,
                        };
                    }
                    await _mediator.Send(new Analysis_Insert.Command { Analysis = analysis });

                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 0,
                        ErrorMessage = "عملیات با موفقیت انجام گردید."
                    });
                }

                // عملیات بروزرسانی
                analysis = _mediator.Send(new Analysis_GetById.Query { PointerID = inputModel.Data.Id }).Result.Analysis;
                if (analysis == null)
                {
                    return Ok(new BaseResult_VM
                    {
                        ErrorCode = 100,
                        ErrorMessage = "کد یکتای انتخاب شده معتبر نمی باشد."
                    });
                }
                analysis.Text = inputModel.Data.Text;
                analysis.Title = inputModel.Data.Title;
                analysis.KeyWord = inputModel.Data.KeyWord;
                if (!string.IsNullOrEmpty(inputModel.FileVM.FileExtention))
                {
                    if (analysis.Document == null)
                    {
                        analysis.Document = new DataModel.DomainClasses.DocumentFile
                        {
                            FileContent = inputModel.FileVM.FileContent,
                            FileExtention = inputModel.FileVM.FileExtention,
                            FileName = inputModel.FileVM.FileName,
                            DocumentTypeInt = (int)DocumentType.Picture,
                        };
                    }
                    else
                    {
                        analysis.Document.Id = analysis.Document != null ? analysis.Document.Id : 0;
                        analysis.Document.FileContent = inputModel.FileVM.FileContent;
                        analysis.Document.FileExtention = inputModel.FileVM.FileExtention;
                        analysis.Document.FileName = inputModel.FileVM.FileName;
                        analysis.Document.DocumentTypeInt = (int)DocumentType.Picture;
                    }
                }

                await _mediator.Send(new Analysis_Update.Command { Analysis = analysis });

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
