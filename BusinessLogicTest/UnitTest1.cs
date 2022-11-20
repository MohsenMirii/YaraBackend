using Microsoft.AspNetCore.Http;
using NUnit.Framework;

using System.IO;

namespace BusinessLogicTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);

            stream.Position = 0;

            //create FormFile with desired data
            IFormFile file = new FormFile(stream, 0, stream.Length, "id_from_form", fileName);

            //Act
            //UpasertBankDTO inputModel = new UpasertBankDTO
            //{
            //    AccountId = 1,
            //    AccountNumberStr = "1234",
            //    BankIconAddressStr = "",
            //    BankNameStr = "tett",
            //    IBANStr = "ibn",
            //    //FileModelVM = new DataModel.File.FileModel_VM
            //    //{
            //    //    FormFile = file,
            //    //    FileName = "tet"
            //    //}
            //};

            // string mn = JsonConvert.SerializeObject(inputModel);


        }
    }
}