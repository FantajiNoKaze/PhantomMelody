
public interface INetSocket
{

}

public class NetSocket : INetSocket
{
    private ISocketData _SocketData;
    public NetSocket(ISocketData SocketData)
    {
        _SocketData = SocketData;
    }
    void Send()
    {
        
    }
}