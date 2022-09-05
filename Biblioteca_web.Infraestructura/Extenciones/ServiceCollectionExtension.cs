using Biblioteca_web.Core.Interfaces;
using Biblioteca_web.Core.ModificarEntidades;
using Biblioteca_web.Core.Servicios;
using Biblioteca_web.Infraestructura.Data;
using Biblioteca_web.Infraestructura.Interfaces;
using Biblioteca_web.Infraestructura.Opciones;
using Biblioteca_web.Infraestructura.Repositorios;
using Biblioteca_web.Infraestructura.Servicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text;

namespace Biblioteca_web.Infraestructura.Extenciones
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AgregaContextoDatos(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BIBLIOTECAContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("BIBLIOTECA")));

            return services;
        }

        public static IServiceCollection AgregaOpciones(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<OpcionesPaginacion>(configuration.GetSection("Paginacion"));
            services.Configure<OpcionesContrasena>(configuration.GetSection("OpcionesContrasena"));

            return services;
        }

        public static IServiceCollection AgregaServicios(this IServiceCollection services)
        {
            services.AddTransient<IServicioPrestado, ServicioPrestado>();
            services.AddTransient<IServicioEstudiante, ServicioEstudiante>();
            services.AddTransient<IServicioLibro, ServicioLibro>();
            services.AddTransient<IServicioSeguridad, ServicioSeguridad>();
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddTransient<IUnidadDeTrabajo, UnidadDeTrabajo>();
            services.AddSingleton<IServicioContrasena, ServicioContrasena>();
            services.AddSingleton<IServicioUri>(proveedor =>
            {
                var acceso = proveedor.GetRequiredService<IHttpContextAccessor>();
                var solicitud = acceso.HttpContext.Request;
                var UriAbsoluto = string.Concat(solicitud.Scheme, "://", solicitud.Host.ToUriComponent());
                return new ServicioUri(UriAbsoluto);
            });

            return services;
        }

        public static IServiceCollection AgregaAutenticacionJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Authentication:Issuer"],
                    ValidAudience = configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]))
                };
            });

            return services;
        }

        public static IServiceCollection AgregaSwagger(this IServiceCollection services, string xmlArchivo)
        {
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Bibliote web API", Version = "v1" });

                var xmlRuta = Path.Combine(AppContext.BaseDirectory, xmlArchivo);
                doc.IncludeXmlComments(xmlRuta);
            });


            return services;
        }

        public static IServiceCollection AgregaCors(this IServiceCollection services, IConfiguration configuration)
        {
            // Se agrega para evirtar problemas de CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    var frontend_url = configuration.GetValue<string>("Authentication:Audience");
                    builder.WithOrigins(frontend_url).AllowAnyMethod().AllowAnyHeader()
                    .WithExposedHeaders(new string[] { "totalRecords" });
                });
            });


            return services;
        }

    }
}
