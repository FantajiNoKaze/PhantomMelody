
using System.Collections.Generic;
using VContainer.Unity;

public class GGPOManager : IRunner
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
    void LocalPlayerPostGGPO()
    {
        _Log.InputLog = _InputService.Read();
        _Log.TimeLog = TimeFrame;
        _Log.StateLog = Log.State.accept;
        _GGPOService.Post(1, TimeFrame, _Log);
    }
    void OutlandPlayerPostGGPO()
    {

    }

    public void Init()
    {
        foreach (var p in _WorldData.GetPlayerGroup())
        {
            UnityEngine.Debug.Log("Creat GGPO : " + p);
        }
        _GGPOService.InitGGPO(_WorldData.GetPlayerGroup());
    }

    public void Runner()
    {
        LocalPlayerPostGGPO();
        OutlandPlayerPostGGPO();
        TimeFrame++;
    }
}