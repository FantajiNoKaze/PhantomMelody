using System.Collections.Generic;
using Unity.VisualScripting;

public interface IGGPOService
{
    void InitGGPO(List<int> PlayerID_Group);
    (bool, int) Post(int PlayerID, int TimeFrame, Log Log);
    Log Get(int PlayerID, int TimeFrame);
    void Predict(int PlayerID, int CurrentTimrPoint);
    void RePredict(int PlayerID, int PredicTimePoint, int CurrentTimrPoint);

}
public class GGPOService : IGGPOService
{

    private readonly IGGPOData _GGPOData;

    public GGPOService(IGGPOData GGPOData)
    {
        _GGPOData = GGPOData;
    }
    public void InitGGPO(List<int> PlayerID_Group)
    {
        foreach (int PlayerID in PlayerID_Group)
        {
            _GGPOData.AddPlayer(PlayerID);
        }
    }
    //void AddPlayer();
    //void DelePlayer();
    public (bool, int) Post(int PlayerID, int TimeFrame, Log Log)
    {
        bool checking = false;
        if (Log.InputLog == _GGPOData.Read_Log(PlayerID, TimeFrame).InputLog)
        {
            checking = true;
        };
        Log.StateLog = Log.State.accept;
        _GGPOData.Write_Log(PlayerID, TimeFrame, Log);
        return (checking, TimeFrame);
    }
    public Log Get(int PlayerID, int TimeFrame)
    {
        return _GGPOData.Read_Log(PlayerID, TimeFrame);
    }
    public void Predict(int PlayerID, int CurrentTimrPoint)
    {
        Log log = new();
        InputSignal PredicSignal;
        int PredicTimePoint = CurrentTimrPoint;
        while (_GGPOData.Read_Log(PlayerID, PredicTimePoint).StateLog != Log.State.none || PredicTimePoint == 0)
        {
            if (_GGPOData.Read_Log(PlayerID, PredicTimePoint).StateLog == Log.State.none)
            {
                PredicTimePoint -= 1;
            };
        }
        PredicSignal = _GGPOData.Read_Log(PlayerID, PredicTimePoint).InputLog;
        for (int i = PredicTimePoint; i <= CurrentTimrPoint; i++)
        {
            log.InputLog = PredicSignal;
            log.TimeLog = PredicTimePoint;
            log.StateLog = Log.State.predict;
            _GGPOData.Write_Log(PlayerID, PredicTimePoint, log);
        }
    }
    public void RePredict(int PlayerID, int PredicTimePoint, int CurrentTimrPoint)
    {
        Log _Log = new();
        for (int i = PredicTimePoint; i <= CurrentTimrPoint; i++)
        {
            if (_GGPOData.Read_Log(PlayerID, PredicTimePoint).StateLog == Log.State.predict)
            {
                _GGPOData.Write_Log(PlayerID, PredicTimePoint, ChangeLog_Time_State(_Log, _GGPOData.Read_Log(PlayerID, PredicTimePoint - 1), PredicTimePoint, Log.State.predict));
            }
        }
        Log ChangeLog_Time_State(Log _Log, Log Reflog, int TimeFrame, Log.State LogState)
        {
            _Log.InputLog = Reflog.InputLog;
            _Log.TimeLog = TimeFrame;
            _Log.StateLog = LogState;
            return _Log;
        }
    }
    public void Rollback(int PlayerID)
    {

    }


}