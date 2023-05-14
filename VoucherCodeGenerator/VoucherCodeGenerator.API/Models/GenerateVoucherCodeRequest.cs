namespace VoucherCodeGenerator.API.Models
{
    public class GenerateVoucherCodeRequest
    {
        public int Length { get; set; } = 10;
        public string CharacterSetsName { get; set; } = "NUMBERS";
        public string VoucherCodePrefix { get; set; } = string.Empty;
        public string VoucherCodePostfix { get; set; } = string.Empty;
        public string VoucherCodePattern { get; set; } = string.Empty;
    }
}
