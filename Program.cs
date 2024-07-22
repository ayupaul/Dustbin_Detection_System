using Buisness_Layer.EmailConfig;
using Buisness_Layer.Services.AreaService;
using Buisness_Layer.Services.EmailService;
using Buisness_Layer.Services.NotifyService;
using Common.FetchCoordinates;
using Core.Data;
using Core.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var emailConfig = builder.Configuration.GetSection("EmailConfiguration")
    .Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IAreaService, AreaService>();
builder.Services.AddScoped<INotifyService, NotifyService>();
builder.Services.AddHttpClient<ICoordinatesService,CoordinatesService>();
builder.Services.AddControllers();
builder.Services.Configure<APIKey>(builder.Configuration.GetSection("Secret"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
