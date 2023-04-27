using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serdiuk.NoteApp.Appication;
using Serdiuk.NoteApp.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, config =>
    {
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        config.Authority = "https://localhost:10001";
    });

//builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Description = "This is Notes API",
        Version = "1",
        Title = "NOTES API",
    });


    var url = builder.Configuration.GetValue<string>("AuthServer:Url");
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Name = "Authorization",
        Type = SecuritySchemeType.OAuth2,
        In = ParameterLocation.Header,
        BearerFormat = "JWT",
        Flows = new OpenApiOAuthFlows
        {
            Password = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri($"{url}/connect/token", UriKind.Absolute),
                AuthorizationUrl = new Uri($"{url}/connect/authorize", UriKind.Absolute),
                Scopes = new Dictionary<string, string>
                {
                    { "NotesApi", "Notes Api" }
                },
            }
        },
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "oauth2"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
    }
);
});

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddMemoryCache();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteApi");
        options.DocumentTitle = "Title";
        options.DocExpansion(DocExpansion.List);
        options.OAuthClientId("client_id_swagger");
        options.OAuthClientSecret("client_secret_swagger");
    });
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestRateLimitMiddleware>(10, TimeSpan.FromMinutes(1));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
