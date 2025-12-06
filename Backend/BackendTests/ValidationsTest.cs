using Xunit;
using Backend.Business;
namespace BackendTests
{
    public class ValidationsTest
    {
        [Fact]
        public void should_return_true_for_valid_email()
        {
            Assert.False(EmailValidator.ValidateEmail("        "), "se esperaba que el resultado debia ser FALS");

            Assert.True(EmailValidator.ValidateEmail("joseagustin@gmail.com"), "se esperaba que el resultado debia ser TRUE");

            Assert.False(EmailValidator.ValidateEmail("@gmail.com"), "se esperaba que el resultado debia ser FALSE");

            Assert.True(EmailValidator.ValidateEmail("CARLOS@gmail.com"), "se esperaba que el resultado debia ser TRUE");

            Assert.True(EmailValidator.ValidateEmail("CARLOS@gmail.com"), "se esperaba que el resultado debia ser TRUE");

            Assert.False(EmailValidator.ValidateEmail(""), "se esperaba que el resultado debia ser FALSE");

            Assert.True(EmailValidator.ValidateEmail("agust@GMAIL.COM"), "se esperaba que el resultado debia ser True");
        }
    }
}