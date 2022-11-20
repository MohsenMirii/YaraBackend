using System;
using System.Linq;
using System.Threading.Tasks;
using DataModel.DomainClasses;
using Microsoft.AspNetCore.Mvc;
using DataModel.Common;
using BusinessLogic.BusinessInterface;

namespace Yara.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        IGenericRepository_BL<DataModel.DomainClasses.Company> _CompanyRepository_BL;
        public CompanyController(IGenericRepository_BL<DataModel.DomainClasses.Company> CompanyRepository_BL)
        {
            _CompanyRepository_BL = CompanyRepository_BL;
        }

        [HttpPost]
        [Route("Upsert")]
        public async Task<ActionResult> Upsert([FromBody] Upsert_SVM<Company> inputModel)
        {
            inputModel.Data.AuthorId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return await _CompanyRepository_BL.Upsert(inputModel);
        }

        [HttpPost]
        [Route("Delete")]
        public ActionResult Delete([FromBody] DeleteClassDTO inputModel)
        {
            inputModel.AuthorId = Convert.ToInt32(User.Claims.ToList()[0].Value);
            return _CompanyRepository_BL.Delete(inputModel).Result;
        }

        [HttpPost]
        [Route("GetDataList")]
        public ActionResult GetDataList([FromBody] GetItemDTO inputModel)
        {
            return _CompanyRepository_BL.GetDataList(inputModel).Result;
        }

        [HttpPost]
        [Route("Search")]
        public ActionResult Search([FromBody] Company inputModel)
        {
            return _CompanyRepository_BL.Search(inputModel).Result;
        }
    }
}
