using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using ScreenSound.Banco;
using ScreenSound.Modelos;
using ScreenSound.Shared.Data.Banco;


namespace ScreenSoundAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ScreenSoundContext>();
            builder.Services.AddTransient<ArtistaDal>();
            builder.Services.AddTransient<MusicaDal>();
            builder.Services.AddTransient<MusicasArtistasDal>();
            builder.Services.AddTransient<GeneroDal>();
            builder.Services.AddTransient<GenerosMusicaDal>();
            builder.Services
     .AddControllers()
     .AddNewtonsoftJson(options =>
     {
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
     });




            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            var app = builder.Build();
            app.MapControllers();

            app.UseSwagger();
            app.UseSwagger();
            app.UseSwaggerUI();


            app.Run();
        }
    }
}
