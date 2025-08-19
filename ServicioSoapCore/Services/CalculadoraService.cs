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
