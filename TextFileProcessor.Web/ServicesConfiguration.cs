using TexFileProcessor.Core.Interfaces;
using TexFileProcessor.Core.Services;

namespace TextFileProcessor.Web
{
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddControllers();
            services.AddMvc();
            services.AddScoped<IFileProcessorServices, FileProcessorServices>();
        }
    }
}
