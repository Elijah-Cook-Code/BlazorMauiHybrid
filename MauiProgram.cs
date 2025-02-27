﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PetStore.Data;
using BlazorHybridApp.Services;

namespace BlazorHybridApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // Use the correct storage location, prefer FileSystem.AppDataDirectory for cross-platform compatibility
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "PetStore.db");

            builder.Services.AddDbContext<ProductContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"));

            builder.Services.AddScoped<ProductService>();


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
