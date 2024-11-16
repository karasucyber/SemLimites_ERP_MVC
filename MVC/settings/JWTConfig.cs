using System.Text;

namespace MVC.settings
{
    public static class JWTConfig
    {

        private const string variable = "SECRET_KEY_JWT";
        public static string secret = Environment.GetEnvironmentVariable(variable);
     }
}
