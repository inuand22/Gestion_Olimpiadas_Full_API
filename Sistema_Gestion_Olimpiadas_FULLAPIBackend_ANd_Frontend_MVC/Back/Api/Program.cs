using LogicaAplicacion.CU;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaDatos.Repositorios.LogicaDatos.Repositorios;
using LogicaNegocio.EntidadesDominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //DISCIPLINA
            builder.Services.AddScoped<IRepositorioDisciplina, RepositorioDisciplinaBD>();
            builder.Services.AddScoped<IListadoDisciplina, ListadoDisciplina>();
            builder.Services.AddScoped<IAltaDisciplina, AltaDisciplina>();
            builder.Services.AddScoped<IUpdateDisciplina, UpdateDisci>();
            builder.Services.AddScoped<IRemoveDisciplina, BorrarDisciplina>();

            //ATLETA
            builder.Services.AddScoped<IRepositorioAtleta, RepositorioAtletaBD>();
            builder.Services.AddScoped<IListadoAtletas, ListadoAtletas>();

            //EVENTO ATLETA
            builder.Services.AddScoped<IRepositorioEventoAtleta, RepositorioEventoAtletaBD>();
            builder.Services.AddScoped<IListadoEventosAtletas, ListadoEventoAtletas>();

            // CONF DE LA BASE DE DATOS
            string strCon = builder.Configuration.GetConnectionString("MiConexion");
            builder.Services.AddDbContext<OlimpiadasContext>(options => options.UseSqlServer(strCon));



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
