using PSICaixa.Data.Context;
using PSICaixa.Data.Repositories.Empregados;
using PSICaixa.Data.Services.Empregados;
using PSICaixa.Domain.Interfaces.Repositories.Empregados;
using PSICaixa.Domain.Interfaces.Services.Empregados;
using SimpleInjector;

namespace PSICaixa.IoC
{
    public class BootStrapperPSICaixa
    {
        public static void Register(Container container, Lifestyle lifeStyle)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            container.Register<IEmpregadoService, EmpregadoService>(lifeStyle);

            container.Register<IEmpregadoRepository, EmpregadoRepository> (lifeStyle);

            container.Register<PSICaixaContext>(lifeStyle);

        }
    }
}
