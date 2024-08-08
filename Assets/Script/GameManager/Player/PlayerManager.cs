
using VContainer.Unity;

public class PlayerManager : IStartable, IFixedTickable
{
    private readonly IPlayerData _PlayerData;
    

    public PlayerManager (IPlayerData PlayerData)
    {
        _PlayerData = PlayerData;
    }
    void IStartable.Start()
    {
        _PlayerData.AddPlayer();
        _PlayerData.AddPlayer();
        foreach (var p in _PlayerData.GetAllPlayerID())
        {
            UnityEngine.Debug.Log("Creat Player : " + p);
        }
    }
    void IFixedTickable.FixedTick()
    {

    }


}