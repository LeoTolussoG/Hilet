namespace Proyecto_final
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            frmLogin main = new frmLogin();                 // Objeto de formulario login
            main.FormClosed += MainForm_Closed;             // Contador que marca la cantidad de ventanas abiertas
            main.Show();                                    // Muestro el login
            Application.Run();                              // Metodo que arranca la aplicación
        }

        // Metodo que permite cerrar la aplicación cuando se cierran todas las ventanas
        private static void MainForm_Closed(object sender, FormClosedEventArgs e)
        {
            ((Form)sender).FormClosed -= MainForm_Closed;

            if (Application.OpenForms.Count == 0)
            {
                Application.ExitThread();
            }
            else
            {
                Application.OpenForms[0].FormClosed += MainForm_Closed;
            }
        }
    }
}