using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public interface ISocketService
{
    void SendPacket<T>(int ToPlayerID, PacketType PacketType, T Message);
    void Broadcast(PacketType PacketType, string Message);
}
public class SocketService : ISocketService
{
    private readonly ISocketData _SocketData;
    private readonly IPlayerData _PlayerData;
    public SocketService(ISocketData SocketData, IPlayerData PlayerData)
    {
        _SocketData = SocketData;
        _PlayerData = PlayerData;
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
        foreach (int ToPlayer in _PlayerData.GetAllPlayerID())
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
    T DeSerializable<T>(PacketType PacketType, string Message)
    {
        if (PacketType == PacketType.SystemMessage)
        {
            return default(T);
        }
        if (PacketType == PacketType.GGPOMessage)
        {
            return JsonUtility.FromJson<T>(Message);
        }
        return default(T);
    }



}