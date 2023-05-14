using Microsoft.AspNetCore.Mvc;
using VoucherCodeGenerator.API.Helpers;
using VoucherCodeGenerator.API.Models;
using lib = VoucherCodeGenerator.Lib;

namespace VoucherCodeGenerator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        [HttpPost]
        [Route("generate")]
        public IActionResult GenerateVoucherCode(GenerateVoucherCodeRequest generateVoucherCodeRequest)
        {
            string charactersSet = CharactersSetHelper.GetCharactersSetFromName(generateVoucherCodeRequest.CharacterSetsName);

            lib.VoucherCodeConfigModel voucherCodeConfigModel = lib.VoucherCodeConfigModel.Iniliatize()
                .WithLength(generateVoucherCodeRequest.Length)
                .WithCharset(charactersSet)
                .WithPrefix(generateVoucherCodeRequest.VoucherCodePrefix)
                .WithPostfix(generateVoucherCodeRequest.VoucherCodePostfix)
                .WithPattern(generateVoucherCodeRequest.VoucherCodePattern);

            string voucherCode = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            GenerateVoucherCodeResponse generateVoucherCodeResponse = new GenerateVoucherCodeResponse()
            {
                VoucherCode = voucherCode
            };

            return Ok(generateVoucherCodeResponse);
        }
    }
}
