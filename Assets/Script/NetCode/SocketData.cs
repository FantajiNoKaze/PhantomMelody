
using System;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine.PlayerLoop;
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
    Queue<Log> GetGGPOBuffer(int PlayerID);
    void WriteGGPOMessage(int PlayerID, Log Log);
    void Init(List<int> PlayerGroup);

}
public struct SystemLog
{

}
public class MessageBuffer : IMessageBuffer
{
    readonly Dictionary<int, Queue<SystemLog>> ToBeExecute_SystemMessageBuffer = new();
    readonly Dictionary<int, Queue<Log>> ToBeExecute_GGPOMessageBuffer = new();

    public void Init(List<int> PlayerGroup)
    {
        foreach (int Player in PlayerGroup)
        {
            ToBeExecute_SystemMessageBuffer.Add(Player, new Queue<SystemLog>());
            ToBeExecute_GGPOMessageBuffer.Add(Player, new Queue<Log>());
        }

    }

    public Queue<Log> GetGGPOBuffer(int PlayerID)
    {
        return ToBeExecute_GGPOMessageBuffer[PlayerID];
    }
    public void WriteGGPOMessage(int PlayerID, Log Log)
    {
        ToBeExecute_GGPOMessageBuffer[PlayerID].Enqueue(Log);
    }
}