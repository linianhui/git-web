using System.Text.Json.Serialization;
using Git.Web.Apis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Git.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
            services.AddMvc(_ => _.EnableEndpointRouting = false)
                .AddJsonOptions(_ => _.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void Configure(IApplicationBuilder app, IRepositoryFactory repositoryFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseApiDocs(".docs");
            app.UseMvc();
            repositoryFactory.Reload();
        }
    }
}
