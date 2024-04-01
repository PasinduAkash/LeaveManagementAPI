using LeaveManagement.Application.Contracts.Infrastructure;
using LeaveManagement.Application.Models;
using LeaveManagement.Infrastructure.Emails;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {

        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.Configure<EmailSettings>(options =>
            {
                options.ApiKey = configuration["EmailSettings:ApiKey"];
                options.FromAddress = configuration["EmailSettings:FromAddress"];
                options.FromName = configuration["EmailSettings:FromName"];
            });

            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }

    }
}
