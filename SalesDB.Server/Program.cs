using SalesDB.Server.Service;
using SalesDB.Server.DTOs;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SettingsBD>(
	 builder.Configuration.GetSection("API")
);
builder.Services.AddSingleton<SellerService>();
builder.Services.AddSingleton<OpportunityService>();
builder.Services.AddSingleton<ApiService>();
builder.Services.AddHttpClient("apicnpj", c =>

  c.BaseAddress = new Uri("https://publica.cnpj.ws/")
);
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
