using System;
using System.Windows.Forms;

namespace GobbletGame
{
    static class Program
    {
        /** ************************************************************************
        * \brief Função Main.
        * \details Entrypoint da aplicação.  
        ***************************************************************************/
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBoard());
        }
    }
}
