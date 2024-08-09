
using UnityEngine;
using VContainer.Unity;

public class SocketManager : IStartable, IFixedTickable
{
    int TimeFrame = 0;//之後要在world統一 現在先亂放
    private IGGPOService _GGPOService;
    private ISocketService _SocketService;

    public SocketManager(IGGPOService GGPOService, ISocketService SocketService)
    {
        _GGPOService = GGPOService;
        _SocketService = SocketService;
    }
    void IStartable.Start()
    {

    }
    void IFixedTickable.FixedTick()
    {
        _SocketService.Broadcast(PacketType.GGPOMessage, JsonUtility.ToJson(_GGPOService.Get(1, TimeFrame)));//1 is local playerID
        TimeFrame++;
    }
}