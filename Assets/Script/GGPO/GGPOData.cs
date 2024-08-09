using System.Collections.Generic;
using System.Diagnostics;
public struct Log
{
    public InputSignal InputLog;
    public int TimeLog;
    public State StateLog;

    public enum State
    {
        none,
        accept,
        predict
    }

}
public interface IGGPOData
{

    void AddPlayer(int PlayerID);
    void DeletePlayer(int PlayerID);
    void Write_Log(int PlayerID, int TimeFrame, Log Log);
    Log Read_Log(int PlayerID, int TimeFrame);
    void SetGGPOLengh(int ListLengh);

}
public class GGPOData : IGGPOData
{
    private readonly Dictionary<int, List<Log>> _GGPO_Log = new();
    int _ListLengh = 8000;
    public void AddPlayer(int PlayerID)
    {
        _GGPO_Log.Add(PlayerID, NewLogList());
        List<Log> NewLogList()
        {
            List<Log> _list = new List<Log>();
            for (int i = 0; i < _ListLengh; i++)
            {
                _list.Add(new Log());
            }
            return _list;
        }
    }
    public void SetGGPOLengh(int ListLengh)
    {
        _ListLengh = ListLengh;
    }
    public void DeletePlayer(int PlayerID)
    {
        _GGPO_Log.Remove(PlayerID);
    }
    public void Write_Log(int PlayerID, int TimeFrame, Log Log)
    {
        _GGPO_Log[PlayerID][TimeFrame] = Log;
    }
    public Log Read_Log(int PlayerID, int TimeFrame)
    {
        return _GGPO_Log[PlayerID][TimeFrame];
    }

}




