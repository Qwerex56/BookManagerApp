using Common.EFCore;
using LibrarySimService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLibraryContext();
builder.Services.AddLibrarySimServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment()) app.UseHsts();

app.UseHttpsRedirection();

app.MapControllerRoute(
        "default",
        "api/{controller}/{action=Index}/{id?}")
    ;

app.Run();