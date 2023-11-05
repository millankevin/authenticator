using System.Text;

namespace Authenticator.Logs
{
    public class LogResquest
    {
        private static string userName { get; set; }
        public static string rolName { get; set; }
        public static bool error { get; set; } = false;

        public static void GenerarLog(string email, string rol, string message)
        {
            DateTime date = DateTime.Now;
            var pathExact = GeFilePath(date);

            using (StreamWriter writer = new StreamWriter(pathExact, true))
            {
                StringBuilder csvContent = new StringBuilder();
                csvContent.AppendLine($" {message}, Generador por el usuario:{email}, Rol: {rol}, Fecha de Consumo: {date}");
                writer.Write(csvContent.ToString());
            }
        }

        //Se escribe archivo para el consumo del Token
        public static void GenerateTokenFile(string email, string rol)
        {
            userName = email;
            rolName = rol;
            var message = $"Mensaje: Consumo del token en API usuarios";
            GenerarLog(email, rol, message);
        }

        //Se escribe archivo para el consumo de Roles
        public static void GenerateRolesFile()
        {
            var message = $"Mensaje: Consumo del metodo consultar en la tabla roles ";
            GenerarLog(userName, rolName, message);
        }
        public static void GenerateGetUserPorEmailFile()
        {
            var message = $"Mensaje: Consumo del metodo consultar por email en la tabla usuarios";
            GenerarLog(userName, rolName, message);
        }
        public static void GenerateGetUserPorRoleFile()
        {
            var message = $"Mensaje: Consumo del metodo consultar por email en la tabla usuarios ";
            GenerarLog(userName, rolName, message);
        }
        //Se escribe archivo para el consumo obtener Usuarios
        public static void GenerateGetUserFile()
        {
            var message = $"Mensaje: Consumo del metodo consultar en la tabla usuarios ";
            GenerarLog(userName, rolName, message);
        }

        //Se escribe archivo para el consumo crear usuarios
        public static void GenerateCreatedUserFile()
        {
            var message = $"Mensaje: Consumo del metodo crear en la tabla usuarios ";
            GenerarLog(userName, rolName, message);
        }

        //Se escribe archivo para el consumo actualizar Usuarios
        public static void GenerateUpdateUserFile()
        {
            var message = $"Mensaje: Consumo del metodo actualizar en la tabla usuarios ";
            GenerarLog(userName, rolName, message);
        }

        //Se escribe archivo para el consumo inactivar Usuarios
        public static void GenerateInactivateUserFile()
        {
            var message = $"Mensaje: Consumo del metodo archivar en la tabla usuarios ";
            GenerarLog(userName, rolName, message);
        }
        public static void GenerateErrorFile(string messageError)
        {
            error = true;
            var message = $"Error: {messageError}";
            GenerarLog(userName, rolName, message);
        }
        private static string GeFilePath(DateTime date)
        {
            string file = string.Empty;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json")
                .Build();

            string baseDirectory = configuration.GetSection("Logs:Path").Value;

            if (error)
                file = configuration.GetSection("Logs:FileError").Value;
            else
                file = configuration.GetSection("Logs:File").Value;

            string year = date.Year.ToString();
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");

            string logFolderPath = Path.Combine(baseDirectory, year, month, day);
            Directory.CreateDirectory(logFolderPath);

            string logFilePath = Path.Combine(logFolderPath, file);
            return logFilePath;
        }


    }
}
