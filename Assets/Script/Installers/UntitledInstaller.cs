using UnityEngine;
using Zenject;

public class UntitledInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInputData>().To<InputData>().AsSingle();
        Container.Bind<IPlayerData>().To<PlayerData>().AsSingle();
        Container.Bind<IGGPOData>().To<GGPOData>().AsSingle();
        Container.Bind<InputManager>().FromComponentInHierarchy().AsSingle();
    }

}