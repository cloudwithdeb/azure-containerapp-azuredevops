using ITodoServiceNamespace;
using TodoNamespace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodoService, TodoService>();// Add CORS
var MskCorsConfiguration = "MskCorsConfiguration";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MskCorsConfiguration,
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }
app.UseCors(MskCorsConfiguration);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
