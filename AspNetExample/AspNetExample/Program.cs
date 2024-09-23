using AspNetExample.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

// Create builder
WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen
    (options =>
    {
        // Annotations
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "1.0",
            Title = "Test example",
            Description = "Test example",
        });
        // Set the comments path for the Swagger JSON and UI.
        string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        // Pick comments from classes, including controller summary comments
        options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

        // The following code is used for JWT bearer authorization
        // This is just my suggestion for api authorization so I commented it out

        // Security scheme
        //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //{
        //    In = ParameterLocation.Header,
        //    Description = "Please enter token",
        //    Name = "Authorization",
        //    Type = SecuritySchemeType.Http,
        //    BearerFormat = "JWT",
        //    Scheme = "bearer"
        //});
        //// security implement
        //options.AddSecurityRequirement(new OpenApiSecurityRequirement
        //{
        //    {
        //        new OpenApiSecurityScheme
        //        {
        //            Reference = new OpenApiReference
        //            {
        //                Type=ReferenceType.SecurityScheme,
        //                Id="Bearer"
        //            }
        //        },
        //        Array.Empty<string>()
        //    }
        //});
    });

// Add database
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString)) connectionString = "Server=KATO\\MERCURYLOCAL;Database=SmartHomeServer;Trusted_Connection=True;User Id=sa;Password=kato@131211#;MultipleActiveResultSets=True;TrustServerCertificate=True;Integrated security=false";
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

// Serialize enums as strings and disable camelCasing
builder.Services.AddControllers().AddJsonOptions
    (options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
    });

// Build the app
WebApplication app = builder.Build();

// Initialize database
using (IServiceScope scope = app.Services.CreateScope())
{
    try
    {
        // Migrate latest database changes
        ApplicationDbContext dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        // Seed user
        //GlobalData.SeedUser(dbContext);
    }
    catch
    {

    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Run the app
app.Run();
