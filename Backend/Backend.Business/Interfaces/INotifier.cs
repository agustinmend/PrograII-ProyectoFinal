using System;
using System.Threading.Tasks;
namespace Backend.Business
{
    public interface INotifier
    {
        public Task NotifyAsync(string mensaje);
    }
}