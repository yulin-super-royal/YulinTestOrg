using System.Security.Cryptography;
using System.Text;

namespace YulinTestOrg.Service
{
    public class MD5Service
    {
        public bool Encrypt(string plainText, out string outCipherText)
        {
            outCipherText = null;

            MD5 md5 = null;
            try
            {
                md5 = MD5.Create();
                byte[] plainByteArray = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                string cipherText = Convert.ToBase64String(plainByteArray);

                outCipherText = cipherText;
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (md5 != null)
                {
                    md5.Dispose();
                }
            }
        }

        /// <summary>加密</summary>
        public (bool, string) Encrypt(string plainText)
        {
            MD5 md5 = null;
            try
            {
                md5 = MD5.Create();
                byte[] plainByteArray = md5.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                string cipherText = Convert.ToBase64String(plainByteArray);

                return (true, cipherText);
            }
            catch
            {
                return (false, null);
            }
            finally
            {
                if (md5 != null)
                {
                    md5.Dispose();
                }
            }
        }
    }
}
