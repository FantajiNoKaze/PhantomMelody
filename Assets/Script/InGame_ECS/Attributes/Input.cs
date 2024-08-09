

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

public struct  Log
{
    public InputSignal InputLog;
    public int TimeLog;
    public LogState StateLog;
    
}