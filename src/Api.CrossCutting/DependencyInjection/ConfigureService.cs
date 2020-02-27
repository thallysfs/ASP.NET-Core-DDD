using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            // addTransient - cada vez que eu chamar esse método ele vai criar uma nova instância de UserService
            serviceCollection.AddTransient<IUserService, UserService>();
            // toda vez que eu injetar ILoginService eu vou fazer o uso de uma instância da LoginService
            serviceCollection.AddTransient<ILoginService, LoginService>();
        }
    }
}
