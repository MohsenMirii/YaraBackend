using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataModel.Common;

namespace BusinessLogic.BusinessInterface
{
    public interface IGenericRepository_BL<T>
    {
        Task<ActionResult> Delete([FromBody] DeleteClassDTO inputModel);
        Task<ActionResult> GetDataList([FromBody] GetItemDTO inputModel);
        Task<ActionResult> Upsert([FromBody] Upsert_SVM<T> inputModel);
        Task<ActionResult> Search([FromBody] T inputModel);

    }
}
