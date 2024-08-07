using System.Collections.Generic;
using System.Diagnostics;
public interface IGGPOData
{
    void AddPlayer(int PlayerID);
    void DeletePlayer(int PlayerID);
    void POSTFrameLog(int PlayerID, Log Log);
    Log GETFrameLog(int PlayerID, int TimeFrame);

}
public class GGPOData : IGGPOData
{
    private Dictionary<int, List<Log>> _GGPO_Log = new();
    int ListLengh = 8000;
    List<Log> NewLogList()
    {
        List<Log> _list = new List<Log>();
        for (int i = 0; i < ListLengh; i++)
        {
            _list.Add(new Log());
        }
        return _list;
    }

    public void AddPlayer(int PlayerID)
    {
        _GGPO_Log.Add(PlayerID, NewLogList());
    }
    public void DeletePlayer(int PlayerID)
    {
        _GGPO_Log.Remove(PlayerID);
    }
    public Log GETFrameLog(int PlayerID, int TimeFrame)
    {
        return _GGPO_Log[PlayerID][TimeFrame];
    }
    public void POSTFrameLog(int PlayerID, Log Log)
    {
        Log _Log =  _GGPO_Log[PlayerID][Log.TimeLog];
        _Log.InputLog = Log.InputLog;
        _Log.TimeLog = Log.TimeLog;
        _Log.StateLog = Log.StateLog;
    }
}




