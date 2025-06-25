using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeLightBible
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.ManterSessao &&
                !string.IsNullOrEmpty(Properties.Settings.Default.UsernameSalvo))
            {
                Sessao.Username = Properties.Settings.Default.UsernameSalvo;
                Sessao.UserId = Properties.Settings.Default.UserIdSalvo;

                if (Sessao.Username == "admin")
                    Application.Run(new MenuAdmin());
                else
                    Application.Run(new MenuForm());
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }

}
