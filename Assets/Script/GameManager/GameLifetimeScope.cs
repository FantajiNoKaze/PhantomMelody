using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<PlayerManager>();
        builder.Register<IPlayerData,PlayerData>(Lifetime.Singleton);

        builder.RegisterEntryPoint<InputManager>();
        builder.Register<IInputData,InputData>(Lifetime.Singleton);
        builder.Register<IInputService,InputService>(Lifetime.Singleton);

        builder.RegisterEntryPoint<GGPOManager>();
        builder.Register<IGGPOData,GGPOData>(Lifetime.Singleton);
        builder.Register<IGGPOService,GGPOService>(Lifetime.Singleton);
       
    }
}
