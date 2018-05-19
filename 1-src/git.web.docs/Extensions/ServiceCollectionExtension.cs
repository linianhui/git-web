using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
// ReSharper disable CheckNamespace

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// <see cref="IServiceCollection"/>的扩展方法
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// 添加API文档
        /// </summary>
        /// <param name="this"></param>
        public static void AddApiDocs(this IServiceCollection @this)
        {
            @this.AddSwaggerGen(_ =>
            {
                _.SwaggerDoc("api",  new Info { Title="API Docs"});
                foreach (var filePath in GetXmlCommentFilePaths())
                {
                    _.IncludeXmlComments(filePath);
                }
            });
        }

        private static IEnumerable<string> GetXmlCommentFilePaths()
        {
            var binPath = PlatformServices.Default.Application.ApplicationBasePath;
            return Directory.GetFiles(binPath, "*.xml");
        }
    }
}
