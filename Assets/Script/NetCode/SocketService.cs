using System;
using NUnit.Framework;
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public interface ISocketService
{
    void SendPacket<T>(int ToPlayerID, PacketType PacketType, T Message);
    void Broadcast<T>(PacketType PacketType, T Message);
    void ReceivePacket(int FormPlayerID, string Packet);
}
public class SocketService : ISocketService
{

    private readonly IPlayerData _PlayerData;
    private readonly IMessageBuffer _MessageBuffer;
    private readonly IWorldData _WorldData;
    private readonly NetSpace _NetSpace;

    public SocketService(IPlayerData PlayerData, IMessageBuffer MessageBuffer, IWorldData WorldData, NetSpace NetSpace)
    {

        _PlayerData = PlayerData;
        _MessageBuffer = MessageBuffer;
        _WorldData = WorldData;
        _NetSpace = NetSpace;
    }


    public void Broadcast<T>(PacketType PacketType, T Message)
    {
        foreach (int ToPlayer in _PlayerData.GetPlayerGroup())
        {
            if (ToPlayer != _WorldData.GetLocalPlayerID())
            {
                Send(ToPlayer, PacketType, Serializable(Message));

            }
        }
    }
    public void ReceivePacket(int FormPlayerID, string Packet)
    {
        var _Packet = Unpack(Packet);
        if (_Packet.Item1 == PacketType.SystemMessage)
        {

        }
        if (_Packet.Item1 == PacketType.GGPOMessage)
        {
            _MessageBuffer.WriteGGPOMessage(FormPlayerID, (Log)DeSerializable<Log>(_Packet.Item2));
        }
    }

    (PacketType, string) Unpack(string Packet)
    {
        Packet _Packet = DeSerializable<Packet>(Packet);
        return (_Packet.PacketType, _Packet.Message);


    }



    public void SendPacket<T>(int ToPlayerID, PacketType PacketType, T Message)
    {

        Send(ToPlayerID, PacketType, Serializable(Message));
    }
    void Send(int ToPlayerID, PacketType PacketType, string Packet)
    {
        Packet _Packet = new();
        _Packet.PacketType = PacketType;
        _Packet.Message = Packet;
        _NetSpace.Fly(ToPlayerID, Serializable(_Packet));
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