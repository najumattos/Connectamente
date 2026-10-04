using Connectamente.API.Middleware;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using dotenv.net;
using Connectamente.API.Data;
using Connectamente.API.Models;
using Connectamente.API.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

DotEnv.Load();                            //Lê o arquivo .env
// Procura por todas as classes que herdam de 'Profile' no projeto
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Configuration.AddEnvironmentVariables(); //adiciona variaveis de ambiente

//chama o front
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPolitica", policy =>
    {
        policy.WithOrigins("http://localhost:5173") // URL do React
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{    
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());// Isso força a conversão de todos os Enums para String no JSON
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; // Não envia propriedades nulas no JSON de resposta
}); ;

// Serviço de Conexão com o Banco
string conexao = builder.Configuration.GetConnectionString("DB_CONNECTION_STRING");
if (string.IsNullOrEmpty(conexao))
{    
    throw new Exception("A string de conexão não foi carregada. Verifique o arquivo .env!");
}
var versao = ServerVersion.AutoDetect(conexao);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(conexao, versao)
);

// Serviço de Autenticação e Autorização - Identity
builder.Services.AddIdentity<ApplicationUserModel, IdentityRole>(options =>
{
    // Configurar Senha
    options.Password.RequiredLength = 10;
    options.Password.RequiredUniqueChars = 4;

    // Configurações de Bloqueio
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

    // Configuração Usuário
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


/* autenticacao
    Prepara a chave que será usada para validar os JWTs que chegam na API.
    A criação do token vai acontecer no JwtService.
*/
var jwtKey = builder.Configuration["JwtSettings:Key"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception(
        "A chave JWT não foi carregada"
    );
}
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
        JwtBearerDefaults.AuthenticationScheme;

    options.DefaultChallengeScheme =
        JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

      ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
      ValidAudience = builder.Configuration["JwtSettings:Audience"],

/* Transforma JWT_KEY em bytes 
   Transforma os bytes em uma chave criptográfica
   Essa chave será usada pelo JWT Bearer
   para verificar a assinatura dos tokens recebidos
*/
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtKey)
        )
    };
});

// autorizacao
builder.Services.AddAuthorization();

// Serviço de Arquivos
builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Connectamente API",
        Version = "v1",
        Description = "API de fornecimento de dados Connectamente"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Cabeçalho da Autorização JWT. Exemplo: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer" //Type = SecuritySchemeType.Http, o campo Scheme deve ser escrito em minúsculo
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
    // Isso limpa as redes conhecidas para que ele aceite os headers do proxy (comum em Docker/Hospedagens)
    options.KnownNetworks.Clear();
    options.KnownProxies.Clear();
});

builder.Services.AddSmartServices();
var app = builder.Build();

// 1. Deve ser o primeiro para entender o protocolo original
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseForwardedHeaders();
// Garantir que o banco exista ao executar o projeto
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await db.Database.MigrateAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Connectamente v1");
        c.RoutePrefix = string.Empty;
    });
}

//app.UseHttpsRedirection();  //Se redireciona a autentica��o da errado

app.UseStaticFiles();

app.UseCors("MinhaPolitica"); 




app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();