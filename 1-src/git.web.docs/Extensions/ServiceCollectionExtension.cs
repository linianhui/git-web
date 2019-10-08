using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.OpenApi.Models;

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
                _.SwaggerDoc("api", new OpenApiInfo { Title = "API Docs" });
                foreach (var filePath in GetXmlCommentFilePaths())
                {
                    _.IncludeXmlComments(filePath);
                }
            });
        }

        private static IEnumerable<string> GetXmlCommentFilePaths()
        {
            var binPath = AppContext.BaseDirectory;
            return Directory.GetFiles(binPath, "*.xml");
        }
    }
}
