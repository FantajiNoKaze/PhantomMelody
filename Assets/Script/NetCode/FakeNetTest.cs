
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public interface IFakeNetTestData
{
    void InitChannel(List<int> PlayerGroup);
    Packet? GetPacket(int PlayerID);
    void PostPacket(int PlayerID, Packet Packet);
}
public class FakeNetTestData : IFakeNetTestData
{
    readonly Dictionary<int, Queue<Packet>> _PlayerChannel = new();
    public void InitChannel(List<int> PlayerGroup)
    {
        foreach (var PlayerChannel in PlayerGroup)
        {
            _PlayerChannel.Add(PlayerChannel, new Queue<Packet>());
        }
    }
    public Packet? GetPacket(int PlayerID)
    {
        if (_PlayerChannel[PlayerID].Count > 0)
            return _PlayerChannel[PlayerID].Dequeue();
        else
            return null;
    }
    public void PostPacket(int PlayerID, Packet Packet)
    {
        _PlayerChannel[PlayerID].Enqueue(Packet);
    }
}
public class FakeNetTest : MonoBehaviour, IStartable, ITickable
{

    private IFakeNetTestData _FakeNetTestData;
    private ISocketService _SocketService;
    private IWorldData _WorldData;
    public FakeNetTest(IFakeNetTestData FakeNetTestData, ISocketService SocketService, IWorldData WorldData)
    {
        _FakeNetTestData = FakeNetTestData;
        _SocketService = SocketService;
        _WorldData = WorldData;
    }
    void IStartable.Start()
    {
        _FakeNetTestData.InitChannel(_WorldData.GetPlayerGroup());
    }
    void ITickable.Tick()
    {
        foreach (var PlayerID in _WorldData.GetPlayerGroup())
        {
            if (_FakeNetTestData.GetPacket(PlayerID) is Packet Packet)
            {
                Fly(PlayerID, Packet);
            }
        }
    }

    void OnSend(int ToPlayerID, Packet Packet)
    {
        _FakeNetTestData.PostPacket(ToPlayerID, Packet);
    }

    void Fly(int PlayerID, Packet Packet)
    {

        //void DeliberatelyLostPacket();
        StartCoroutine(DeliberatelyDelayPacket());

        IEnumerator DeliberatelyDelayPacket()
        {
            System.Random random = new System.Random();
            yield return new WaitForSeconds(random.Next(100, 100) / 1000);//延遲豪秒      
        }
        OnReceive(PlayerID, Packet);
    }
    void OnReceive(int FormPlayerID, Packet Packet)
    {
        _SocketService.ReceivePacket(FormPlayerID, Packet);
    }
}