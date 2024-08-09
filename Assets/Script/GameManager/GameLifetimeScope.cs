using System.Collections.Generic;
using Unity.Entities.UniversalDelegates;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponentInHierarchy<NetSpace>();

        //Data
        builder.Register<IWorldData, WorldData>(Lifetime.Singleton);
        builder.Register<IPlayerData, PlayerData>(Lifetime.Singleton);
        builder.Register<IInputData, InputData>(Lifetime.Singleton);
        builder.Register<IGGPOData, GGPOData>(Lifetime.Singleton);
        builder.Register<IMessageBuffer, MessageBuffer>(Lifetime.Singleton);
        //Service
        builder.Register<IInputService, InputService>(Lifetime.Singleton);
        builder.Register<IGGPOService, GGPOService>(Lifetime.Singleton);
        builder.Register<ISocketService, SocketService>(Lifetime.Singleton);
        //Manager
        builder.Register<GameManager>(Lifetime.Singleton);
        builder.Register<PlayerManager>(Lifetime.Singleton);
        builder.Register<InputManager>(Lifetime.Singleton);
        builder.Register<GGPOManager>(Lifetime.Singleton);
        builder.Register<SocketManager>(Lifetime.Singleton);

       

        //EntryPoint
        builder.RegisterEntryPoint<GameMain>();

    }

}
public interface IWorldData
{
    List<int> GetPlayerGroup();
    void InitPlayerGroup(List<int> PlayerGroup);
    int GetLocalPlayerID();
    int GetTimeFrame();
    void ClockTimeFrame();
}
public class WorldData : IWorldData
{
    private List<int> _PlayerGroup = new();
    private int _TimeFrame = 0;
    public int GetLocalPlayerID()
    {
        return _PlayerGroup[0];
    }
    public int GetTimeFrame()
    {
        return _TimeFrame;
    }
    public void ClockTimeFrame()
    {
        _TimeFrame++;
    }
    public List<int> GetPlayerGroup()
    {
        return _PlayerGroup;
    }
    public void InitPlayerGroup(List<int> PlayerGroup)
    {
        _PlayerGroup = PlayerGroup;
    }
}
