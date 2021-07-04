// ReSharper disable CheckNamespace

using Swashbuckle.AspNetCore.SwaggerUI;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// <see cref="IApplicationBuilder"/>的扩展方法
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        /// <summary>
        /// 启用API文档和文档UI
        /// </summary>
        /// <param name="this"></param>
        /// <param name="routePrefixSwaggerUI">路由前缀SwaggerUI</param>
        /// <param name="routePrefixReDoc">路由前缀ReDoc</param>
        public static void UseApiDocs(this IApplicationBuilder @this, string routePrefixSwaggerUI, string routePrefixReDoc)
        {
            var apiSchemePath = "/.api-scheme.json";
            @this.UseSwagger(_ =>
            {
                _.RouteTemplate = ".{documentName}-scheme.json";
            });

            @this.UseReDoc(_ =>
            {
                _.RoutePrefix = routePrefixReDoc;
                _.SpecUrl = apiSchemePath;
            });

            @this.UseSwaggerUI(_ =>
            {
                _.RoutePrefix = routePrefixSwaggerUI;
                _.DefaultModelRendering(ModelRendering.Example);
                _.DefaultModelExpandDepth(3);
                _.DefaultModelsExpandDepth(3);
                _.DisplayRequestDuration();
                _.DocExpansion(DocExpansion.List);
                _.EnableDeepLinking();
                _.ShowExtensions();
                _.SwaggerEndpoint(apiSchemePath, "API Docs");
            });
        }
    }
}
