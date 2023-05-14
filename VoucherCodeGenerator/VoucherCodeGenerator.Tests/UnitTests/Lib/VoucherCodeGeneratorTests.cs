using VoucherCodeGenerator.Lib;
using lib = VoucherCodeGenerator.Lib;

namespace VoucherCodeGenerator.Tests.UnitTests.Lib
{
    public class CodeGeneratorTests
    {
        [Fact]
        public void ShouldGenerateCodeOfGivenLength()
        {
            // Arrange
            lib.VoucherCodeConfigModel voucherCodeConfigModel = lib.VoucherCodeConfigModel.Iniliatize().WithLength(10);

            // Act
            string code = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            // Assert
            Assert.True(code.Length == 10);
        }

        [Fact]
        public void ShouldGenerateNumericCode()
        {
            // Arrange
            lib.VoucherCodeConfigModel voucherCodeConfigModel = lib.VoucherCodeConfigModel.Iniliatize().WithLength(8).WithCharset(CharactersSet.NUMBERS);

            // Act
            string code = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            // Assert
            Assert.Matches("^([0-9]){8}$", code);
        }

        [Fact]
        public void ShouldGenerateCodeWithPrefix()
        {
            // Arrange
            VoucherCodeConfigModel voucherCodeConfigModel = VoucherCodeConfigModel.Iniliatize().WithLength(8).WithPrefix("TEST-");

            // Act
            string code = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            // Assert
            Assert.StartsWith("TEST-", code);
            Assert.True(code.Length.Equals(13));
        }

        [Fact]
        public void ShouldGenerateCodeWithPostfix()
        {
            // Arrange
            VoucherCodeConfigModel voucherCodeConfigModel = VoucherCodeConfigModel.Iniliatize().WithLength(8).WithPrefix("TE-").WithPostfix("-ST");

            // Act
            string code = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            // Assert
            Assert.StartsWith("TE-", code);
            Assert.EndsWith("-ST", code);
            Assert.True(code.Length.Equals(14));
        }

        [Fact]
        public void ShouldGenerateCodeFromGivenPattern()
        {
            // Arrange
            VoucherCodeConfigModel voucherCodeConfigModel = VoucherCodeConfigModel.Iniliatize().WithPattern("##-###-##");

            // Act
            string code = lib.VoucherCodeGenerator.Generate(voucherCodeConfigModel);

            // Assert
            Assert.Matches("^([0-9a-zA-Z]){2}-([0-9a-zA-Z]){3}-([0-9a-zA-Z]){2}$", code);
        }
    }
}
