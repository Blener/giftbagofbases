using GiftBagOfBases.Commands;
using GiftBagOfBases.Events;
using System.Threading.Tasks;

namespace GiftBagOfBases.Interfaces.Domain
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;

        Task RaiseEvent<T>(T @event) where T : Event;
    }
}