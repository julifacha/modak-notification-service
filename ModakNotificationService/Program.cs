using Core.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models;
using Repositories;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Build a config object, using env vars and JSON providers.
IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.Configure<EmailConfigurationOptions>(config.GetSection(EmailConfigurationOptions.EmailConfiguration));

builder.Services.AddSingleton<SharedContext>();
builder.Services.AddScoped<IRepository<Notification>, NotificationRepository>();
builder.Services.AddScoped<IRepository<NotificationRule>, NotificationRuleRepository>();
builder.Services.AddScoped<IRepository<User>, UserRepository>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<INotificationRuleValidationService, NotificationRuleValidationService>();
builder.Services.AddScoped<ISmtpService, SmtpService>();


using IHost host = builder.Build();

var notificationService = host.Services.GetRequiredService<INotificationService>();

var notificationsToSend = new []
    { 
        new { UserId = "user1", NotificationType = NotificationTypeEnum.News, Message = "News 1" },
        new { UserId = "user1", NotificationType = NotificationTypeEnum.News, Message = "News 2" },
        new { UserId = "user1", NotificationType = NotificationTypeEnum.News, Message = "News 3" },
        new { UserId = "user2", NotificationType = NotificationTypeEnum.News, Message = "News 1" },
        new { UserId = "user1", NotificationType = NotificationTypeEnum.Status, Message = "Status 1" },
        new { UserId = "user4", NotificationType = NotificationTypeEnum.Status, Message = "Status 1" },
    };

foreach(var notification in notificationsToSend)
{
    try
    {
        notificationService.Send(notification.NotificationType, notification.UserId, notification.Message);
        Console.WriteLine($"Sent notification \"{notification.NotificationType}\" to {notification.UserId}");
    }
    catch (Exception ex)
    { 
        Console.Error.WriteLine(ex.ToString());
    }
}


