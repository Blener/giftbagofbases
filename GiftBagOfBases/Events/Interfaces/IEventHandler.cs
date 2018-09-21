namespace GiftBagOfBases.Events.Interfaces
{
    public interface IEventHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}