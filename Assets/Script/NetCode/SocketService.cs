using NUnit.Framework;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public interface ISocketService
{
    void SendPacket<T>(int ToPlayerID, PacketType PacketType, T Message);
    void Broadcast(PacketType PacketType, string Message);
    void ReceivePacket(int FormPlayerID, Packet Packet);
}
public class SocketService : ISocketService
{
    private readonly ISocketData _SocketData;
    private readonly IPlayerData _PlayerData;
    private readonly IMessageBuffer _MessageBuffer;

    public SocketService(ISocketData SocketData, IPlayerData PlayerData, IMessageBuffer MessageBuffer)
    {
        _SocketData = SocketData;
        _PlayerData = PlayerData;
        _MessageBuffer = MessageBuffer;
    }

    public void ReceivePacket(int FormPlayerID, Packet Packet)
    {
        if (Packet.PacketType == PacketType.SystemMessage)
        {

        }
        if (Packet.PacketType == PacketType.GGPOMessage)
        {
            _MessageBuffer.WriteGGPOMessage(FormPlayerID, DeSerializable<Log>(Packet.Message));
        }
    }

    public void SendPacket<T>(int ToPlayerID, PacketType PacketType, T Message)
    {
        Packet _Packet = new();
        _Packet.PacketType = PacketType;
        _Packet.Message = Serializable(Message);
        Send(ToPlayerID, _Packet);
    }
    void Send(int ToPlayerID, Packet _Packet)
    {

    }
    public void Broadcast(PacketType PacketType, string Message)
    {
        foreach (int ToPlayer in _PlayerData.GetPlayerGroup())
        {
            if (ToPlayer != 1)
            {
                SendPacket(ToPlayer, PacketType, Message);
            }
        }
    }
    string Serializable<T>(T Message)
    {
        return JsonUtility.ToJson(Message);
    }
    T DeSerializable<T>(string Message)
    {
        return JsonUtility.FromJson<T>(Message); ;
    }



}