
using System;
using System.Collections.Generic;
using System.Net.Mail;
public enum PacketType
{
    SystemMessage,
    GGPOMessage
}

[Serializable]
public struct Packet
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

public interface IMessageBuffer
{
    Queue<Log> ReadGGPOBuffer(int PlayerID);
    void WriteGGPOMessage(int PlayerID, Log Log);

}
public class SystemMessage
{

}
public class MessageBuffer : IMessageBuffer
{
    readonly Dictionary<int, Queue<SystemMessage>> ToBeExecute_SystemMessageBuffer;
    readonly Dictionary<int, Queue<Log>> ToBeExecute_GGPOMessageBuffer;

    public Queue<Log> ReadGGPOBuffer(int PlayerID)
    {
        return ToBeExecute_GGPOMessageBuffer[PlayerID];
    }
    public void WriteGGPOMessage(int PlayerID, Log Log)
    {
        ToBeExecute_GGPOMessageBuffer[PlayerID].Enqueue(Log);
    }
}