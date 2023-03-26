using Microsoft.EntityFrameworkCore;
using BookLib.DataAccess;
using BookLib.Repositories;
using BookLib.Services;

namespace BookLib
{
	public class Startup
	{
		public IConfiguration _configuration { get; }

		public Startup(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			services.AddRouting(options => options.LowercaseUrls = true);
			services.AddCors();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();
			services.AddDbContext<BookLibSqlContext>(
			   options =>
			   {
				   options.UseSqlServer(_configuration.GetConnectionString("BookLibConnection"));
			   });
			services.AddScoped<BookRepository>();
			services.AddScoped<BookAuthorRepository>();
			services.AddScoped<GenreRepository>();
			services.AddScoped<ImageRepository>();
			services.AddScoped<PublisherRepository>();
			services.AddScoped<AuthorRepository>();
			services.AddScoped<OpenLibraryService>();
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI();
			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}