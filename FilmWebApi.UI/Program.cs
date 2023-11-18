using FilmWebApi.BLL.AutoMapper;
using FilmWebApi.BLL.Services.Abstract;
using FilmWebApi.BLL.Services.Concrete;
using FilmWebApi.Core.IRepositories;
using FilmWebApi.DAL.Context;
using FilmWebApi.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FilmWebApi.UI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("conStr")));


            builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);


            //AUTOMAPPER
            builder.Services.AddAutoMapper(typeof(ActorMapping));

            //DEPENDENCY INJECTION
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			builder.Services.AddTransient<IActorRepository, ActorRepository>();
			builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
			builder.Services.AddTransient<IFilmRepository, FilmRepository>();

			builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseManager<>));
			builder.Services.AddTransient<IActorService,ActorManager>();
			builder.Services.AddTransient<ICategoryService,CategoryManager>();
			builder.Services.AddTransient<IFilmService,FilmManager>();




            var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}