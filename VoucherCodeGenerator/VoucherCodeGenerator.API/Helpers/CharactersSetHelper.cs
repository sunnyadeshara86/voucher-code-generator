using VoucherCodeGenerator.Lib;

namespace VoucherCodeGenerator.API.Helpers
{
    public static class CharactersSetHelper
    {
        public static string GetCharactersSetFromName(string name)
        {
            string charactersSet;

            switch (name.ToUpperInvariant())
            {
                case "ALPHABETIC":
                    charactersSet = CharactersSet.ALPHABETIC;
                    break;
                case "ALPHANUMERIC":
                    charactersSet = CharactersSet.ALPHANUMERIC;
                    break;
                default:
                    charactersSet = CharactersSet.NUMBERS;
                    break;
            }

            return charactersSet;
        }
    }
}
