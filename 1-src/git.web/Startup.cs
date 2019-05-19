using Git.Web.Apis;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;

namespace Git.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApiDocs();
            services.AddSingleton<IRepositoryFactory, RepositoryFactory>();
            services.AddMvc().AddJsonOptions(_ =>
            {
                _.SerializerSettings.Converters.Add(new StringEnumConverter());
            });
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
