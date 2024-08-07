
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Zenject;

public class GGPOController
{


}
public class GGPOManager : MonoBehaviour
{
    private readonly IGGPOData _GGPOData;
    private readonly IPlayerData _PlayerData;
    private readonly IInputData _InputData;

    int _TimeFrame = 0;
    Log _log = new();

    int LocalPlayerID;
    //private Dictionary<int,int> PlayerInputID_Bridge_GGPOID;

    [Inject]
    public GGPOManager(IGGPOData GGPOData, IPlayerData PlayerData, IInputData InputData)
    {
        _GGPOData = GGPOData;
        _PlayerData = PlayerData;
        _InputData = InputData;
    }
    void Start()
    {
        InitGGPO();
    }
    void FixedUpdate()
    {
        POSTLog_FromLocal(LocalPlayerID);
        //POSTLog_FromOutland(_NetData.GetInputSingal_LogBuffers());
        _TimeFrame += 1;
    }
    void POSTLog_FromLocal(int LocalPlayerID)
    {

        _log.InputLog = _InputData.Read();
        _log.TimeLog = _TimeFrame;
        _log.StateLog = LogState.accept;
        _GGPOData.POSTFrameLog(LocalPlayerID, _log);
    }
    void POSTLog_FromOutland(Dictionary<int, List<Log>> OutlandLogBuffers)//預設netcodeManager的LogBuffers已經排好對應Player跟時戳。
    {
        int _RollbackTime = 9999;
        bool _Rollback = false;

        foreach (var _O in OutlandLogBuffers)
        {
            foreach (Log _Log in _O.Value)
            {
                if (_GGPOData.GETFrameLog(_O.Key, _Log.TimeLog).InputLog != _Log.InputLog)
                {
                    _Log.StateLog = LogState.accept;
                    _GGPOData.POSTFrameLog(_O.Key, _Log);
                    _RollbackTime = FurthestbackTime(_Log.TimeLog, _RollbackTime);
                    _Rollback = true;
                }
                else
                {
                    _Log.StateLog = LogState.accept;
                    _GGPOData.POSTFrameLog(_O.Key, _Log);
                }
            }
        }
        //RePredict();//重新預測
        if(_Rollback){
            //Rollback(_RollbackTime);世界回滾
        }
    
    }

    void Predict()
    {

    }
    void RePredict(int TimeLog)
    {

    }

    void Rollback(int TimeLog)
    {

    }
    int FurthestbackTime(int furthest, int close)
    {
        if (furthest < close)
        {
            return furthest;
        }
        else
        {
            return close;
        }
    }

    void InitGGPO()
    {
        List<int> _Players = _PlayerData.GetAllPlayerID();
        foreach (var _Player in _Players)
        {
            _GGPOData.AddPlayer(_Player);
        }
    }
}