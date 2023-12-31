﻿
using MediatR;
using MediatR.Pipeline;
using Microsoft.EntityFrameworkCore;
using Web.App.Application.Common;
using Web.App.Application.Repositories;
using Web.App.Application.Reservations;
using Web.App.Database;

namespace Web.App
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var connetionString = "server=localhost;database=flights;user=root;password=Pokemon123&";

            services.AddControllersWithViews();
            services.AddSession();
            services
                .AddAutoMapper(typeof(DependencyInjection))
                .AddScoped<IDbContext, FlightDbContext>()
                .AddScoped<IReservationRepository, ReservationRepository>()
                .AddScoped<IReservationService, ReservationService>();
            services
                    .AddDbContext<FlightDbContext>(
                        options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddMemoryCache();

            return services;
        }
    }
}
