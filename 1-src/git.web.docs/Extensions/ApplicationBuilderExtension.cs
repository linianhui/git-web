// ReSharper disable CheckNamespace

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
        /// <param name="routePrefix">路由前缀</param>
        public static void UseApiDocs(this IApplicationBuilder @this, string routePrefix)
        {
            @this.UseSwagger(_ =>
            {
                _.RouteTemplate = routePrefix + "/{documentName}-scheme.json";
            });

            @this.UseSwaggerUI(_ =>
            {
                _.RoutePrefix = routePrefix;
                _.DefaultModelRendering(ModelRendering.Example);
                _.DefaultModelExpandDepth(3);
                _.DefaultModelsExpandDepth(3);
                _.DisplayRequestDuration();
                _.DocExpansion(DocExpansion.List);
                _.EnableDeepLinking();
                _.ShowExtensions();
                _.SwaggerEndpoint($"/{routePrefix}/api-scheme.json", "API Docs");
            });
        }
    }
}
