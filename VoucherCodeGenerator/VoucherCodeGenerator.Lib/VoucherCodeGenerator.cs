using System.Text;

namespace VoucherCodeGenerator.Lib
{
    public class VoucherCodeGenerator
    {
        #region Private members

        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        #endregion

        #region Public members

        public static string Generate(VoucherCodeConfigModel voucherCodeConfigModel)
        {
            StringBuilder sb = new StringBuilder();

            char[] chars = voucherCodeConfigModel.Charset.ToCharArray();
            char[] pattern = voucherCodeConfigModel.Pattern.ToCharArray();

            if (!string.IsNullOrWhiteSpace(voucherCodeConfigModel.Prefix))
            {
                sb.Append(voucherCodeConfigModel.Prefix);
            }

            for (int i = 0; i < pattern.Length; i++)
            {
                if (pattern[i] == VoucherCodeConfigModel.PATTERN_PLACEHOLDER)
                    sb.Append(chars[random.NextInt64(chars.LongLength)]);
                else
                    sb.Append(pattern[i]);
            }

            if (!string.IsNullOrWhiteSpace(voucherCodeConfigModel.Postfix))
            {
                sb.Append(voucherCodeConfigModel.Postfix);
            }

            return sb.ToString();
        }

        #endregion
    }
}
