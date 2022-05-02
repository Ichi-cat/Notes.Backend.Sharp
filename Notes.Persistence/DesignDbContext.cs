﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Notes.Persistence
{
    public class DesignDbContext : IDesignTimeDbContextFactory<NotesDbContext>
    {
        public NotesDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotesDbContext>();

            // получаем конфигурацию из файла appsettings.json
            ConfigurationBuilder builder = new ConfigurationBuilder();
            //builder.SetBasePath(Directory.GetCurrentDirectory());
            //builder.AddJsonFile("appsettings.json");
            //IConfigurationRoot config = builder.Build();

            //// получаем строку подключения из файла appsettings.json
            //string connectionString = config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite("Data Source=Notes.db");
            return new NotesDbContext(optionsBuilder.Options);
        }
    }
}
