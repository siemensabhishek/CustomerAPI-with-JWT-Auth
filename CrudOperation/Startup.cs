using CustomerEntities;

namespace CrudOperation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var connectionString = configuration.GetConnectionString("DBSettingconnection");
            var CustomerContext = new CustomerEntities.CustomerEntities(new CustomerContextOptions());
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=.;database=myDb;trusted_connection=true;");
        //}




        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ApplicationDbContext>(options => options.)
            services.AddDbContext<CustomerEntities>(options => options.UseSqlServer());
            services.AddControllers();
            services.AddScoped<ICrudOperationSL, CrudOperationSL>();
            services.AddScoped<ICrudOperationRL,CrudOperationRL>();
            services.AddSwaggerGen();    
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                
            });
        }
    }
}
