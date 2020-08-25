using CozHep.Domain.Core.Commands;
using CozHep.Domain.Core.Events;
using System.Threading.Tasks;


namespace CozHep.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
