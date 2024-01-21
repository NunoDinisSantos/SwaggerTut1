using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RPG_Game_Test.Authentication;
using RPG_Game_Test.Data;
using RPG_Game_Test.Services.CharacterServices;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddControllers(/*x => x.Filters.Add<ApiKeyAuthFilter>()// Adiciona em cada controlador o filtro*/);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen( x =>
{
    x.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "API Key",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Name = "X-Api-Key",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    }
    );

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };

    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, new List<string>() }
    };

    x.AddSecurityRequirement(requirement);
});


builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ICharacterFacade, CharacterFacade>();

//builder.Services.AddScoped<ApiKeyAuthFilter>(); // Permite a utilização de filtrar para usar key em cada controller

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ApiKeyAuthMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
