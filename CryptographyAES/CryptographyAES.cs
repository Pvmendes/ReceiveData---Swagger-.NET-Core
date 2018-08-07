using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CryptographyAES
{
    public class Cryptography
    {
        private readonly UTF8Encoding _enc;
        private readonly byte[] _iv;
        private readonly byte[] _key;
        private readonly RijndaelManaged _rcipher;
        private byte[] _pwd, _ivBytes;
        private const int Keysize = 256;
        private const int DerivationIterations = 1000;

        public Cryptography(){
            _enc = new UTF8Encoding();
            _rcipher = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 256,
                BlockSize = 128,
            };
            _key = new byte[32];
            _iv = new byte[_rcipher.BlockSize / 8]; //128 bit / 8 = 16 bytes
            _ivBytes = new byte[16];    
        }
        private enum Type
        {
            Encrypt,
            Decrypt
        }

        public string AESEncrypt(string plainText, string cryptKey)
        {
            var key = GetHashSha256(cryptKey, 32);
            var initVector = "";
            return AESEncryptDecrypt(plainText, key, Type.Encrypt, initVector);
        }

        public string AESDecrypt(string encryptedText, string cryptKey)
        {
            var key = GetHashSha256(cryptKey, 32);
            var initVector = "";
            return AESEncryptDecrypt(encryptedText, key, Type.Decrypt, initVector);
        }


        #region AES  Encryption
        private string AESEncryptDecrypt(string inputText, string encryptionKey, Type mode, string initVector)
        {
            var _out = ""; // output string
                           //_encryptionKey = MD5Hash (_encryptionKey);
            _pwd = Encoding.UTF8.GetBytes(encryptionKey);
            _ivBytes = Encoding.UTF8.GetBytes(initVector);

            var len = _pwd.Length;
            if (len > _key.Length)
            {
                len = _key.Length;
            }
            var ivLenth = _ivBytes.Length;
            if (ivLenth > _iv.Length)
            {
                ivLenth = _iv.Length;
            }

            Array.Copy(_pwd, _key, len);
            Array.Copy(_ivBytes, _iv, ivLenth);
            _rcipher.Key = _key;
            _rcipher.IV = _iv;

            if (mode.Equals(Type.Encrypt))
            {
                using (var cryptor = _rcipher.CreateEncryptor())
                {
                    //encrypt
                    var plainText = cryptor.TransformFinalBlock(_enc.GetBytes(inputText), 0, inputText.Length);

                    _out = Convert.ToBase64String(plainText);
                }
            }
            if (mode.Equals(Type.Decrypt))
            {
                using (var cryptor = _rcipher.CreateDecryptor())
                {
                    //decrypt
                    var plainText = cryptor.TransformFinalBlock(Convert.FromBase64String(inputText), 0, Convert.FromBase64String(inputText).Length);

                    _out = _enc.GetString(plainText);
                }
            }

            return _out;
        }


        private string GetHashSha256(string text, int length)
        {
            var bytes = Encoding.UTF8.GetBytes(text);
            using (var hashstring = new SHA256Managed())
            {
                var hash = hashstring.ComputeHash(bytes);
                var hashString = string.Empty;
                foreach (var x in hash)
                {
                    hashString += string.Format("{0:x2}", x); //covert to hex string
                }
                if (length > hashString.Length)
                    return hashString;
                return hashString.Substring(0, length);
            }
        }
        #endregion
    }
}
