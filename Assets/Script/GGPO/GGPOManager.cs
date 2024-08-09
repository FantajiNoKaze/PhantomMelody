
using System.Collections.Generic;
using VContainer.Unity;

public class GGPOManager : IStartable, IFixedTickable
{
    private readonly IGGPOService _GGPOService;
    private readonly IInputService _InputService;
    private readonly IWorldData _WorldData;
    //private readonly IGetOutlandPlayerData _GetOutlandPlayerData;

    Log _Log = new();
    public int TimeFrame = 0;
    public GGPOManager(IGGPOService GGPOService, IWorldData WorldData, IInputService InputService)
    {
        _GGPOService = GGPOService;
        _WorldData = WorldData;
        _InputService = InputService;

    }
    void IStartable.Start()
    {
        foreach (var p in _WorldData.GetPlayerGroup())
        {
            UnityEngine.Debug.Log("Creat GGPO : " + p);
        }
        _GGPOService.InitGGPO(_WorldData.GetPlayerGroup());
    }
    void IFixedTickable.FixedTick()
    {
        LocalPlayerPostGGPO();
        OutlandPlayerPostGGPO();
        TimeFrame++;
    }
    void LocalPlayerPostGGPO()
    {
        _Log.InputLog = _InputService.Read();
        _Log.TimeLog = TimeFrame;
        _Log.StateLog = LogState.accept;
        _GGPOService.Post(1, TimeFrame, _Log);
    }
    void OutlandPlayerPostGGPO()
    {

    }


}