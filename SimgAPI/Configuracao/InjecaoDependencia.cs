using SimgAPI.Dominio.Interfaces.Repositorios;
using SimgAPI.Dominio.Interfaces.Servicos;
using SimgAPI.Dominio.Servicos;
using SimgAPI.Infraestrutura.Dados.Repositorios;
using SimgAPI.Infraestrutura.Mqtt;

namespace SimgAPI.Configuracao
{
    public static class InjecaoDependencia
    {
        public static void AddInjecaoDependencia(IServiceCollection servicos)
        {
            servicos.AddSingleton<IRepositorioLeitura, RepositorioLeitura>();
            servicos.AddSingleton<IRepositorioAlerta, RepositorioAlerta>();
            servicos.AddSingleton<IRepositorioDispositivo, RepositorioDispositivo>();
            servicos.AddSingleton<IRepositorioUsuario, RepositorioUsuario>();

            servicos.AddSingleton<IServicoLeitura, ServicoLeitura>();
            servicos.AddSingleton<IServicoAlerta, ServicoAlerta>();
            servicos.AddSingleton<IServicoDispositivo,ServicoDispositivo>();
            servicos.AddSingleton<IServicoUsuario, ServicoUsuario>();

            servicos.AddHostedService<ServicoConsumidorBase>();
        }
    }
}
