using Microsoft.Extensions.DependencyInjection;
using QuartzWatcher.Listeners;

namespace QuartzWatcher;

/// <summary>
/// Provides extension methods for registering QuartzWatcher services with the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers QuartzWatcher services and configuration with the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add services to.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddQuartzWatcher(this IServiceCollection services)
    {
        services.AddOptions<QuartzWatcherSettings>()
            .BindConfiguration(QuartzWatcherSettings.SectionName)
            .ValidateDataAnnotations()
            .ValidateOnStart();

        services.AddSingleton<QuartzMessageFactory>();
        return services;
    }

    /// <summary>
    /// Registers QuartzWatcher listeners with the Quartz configuration.
    /// </summary>
    /// <param name="configurator">The Quartz configurator to add listeners to.</param>
    /// <returns>The updated Quartz configurator.</returns>
    public static IServiceCollectionQuartzConfigurator AddQuartzWatcher(this IServiceCollectionQuartzConfigurator configurator)
    {
        configurator.AddSchedulerListener<QuartzWatcherSchedulerListener>();
        configurator.AddJobListener<QuartzWatcherJobListener>();
        configurator.AddTriggerListener<QuartzWatcherTriggerListener>();
        return configurator;
    }
}
