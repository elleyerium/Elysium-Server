namespace NetCoreServer.Server
{
    public interface IMessage
    {
        void Send();
        void Receive();
    }
}