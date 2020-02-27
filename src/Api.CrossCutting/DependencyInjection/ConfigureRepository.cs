using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            // addTransient - cada vez que eu chamar esse método ele vai criar uma nova instância de UserService
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            // o que digo abaixo é: quando usar IUserRepository vc usa a instância de UserImplementation
            serviceCollection.AddScoped<IUserRepository, UserImplementation>();

            serviceCollection.AddDbContext<MyContext>(
                //options => options.UseMySql("Server=localhost;Port=3306;Database=Course;Uid=developer;Pwd=12345678")
                options => options.UseSqlServer("Server=.\\SQLEXPRESS2017;Database=Course;Uid=sa;Pwd=12345678")
            );
        }
    }
}
