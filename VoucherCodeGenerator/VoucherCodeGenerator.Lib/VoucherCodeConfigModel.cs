namespace VoucherCodeGenerator.Lib
{
    public class VoucherCodeConfigModel
    {
        #region Private members
        private int length;
        private readonly string charset = null;
        private readonly string prefix = null;
        private readonly string postfix = null;
        private readonly string pattern = null;
        #endregion

        #region Constructors
        public VoucherCodeConfigModel()
        {
        }

        public VoucherCodeConfigModel(int length, string charset, string prefix, string postfix, string pattern)
        {
            if (length <= 0)
            {
                length = 8;
            }

            if (charset == null)
            {
                charset = CharactersSet.ALPHANUMERIC;
            }

            if (pattern == null)
            {
                char[] chars = new char[length];
                chars = chars.Select(c => PATTERN_PLACEHOLDER).ToArray();
                pattern = new string(chars) ?? string.Empty;
            }

            this.length = length;
            this.charset = charset;
            this.prefix = prefix;
            this.postfix = postfix;
            this.pattern = pattern;
        }
        #endregion

        #region Public members

        public const char PATTERN_PLACEHOLDER = '#';

        public static VoucherCodeConfigModel Iniliatize() => new VoucherCodeConfigModel();

        public VoucherCodeConfigModel WithLength(int length) => new VoucherCodeConfigModel(length, charset ?? null, prefix ?? null, postfix ?? null, pattern ?? null);

        public VoucherCodeConfigModel WithCharset(string charset) => new VoucherCodeConfigModel(length > 0 ? length : 0, charset, prefix ?? null, postfix ?? null, pattern ?? null);

        public VoucherCodeConfigModel WithPrefix(string prefix) => new VoucherCodeConfigModel(length > 0 ? length : 0, charset ?? null, prefix, postfix ?? null, pattern ?? null);

        public VoucherCodeConfigModel WithPostfix(string postfix) => new VoucherCodeConfigModel(length > 0 ? length : 0, charset ?? null, prefix ?? null, postfix, pattern ?? null);

        public VoucherCodeConfigModel WithPattern(string pattern) => new VoucherCodeConfigModel(length > 0 ? length : 00, charset ?? null, prefix ?? null, postfix ?? null, pattern);

        public int Length
        {
            get => this.length;
            set => this.length = value;
        }

        public string Charset
        {
            get => this.charset;
        }

        public string Prefix
        {
            get => this.prefix;
        }

        public string Postfix
        {
            get => this.postfix;
        }

        public string Pattern
        {
            get => this.pattern;
        }

        public virtual string GetMessage()
        {
            return $"Code Config [length = {length}, charset = {charset}, prefix = {prefix}, postfix = {postfix}, pattern = {pattern}]";
        }
        #endregion
    }
}
