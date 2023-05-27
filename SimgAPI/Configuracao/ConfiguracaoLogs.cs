using Serilog;
using Serilog.Events;

namespace SimgAPI.Configuracao
{
    public static class ConfiguracaoLogs
    {
        public static void ConfiguraLogs(WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((ctx, lc) =>
            lc.WriteTo.File("/home/Logs/log-.txt", rollingInterval: RollingInterval.Day));
        }
    }
}