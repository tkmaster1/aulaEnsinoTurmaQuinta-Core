using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TKMaster.AulaEnsino.Core.Data.Context;
using TKMaster.AulaEnsino.Core.Data.Repository;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Notifications;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Repositories;
using TKMaster.AulaEnsino.Core.Domain.Interfaces.Services;
using TKMaster.AulaEnsino.Core.Domain.Notifications;
using TKMaster.AulaEnsino.Core.Service.Application;

namespace TKMaster.AulaEnsino.Core.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Lifestyle.Transient => Uma instância para cada solicitação
            // Lifestyle.Singleton => Uma instância única para a classe (para servidor)
            // Lifestyle.Scoped => Uma instância única para o request

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            #region Domain

            services.AddScoped<IFornecedorAppService, FornecedorAppService>();

            #endregion

            #region InfraData

            services.AddScoped<MeuContexto>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IFornecedorRepository, FornecedorRepository>();

            #endregion
        }
    }
}
