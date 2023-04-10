namespace TextFileProcessor.Web
{
    public class WebHostConfiguration
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureLogging(logging =>
                {
                    // Configure logging
                })
                .ConfigureKestrel(options =>
                {
                    // Configure Kestrel server
                });
        }
    }
}
