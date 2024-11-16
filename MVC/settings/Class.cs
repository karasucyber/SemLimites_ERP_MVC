namespace MVC.settings
{
    public static class Settings
    {

        private const string Variable = "SECRET_KEY_JWT";
        public static string Secret = Environment.GetEnvironmentVariable(Variable);

    }
}
