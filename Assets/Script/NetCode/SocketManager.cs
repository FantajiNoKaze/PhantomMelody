
using UnityEngine;
using VContainer.Unity;

public class SocketManager : IRunner
{
    private IGGPOService _GGPOService;
    private ISocketService _SocketService;
    private IWorldData _WorldData;
    private IMessageBuffer _MessageBuffer;
    public SocketManager(IGGPOService GGPOService, ISocketService SocketService, IWorldData WorldData, IMessageBuffer MessageBuffer)
    {
        _GGPOService = GGPOService;
        _SocketService = SocketService;
        _WorldData = WorldData;
        _MessageBuffer = MessageBuffer;
    }
    public void RunInit()
    {
        _MessageBuffer.Init(_WorldData.GetPlayerGroup());
    }
    public void Runner()
    {
        SendLocalLog();
        LoadGGPOMessageBuffer();
    }
    void SendLocalLog()
    {
        _SocketService.Broadcast(PacketType.GGPOMessage, (Log)_GGPOService.Get(_WorldData.GetLocalPlayerID(), _WorldData.GetTimeFrame()));
    }
    void LoadGGPOMessageBuffer()
    {
        foreach (var Player in _WorldData.GetPlayerGroup())
        {
            var Buffer = _MessageBuffer.GetGGPOBuffer(Player);
            while (Buffer.Count > 0)
            {
                UnityEngine.Debug.Log(Buffer.Dequeue());
            }
        }

    }
}