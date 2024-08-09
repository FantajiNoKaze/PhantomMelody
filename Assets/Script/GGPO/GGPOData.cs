using System.Collections.Generic;
using System.Diagnostics;
public interface IGGPOData
{

    void AddPlayer(int PlayerID);
    void DeletePlayer(int PlayerID);
    void Write_Log(int PlayerID, int TimeFrame, Log Log);
    Log Read_Log(int PlayerID, int TimeFrame);

}
public class GGPOData : IGGPOData
{
    private readonly Dictionary<int, List<Log>> _GGPO_Log = new();
    int ListLengh = 8000;
    public void AddPlayer(int PlayerID)
    {
        _GGPO_Log.Add(PlayerID, NewLogList());
        List<Log> NewLogList()
        {
            List<Log> _list = new List<Log>();
            for (int i = 0; i < ListLengh; i++)
            {
                _list.Add(new Log());
            }
            return _list;
        }
    }
    public void DeletePlayer(int PlayerID)
    {
        _GGPO_Log.Remove(PlayerID);
    }
    public void Write_Log(int PlayerID, int TimeFrame, Log Log)
    {
        Log _Log = _GGPO_Log[PlayerID][TimeFrame];
        _Log.InputLog = Log.InputLog;
        _Log.TimeLog = Log.TimeLog;
        _Log.StateLog = Log.StateLog;
    }
    public Log Read_Log(int PlayerID, int TimeFrame)
    {
        return _GGPO_Log[PlayerID][TimeFrame];
    }

}




