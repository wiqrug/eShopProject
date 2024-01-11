using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project2.Models;
using Project2.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => {
        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        {
            Description = "Please enter token",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.OperationFilter<SecurityRequirementsOperationFilter>();
    });
builder.Services.AddScoped<IPasswordHasher<Candidate>, PasswordHasher<Candidate>>();
builder.Services.AddScoped<IPasswordHasher<Admin>, PasswordHasher<Admin>>();
builder.Services.AddScoped<AccountServices>();
builder.Services.AddScoped<CandidateServices>();
builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<CertificateServices>();
builder.Services.AddScoped<CandidateCertificatesServices>();
builder.Services.AddScoped<ExamService>();
builder.Services.AddScoped<CertificateServices>();
builder.Services.AddScoped<QuestionsServices>();
builder.Services.AddScoped<AuthenticationFilterCandidate>();
builder.Services.AddScoped<AuthenticationFilterAdmin>();

/*builder.Services.AddMvc(options =>              //Auto to service kanei to AuthenticationFilter GLOBAL oper methermineuomenon esti OLA ta controllers
{                                               //tha xrisimopoioun to filtro auto. An theloume kapoios controller na MIN to xrisimiopoiei prepei na 
    options.Filters.Add<AuthenticationFilter>();//valoume apo pano tou to annotation [AllowAnonymous] gia na epitrepei na ton xtipame xoris authentication
});                                             //diaforetika apenergopoioume ayto to service kai vazoume pano apo kathe controller to annotation [ServiceFilter(typeof(AuthenticationFilter))]
*/


builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    string? connectioString = builder.Configuration.GetConnectionString("PeopleCertDB");
    options.UseSqlServer(connectioString);
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:key"]!))
        };

    });


var app = builder.Build();
app.UseCors(options => options.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
