namespace Primer_proyecto
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
            Application.Run(new Form1());
        }

        public static string GetConnectionString()
        {
            string connectionString = "Data Source=DESKTOP-4O8PIJT\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;Trust Server Certificate=True";
            return connectionString;
        }
    }
}