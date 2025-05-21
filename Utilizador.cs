using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BeLightBible
{
    public static class Sessao
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
    }
    public class Utilizador
    {
        private static string connectionString = "Server=localhost\\SQLEXPRESS;Database=BeLightBibleDB;Trusted_Connection=True;TrustServerCertificate=True";

        public bool ExisteUtilizador(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;


                connection.Open();
                int count = (int)cmd.ExecuteScalar(); 

                return count > 0; // Retorna true se o utilizador já existe
            }
        }

        public bool Registrar(string username, string email, string password)
        {
            string passwordHash = Utils.HashPassword(password);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string query = "INSERT INTO Users (Username, Email, PasswordHash) VALUES (@Username, @Email, @PasswordHash)";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username; // Adiciona o parâmetro de nome de utilizador
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email; // Adiciona o parâmetro de e-mail
                cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar).Value = passwordHash;

                connection.Open();
                int result = cmd.ExecuteNonQuery();

                return result > 0; // Retorna true se o registro foi bem-sucedido
            }
        }

        public bool Autenticar(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT PasswordHash FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                connection.Open();
                string storedHash = (string)cmd.ExecuteScalar();

                if (storedHash != null)
                {
                    return Utils.VerifyPassword(password, storedHash); // Verifica a senha
                }
                return false; // Retorna false se o utilizador não existe
            }
        }

        public int ObterUserId(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT UserId FROM Users WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;

                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int userId))
                {
                    return userId;
                }

                return -1;
            }
        }
    }
}
