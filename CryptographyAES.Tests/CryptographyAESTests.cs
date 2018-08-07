using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CryptographyAES.Tests
{
    [TestFixture]
    public class CryptographyAESTests
    {
        private static readonly string KEY = "PvWi";
        private static readonly string PLAIN_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

        [Test]
        public void EncryptDecrypt()
        {
            var criptAES = new Cryptography();

            var plainTextEncrypted = criptAES.AESEncrypt(PLAIN_TEXT, KEY);

            var plainTextDecrypted = criptAES.AESDecrypt(plainTextEncrypted, KEY);

            plainTextDecrypted.Should().Be(PLAIN_TEXT);
        }
    }
}
