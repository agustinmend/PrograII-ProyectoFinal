using System;
using System.Threading.Tasks;
namespace Backend.Business
{
    public class ConsoleNotifier : INotifier
    {
        public Task NotifyAsync(string mensaje)
        {
            Console.WriteLine($"Notificacion por consola: {mensaje}");
            return Task.CompletedTask;
        }        
    }
}
