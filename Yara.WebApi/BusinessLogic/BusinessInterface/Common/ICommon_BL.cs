using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;

namespace BusinessLogic.BusinessInterface.Common
{
    public interface ICommon_BL
    {
        Task<ActionResult> GetOneItem([FromBody]GetOneItemDTO inputModel);
        Task<ActionResult> GetDocument([FromBody] GetDocumentDTO inputModel);
        Task<ActionResult> GetCombinationItem();
        Task<ActionResult> Search(string textToSearch);
        Task<ActionResult> GetRelatedSubject(RelatedSubject_VM keyWord);
    }
}
