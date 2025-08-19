# ServicioWebSoap

<img width="2559" height="1034" alt="image" src="https://github.com/user-attachments/assets/f2b4c4c2-5c7b-4a0c-a069-dfa1f22d2696" />

<img width="2553" height="1079" alt="image" src="https://github.com/user-attachments/assets/29d11e41-3e33-4438-b1f6-29c9a35195a8" />

# 🧼 Crear y Probar un Servicio Web SOAP en .NET 6+ con SoapCore

> ⚠️ **Nota importante**  
> .NET Core y versiones posteriores (.NET 6, .NET 7, .NET 8) **no soportan directamente** servicios SOAP tipo `.asmx`, como en .NET Framework.  
> Sin embargo, es posible crear servicios SOAP en ASP.NET Core utilizando librerías como [SoapCore](https://github.com/DigDes/SoapCore).

---

## ✅ Parte 1: Crear un Servicio Web SOAP en .NET Core (con SoapCore)

### 1. Crear un nuevo proyecto

1. Abre **Visual Studio 2022**.
2. Selecciona **Create a new project**.
3. Elige **ASP.NET Core Web API**.
4. Asigna un nombre, por ejemplo: `ServicioSoapCore`.
5. En la siguiente pantalla:
   - **Framework**: .NET 6 o .NET 8.
   - Desmarca **"Use controllers"**.
6. Clic en **Create**.

---

### 2. Instalar el paquete SoapCore

Abre la consola de NuGet o el administrador de paquetes y ejecuta:

```bash
Install-Package SoapCore
3. Crear la interfaz del servicio
Agrega una carpeta llamada Services y dentro crea el archivo ICalculadoraService.cs:

csharp
Copiar código
using System.ServiceModel;

namespace ServicioSoapCore.Services
{
    [ServiceContract]
    public interface ICalculadoraService
    {
        [OperationContract]
        int Sumar(int a, int b);

        [OperationContract]
        int Restar(int a, int b);
    }
}
4. Implementar la clase del servicio
Dentro de la misma carpeta Services, crea el archivo CalculadoraService.cs:

csharp
Copiar código
namespace ServicioSoapCore.Services
{
    public class CalculadoraService : ICalculadoraService
    {
        public int Sumar(int a, int b)
        {
            return a + b;
        }

        public int Restar(int a, int b)
        {
            return a - b;
        }
    }
}
5. Configurar el archivo Program.cs
Reemplaza el contenido de Program.cs con:

csharp
Copiar código
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
6. Ejecutar el servicio
Presiona F5 para iniciar la aplicación.

Visualiza el servicio en: http://localhost:<puerto>/Calculadora.asmx.

Copia esta URL para probarla en SOAP UI.

✅ Parte 2: Probar el Servicio SOAP en SOAP UI
1. Abrir SOAP UI
File → New SOAP Project.

Nombre del proyecto: PruebaCalculadora.

En el campo WSDL, pega:

arduino
Copiar código
http://localhost:<puerto>/Calculadora.asmx?wsdl
2. Ejemplo de request para el método Sumar
xml
Copiar código
<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/">
   <soapenv:Header/>
   <soapenv:Body>
      <tem:Sumar>
         <tem:a>5</tem:a>
         <tem:b>3</tem:b>
      </tem:Sumar>
   </soapenv:Body>
</soapenv:Envelope>
3. Respuesta esperada
xml
Copiar código
<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
   <soap:Body>
      <SumarResponse xmlns="http://tempuri.org/">
         <SumarResult>8</SumarResult>
      </SumarResponse>
   </soap:Body>
</soap:Envelope>
🧩 Comparación con ASMX
Característica	.asmx (.NET Framework)	SoapCore (.NET 6+)
Tecnología	Clásica (obsoleta)	Moderna (ASP.NET Core)
Soporte de Microsoft	Limitado	Comunidad activa
Ideal para	Migraciones, legado	Proyectos modernos

