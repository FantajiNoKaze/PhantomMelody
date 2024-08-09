
using Unity.Entities.UniversalDelegates;
using UnityEngine;
using VContainer.Unity;

public class InputManager : IRunner
{
    InputSignal _InputSignal = new();
    Log _Log = new();
    private IGGPOService _GGPOService;
    private IWorldData _WorldData;

    public InputManager(IGGPOService GGPOService, IWorldData WorldData)
    {
        _GGPOService = GGPOService;
        _WorldData = WorldData;
    }

    public void RunInit()
    {

    }

    public void Runner()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _InputSignal |= InputSignal.GetKeyDown_Up;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _InputSignal |= InputSignal.GetKeyDown_Dowm;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _InputSignal |= InputSignal.GetKeyDown_Left;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _InputSignal |= InputSignal.GetKeyDown_Right;
        }
        _Log.InputLog = _InputSignal;
        _Log.TimeLog = _WorldData.GetTimeFrame();
        _GGPOService.Post(_WorldData.GetLocalPlayerID(), _WorldData.GetTimeFrame(), _Log);

        _InputSignal &= InputSignal.None;


    }


}

