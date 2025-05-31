namespace WebApp6.Utils
{
    public class ConfigurationManagerAPI
    {
        public static IConfiguration AppSetting
        {
            get;
        }
        static ConfigurationManagerAPI()
        {
            AppSetting
                = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
        }
    }
}
