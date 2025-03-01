using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using BusinessLayer.Temporary.Services;
using DataAccessLayer.Database;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Repositories;
using DataAccessLayer.Temporary;
using DataAccessLayer.Temporary.Repositories;
using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphqlAPI.Mutations;
using GraphqlAPI.Queries;
using GraphqlAPI.Schemas;
using GraphqlAPI.Types;
using Microsoft.EntityFrameworkCore;
using Uitlity.MappingProfile;

namespace GraphqlAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true; // Optional: Pretty-print JSON
            });

            // DI
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<DataSourceContext>(options =>
                options.UseSqlServer(connectionString).UseLazyLoadingProxies());

            builder.Services.AddAutoMapper(typeof(DomainPersistenceProfile));
            builder.Services.AddSingleton<ITemporaryDataSource, TemporaryDataSource>();
            //builder.Services.AddScoped<IBookRepository, TempBookRepository>();
            //builder.Services.AddScoped<IBookService, TempBookService>();
            builder.Services.AddScoped<IBookRepository, BookRepository>();
            builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

            builder.Services.AddScoped<AuthorInputType>();
            builder.Services.AddScoped<AuthorMutation>();



            builder.Services.AddScoped<IBookService, BookService>();
            builder.Services.AddScoped<IAuthorService, AuthorService>();



            builder.Services.AddScoped<BookType>();
            builder.Services.AddScoped<BookQuery>();
            builder.Services.AddScoped<AuthorType>();
            builder.Services.AddScoped<AuthorQuery>();
            builder.Services.AddScoped<RootQuery>();
            builder.Services.AddScoped<ISchema, RootSchema>();


            builder.Services.AddGraphQL(gb => gb.AddAutoSchema<ISchema>().AddSystemTextJson());


            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseGraphiQl("/graphql-client", "/graphql-api");
            app.UseGraphQL<ISchema>("/graphql-api");

            app.MapControllers();


            app.Run();
        }
    }
}
