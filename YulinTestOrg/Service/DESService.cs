using System.Security.Cryptography;
using System.Text;

namespace YulinTestOrg.Service
{
    public class DESService
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public string Encrypt(string plainText, string key, string iv)
        {
            DES des = null;

            try
            {
                des = DES.Create();

                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);

                byte[] plainByteArray = Encoding.UTF8.GetBytes(plainText);
                byte[] cipherByteArray = des.CreateEncryptor().TransformFinalBlock(plainByteArray, 0, plainByteArray.Length);

                string cipherText = Convert.ToBase64String(cipherByteArray);

                return cipherText;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (des != null)
                {
                    des.Dispose();
                }
            }
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText, string key, string iv)
        {
            DES des = null;
            try
            {
                des = DES.Create();
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = Encoding.UTF8.GetBytes(key);
                des.IV = Encoding.UTF8.GetBytes(iv);

                byte[] cipherByteArray = Convert.FromBase64String(cipherText);
                byte[] plainByteArray = des.CreateDecryptor().TransformFinalBlock(cipherByteArray, 0, cipherByteArray.Length);

                string plainText = Encoding.UTF8.GetString(plainByteArray);

                return plainText;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (des != null)
                {
                    des.Dispose();
                }
            }
        }
    }
}
