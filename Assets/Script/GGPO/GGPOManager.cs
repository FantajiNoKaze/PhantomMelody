
using System.Collections.Generic;
using VContainer.Unity;

public class GGPOManager : IRunner
{
    private readonly IGGPOService _GGPOService;
    private readonly IWorldData _WorldData;
    public GGPOManager(IGGPOService GGPOService, IWorldData WorldData)
    {
        _GGPOService = GGPOService;
        _WorldData = WorldData;

    }
    public void RunInit()
    {
        foreach (var p in _WorldData.GetPlayerGroup())
        {
            UnityEngine.Debug.Log("Creat GGPO : " + p);
        }
        _GGPOService.InitGGPO(_WorldData.GetPlayerGroup());
    }

    public void Runner()
    {

    }
}