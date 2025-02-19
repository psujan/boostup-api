using Boostup.API.Data;
using Boostup.API.Data.Seeder;
using Boostup.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnectionString"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.RegisterService(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapGet("/", () => "Welcome to BoostupCleaning Services");

if (args.Contains("seed"))
{
    // Run the seeding process
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        //seed user roles data
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        await SeedData.SeedRoles(dbContext);
        await SeedData.SeedUser(services , dbContext);
    }

    Console.WriteLine("Database seeding completed.");
    Environment.Exit(0); // Ensure app exits after seeding
}

app.Run();


