
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;




public class NetTestData
{
    public Dictionary<int, Packet> SoaringPackets = new();
}
public class NetTestManager : IStartable, IFixedTickable
{

    private NetTestData _NetTestData;
    public NetTestManager(NetTestData NetTestData)
    {
        _NetTestData = NetTestData;
    }
    void IStartable.Start()
    {
        
    }
    void IFixedTickable.FixedTick()
    {

    }
    void ReceiveTrigger()
    {

    }
}