﻿using Microsoft.Extensions.Configuration;
using System.IO;

namespace RestClient
{
    public class AppSettings
    {
        public string? AlbumsUrl { get; set; }
        private AppSettings() => Load();

        public static AppSettings Instance { get; set; } = new AppSettings();

        private void Load()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            if(configuration != null)
                AlbumsUrl = configuration["jsonplacehoder:albums"];
        }
    }
}
