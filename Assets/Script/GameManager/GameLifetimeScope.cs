using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IWorldData, WorldData>(Lifetime.Singleton);
        builder.RegisterEntryPoint<PlayerManager>();
        builder.Register<IPlayerData, PlayerData>(Lifetime.Singleton);
        
       
        builder.RegisterEntryPoint<FakeNetTest>();
        builder.Register<IFakeNetTestData, FakeNetTestData>(Lifetime.Singleton);
        builder.Register<IMessageBuffer, MessageBuffer>(Lifetime.Singleton);

        
        builder.RegisterEntryPoint<InputManager>();
        builder.Register<IInputData, InputData>(Lifetime.Singleton);
        builder.Register<IInputService, InputService>(Lifetime.Singleton);

        builder.RegisterEntryPoint<GGPOManager>();
        builder.Register<IGGPOData, GGPOData>(Lifetime.Singleton);
        builder.Register<IGGPOService, GGPOService>(Lifetime.Singleton);

        builder.RegisterEntryPoint<SocketManager>();
        builder.Register<ISocketData, SocketData>(Lifetime.Singleton);
        builder.Register<INetSocket, NetSocket>(Lifetime.Singleton);
        builder.Register<ISocketService, SocketService>(Lifetime.Singleton);


    }

}
public interface IWorldData
{
    List<int> GetPlayerGroup();
    void InitPlayerGroup(List<int> PlayerGroup);
}
public class WorldData : IWorldData
{
    private List<int> _PlayerGroup;
    private int TimeFrame;

    public List<int> GetPlayerGroup()
    {
        return _PlayerGroup;
    }
    public void InitPlayerGroup(List<int> PlayerGroup)
    {
        _PlayerGroup = PlayerGroup;
    }
}
