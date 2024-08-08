
using System;
using System.Collections.Generic;
using System.Net.Mail;
public enum PacketType
{
    SystemMessage,
    GGPOMessage
}

[Serializable]
public class Packet
{
    public PacketType PacketType;
    public string Message;
}
public class Socket
{


}

public interface ISocketData
{

}

public class SocketData : ISocketData
{
    readonly Dictionary<Socket, int> BridgeTable;//Socket to PlayerID
    readonly Dictionary<int, Queue<Packet>> ReceivePacketBuffer;

    void EnQueueReceivePacket(int FromPlayerID, Packet Packet)
    {
        ReceivePacketBuffer[FromPlayerID].Enqueue(Packet);
    }
    Packet DeQueueReceivePacket(int FromPlayerID)
    {
        return ReceivePacketBuffer[FromPlayerID].Dequeue();
    }
}