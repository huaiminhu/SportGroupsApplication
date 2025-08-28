using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SportGroups.Api.SwaggerSupport
{
    // 讓Enum Data在Swagger UI顯示原始資料
    public class EnumSchemaFilter : ISchemaFilter   
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                var names = Enum.GetNames(context.Type);
                var values = Enum.GetValues(context.Type).Cast<int>();

                schema.Enum.Clear();
                foreach (var name in names)
                {
                    schema.Enum.Add(new OpenApiString(name));
                }

                schema.Description += $"Possible values: {string.Join(", ", names.Zip(values, (n, v) => $"{n} = {v}"))}";
            }
        }
    }

}
