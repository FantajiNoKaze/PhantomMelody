

using System;
using Unity.Entities;

public struct Controller : IComponentData
{
    public InputSignal inputSignal;

}

public enum LogState
{
    none,
    accept,
    predict
}
public class Log
{
    public InputSignal InputLog;
    public int TimeLog;
    public LogState StateLog;
    public Log()
    {
        InputLog = InputSignal.None;
        TimeLog = 0;
        StateLog = LogState.none;
    }
}