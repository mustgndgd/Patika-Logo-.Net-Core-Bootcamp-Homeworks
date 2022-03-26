using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
namespace homework_2.SwaggerHelper
{
    public class AddDefaultKeyHeaderParameter: IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "AppVersion",
                In = ParameterLocation.Header,
                Description = " Last current version is 4.0.0 dont try before versions",
                Required = true,
            });
        }
    }
}
