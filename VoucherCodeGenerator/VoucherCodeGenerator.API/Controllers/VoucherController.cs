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
        public IActionResult GenerateVoucherCodes(GenerateVoucherCodeRequest generateVoucherCodeRequest)
        {
            string charactersSet = CharactersSetHelper.GetCharactersSetFromName(generateVoucherCodeRequest.CharacterSetsName);

            lib.VoucherCodeConfigModel voucherCodeConfigModel = lib.VoucherCodeConfigModel.Iniliatize()
                .WithCharset(charactersSet);

            if(generateVoucherCodeRequest.Length > 0) 
            { 
                voucherCodeConfigModel = voucherCodeConfigModel.WithLength(generateVoucherCodeRequest.Length)
                .WithPrefix(generateVoucherCodeRequest.VoucherCodePrefix)
                .WithPostfix(generateVoucherCodeRequest.VoucherCodePostfix);
            }
            else if(generateVoucherCodeRequest.VoucherCodePattern != null)
            {
                voucherCodeConfigModel = voucherCodeConfigModel.WithPattern(generateVoucherCodeRequest.VoucherCodePattern);
            }

            List<string> voucherCodes = new List<string>();

            int generatedVouchers = 0;

            while (generatedVouchers < generateVoucherCodeRequest.NumberOfVouchers)
            {
                string voucherCode = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

                if (voucherCodes.Contains(voucherCode))
                    continue;

                voucherCodes.Add(voucherCode);
                generatedVouchers++;
            }

            GenerateVoucherCodeResponse generateVoucherCodeResponse = new GenerateVoucherCodeResponse()
            {
                VoucherCode = voucherCodes
            };

            return Ok(generateVoucherCodeResponse);
        }
    }
}
