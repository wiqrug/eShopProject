using Microsoft.EntityFrameworkCore;
using Project2.Services;
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
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CandidateServices>();
builder.Services.AddScoped<AdminServices>();
builder.Services.AddScoped<CertificateServices>();
builder.Services.AddScoped<CandidateCertificatesServices>();
builder.Services.AddScoped<ExamService>();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    string? connectioString = builder.Configuration.GetConnectionString("PeopleCertDB");
    options.UseSqlServer(connectioString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
