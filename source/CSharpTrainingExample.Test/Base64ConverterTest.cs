using PasswordGeneratorHelper;
using System;
using System.Text;
using Xunit;

namespace CSharpTrainingExample.Test
{
    public class Base64ConverterTest
    {
        private readonly PasswordGenerator _password = null;
        private readonly Base64Converter _base64Converter = null;

        public Base64ConverterTest()
        {
            _password = new PasswordGenerator();
            _base64Converter = new Base64Converter();
        }

        [Fact]
        public void ConvertToWithLinq()
        {
            string text = _password.Get(100);

            string b1 = _base64Converter.ConvertToWithLinq(text);
            string b2 = ConvertTo(text);

            Assert.True(b1 == b2);
        }

        private string ConvertTo(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}