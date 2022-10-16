using Infrastructure;
using Convey;
using Application;
using Api.Controllers;
using Infrastructure.Exceptions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddInfrastructure(configuration);
builder.Services
    .AddConvey()
    .AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddGrpc(x => x.Interceptors.Add<GrpcExceptionHandler>());
var app = builder.Build();

//app.UseMiddleware<ExceptionMiddleware>();
app.MapGrpcService<NotificationController>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/error");
    app.UseSwagger();                     
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
