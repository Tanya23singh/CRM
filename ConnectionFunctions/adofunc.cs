using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CRM_Web_Api.ConnectionFunctions
{
    public class adofunc
    {
        private static byte[] Key;
        private static byte[] IV;

        // Static method to initialize AdoFunc
        public static void Initialize(byte[] key, byte[] iv)
        {
            Key = key;
            IV = iv;
        }

        public static string Encrypt(string plainText)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                        }

                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }

            public static string Decrypt(string cipherText)
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Key;
                    aesAlg.IV = IV;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
        
            private readonly string _connectionString;
        private string iv;

        public adofunc(string connectionString)
        {
            _connectionString = connectionString;
        }

       
        public static SqlConnection CreateConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        public static void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public  SqlDataReader ExecuteReader(string procedureName, SqlCommand command)
        {
            SqlDataReader? reader = null;
            SqlConnection connection = CreateConnection(_connectionString);

            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch
            {
                if (reader != null)
                {
                    reader.Close();
                }

                throw;
            }

            return reader;
        }
        public  object ExecuteScalar(string procedureName, SqlCommand command)
        {
            object? result = null;
            SqlConnection connection = CreateConnection(_connectionString);

            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                result = command.ExecuteScalar();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            return result;
        }
        public  int ExecuteNonQuery(string procedureName, SqlCommand command)
        {
            int rowsAffected = 0;
            SqlConnection connection = CreateConnection(_connectionString);

            try
            {
                connection.Open();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                command.Connection = connection;
                rowsAffected = command.ExecuteNonQuery();
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection(connection);
            }

            return rowsAffected;
        }
    }
}

