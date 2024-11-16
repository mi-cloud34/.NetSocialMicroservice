using System.Reflection;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.Application.Pipelines.Validation;
using Core.Application.Rules;
using FluentValidation;
using MediatR;
using Message.Application.Services.ImageService;
using Message.Application.Services.ImageService.StorageService;
using Message.Application.Services.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Social.Shared.FileShared;
using Social.Shared.FileShared.Azure;
using Social.Shared.FileShared.Local;

namespace Message.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            configuration.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
            configuration.AddOpenBehavior(typeof(CachingBehavior<,>));
            configuration.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));
            configuration.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
            configuration.AddOpenBehavior(typeof(TransactionScopeBehavior<,>));

        });
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CacheRemovingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionScopeBehavior<,>));




        //services.AddSingleton<IElasticSearch, ElasticSearchManager>();




        services.AddScoped<IStorageService, StorageServices>();
        services.AddScoped<IAzureStorage, AzureStorage>();
        services.AddScoped<ILocalStorage, LocalStorage>();
        return services;
    }
    public static IServiceCollection AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
    {
        services.AddScoped<IStorage, T>();
        return services;
    }
    //public static IServiceCollection AddStorage(this IServiceCollection services, StorageType storageType)
    //{
    //    switch (storageType)
    //    {
    //        case StorageType.Locale:
    //            services.AddScoped<IStorage, LocalStorage>();
    //            break;
    //        case StorageType.Azure:
    //            services.AddScoped<IStorage, AzureStorage>();
    //            break;
    //        //case StorageType.AWS:
    //        //    break;
    //        default:
    //            services.AddScoped<IStorage, LocalStorage>();
    //            break;
    //    }

    //    return services;
    //}
    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, type);
            }
        }
        return services;
    }
}