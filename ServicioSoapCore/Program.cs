using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServicioSoapCore.Services;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddSingleton<ICalculadoraService, CalculadoraService>();
builder.Services.AddMvc();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ICalculadoraService>("/Calculadora.asmx", new SoapCore.SoapEncoderOptions(), SoapCore.SoapSerializer.XmlSerializer);
});

app.Run();