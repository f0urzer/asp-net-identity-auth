using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

public static class SnakeCaseExtension
{
    public static void UseSnakeCase(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            foreach (var property in entity.GetProperties())
            {
                var newName = ConvertToSnakeCase(property.Name);
                property.SetColumnName(newName);
            }

            var tableName = ConvertToSnakeCase(entity.GetTableName());
            entity.SetTableName(tableName);
        }
    }

    private static string ConvertToSnakeCase(string? name)
    {
        if (string.IsNullOrEmpty(name)) return string.Empty;

        return Regex.Replace(name, "([a-z0-9])([A-Z])", "$1_$2").ToLowerInvariant();
    }
}
