
using VContainer.Unity;

public class PlayerManager : IStartable, IFixedTickable
{
    private readonly IPlayerData _PlayerData;
    private readonly IWorldData _WorldData;

    public PlayerManager(IPlayerData PlayerData, IWorldData WorldData)
    {
        _PlayerData = PlayerData;
        _WorldData = WorldData;
    }
    void IStartable.Start()
    {
        _PlayerData.AddPlayer();
        _PlayerData.AddPlayer();
        foreach (var p in _PlayerData.GetPlayerGroup())
        {
            UnityEngine.Debug.Log("Creat Player : " + p);
        }
        _WorldData.InitPlayerGroup(_PlayerData.GetPlayerGroup());
    }
    void IFixedTickable.FixedTick()
    {

    }


}