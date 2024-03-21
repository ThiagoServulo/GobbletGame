using System;
using System.Windows.Forms;

namespace GobbletGame
{
    static class Program
    {
        /** ************************************************************************
        * \brief Main function.
        * \details Entry point of the application.
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
