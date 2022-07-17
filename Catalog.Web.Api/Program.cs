using Catalog.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCatalogDbContext(builder.Configuration.GetConnectionString("EBGCatalog"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(p => p
    .WithOrigins("http://localhost:3000")
    .AllowAnyHeader().AllowAnyMethod()
    .AllowCredentials());

app.MapControllers();

app.Run();
