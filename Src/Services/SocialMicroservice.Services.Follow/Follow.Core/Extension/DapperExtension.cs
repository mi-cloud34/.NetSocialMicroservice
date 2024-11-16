using Follow.Core.DataAccess;
using Humanizer;
using System.Collections.Generic;
using System.Reflection;

namespace Follow.Core.Extension;
public static class EntityExtensions
{
    public static string GetDatabaseTableName(this IEntity entity)
    {
        return entity.GetType().Name.Pluralize();
    }

    private static string getDatabaseTableName<TEntity>(TEntity entity)
        where TEntity : IEntity
    {
        return typeof(TEntity).Name;
    }

    public static string GetInsertColumns(this IEntity entity)
    {
        return string.Join(", ", entity.getPropertyNames());
    }

    public static string GetInsertValues(this IEntity entity)
    {
        return string.Join(", ", entity.getPropertyNames(property => $"@{property.Name}"));
    }

    public static string GetUpdateColumnsValues(this IEntity entity)
    {
        return string.Join(", ",
            entity.getPropertyNames(property => $"{property.Name} = @{property.Name}"));
    }


    private static IEnumerable<string> getPropertyNames(this IEntity entity)
    {
        return entity.getEntityPropertyInfo().Select(property => $"{property.Name}");
    }

    private static IEnumerable<string> getPropertyNames(this IEntity entity, Func<PropertyInfo, string> selector)
    {
        return entity.getEntityPropertyInfo().Select(selector);
    }

    private static IEnumerable<PropertyInfo> getEntityPropertyInfo(this IEntity entity)
    {
        return entity.GetType().GetProperties()
                               .Where(property =>
                                       property.Name is not "Id" &&
                                       property.CanRead &&
                                       typeof(IEntity).IsAssignableFrom(property.PropertyType) is false);
    }
}