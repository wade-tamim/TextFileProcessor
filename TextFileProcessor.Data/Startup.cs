using Microsoft.EntityFrameworkCore;
//using TexFileProcessor.Core.Interfaces;
//using TexFileProcessor.Core.Repository;
//using TextFileProcessor.Data.AutoMapper;

namespace TextFileProcessor.Data
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TextFileProcessorDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TextFileProcessorDB")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
        }
    }
}

//services.AddAutoMapper(typeof(DataMappingProfile).Assembly);
//services.AddScoped<IProcessedFileRepository, ProcessedFileRepository>();

//services.AddScoped<Func<TextFileProcessorDbContext>>(
//    serviceProvider => serviceProvider.GetRequiredService<TextFileProcessorDbContext>);
