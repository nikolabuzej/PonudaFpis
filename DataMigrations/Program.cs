
using DataMigrations.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;


    var serviceProvider = CreateServices();

    // Put the database update into a scope to ensure
    // that all resources will be disposed.
    using (var scope = serviceProvider.CreateScope())
    {
        UpdateDatabase(scope.ServiceProvider);
    }


/// <summary>
/// Configure the dependency injection services
/// </summary>
 static IServiceProvider CreateServices()
{
    return new ServiceCollection()
        // Add common FluentMigrator services
        .AddFluentMigratorCore()
        .ConfigureRunner(rb => rb
            // Add SQLite support to FluentMigrator
            .AddSqlServer2016()
            // Set the connection string
            .WithGlobalConnectionString("Server=localhost,1433;Database=ponuda;User Id=sa;Password=First132.;")
            // Define the assembly containing the migrations
            .ScanIn(typeof(Migration_001_Schema).Assembly).For.Migrations())
        // Enable logging to console in the FluentMigrator way
        .AddLogging(lb => lb.AddFluentMigratorConsole())
        // Build the service provider
        .BuildServiceProvider(false);
}

/// <summary>
/// Update the database
/// </summary>
 static void UpdateDatabase(IServiceProvider serviceProvider)
{
    // Instantiate the runner
    var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

    // Execute the migrations
    runner.MigrateUp();
}