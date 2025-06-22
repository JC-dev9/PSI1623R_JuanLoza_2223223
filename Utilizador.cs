using System;
using System.Linq;
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
        public bool ExisteUtilizador(string username)
        {
            using (var context = new Entities()) // seu contexto EF
            {
                return context.Users.Any(u => u.Username == username);
            }
        }

        public bool Registrar(string username, string email, string password)
        {
            string passwordHash = Utils.HashPassword(password);

            using (var context = new Entities())
            {
                var user = new Users
                {
                    Username = username,
                    Email = email,
                    PasswordHash = passwordHash
                };

                context.Users.Add(user);
                int result = context.SaveChanges();

                return result > 0;
            }
        }

        public bool Autenticar(string username, string password)
        {
            using (var context = new Entities())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);

                if (user != null)
                {
                    return Utils.VerifyPassword(password, user.PasswordHash);
                }
                return false;
            }
        }

        public int ObterUserId(string username)
        {
            using (var context = new Entities())
            {
                var user = context.Users.SingleOrDefault(u => u.Username == username);

                if (user != null)
                    return user.UserId;

                return -1;
            }
        }
    }
}
