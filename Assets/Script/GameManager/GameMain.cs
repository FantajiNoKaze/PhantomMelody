
using System.Collections.Generic;
using VContainer.Unity;

public interface IRunner
{
    void RunInit();
    void Runner();
}
public class GameMain : IStartable, IFixedTickable
{

    List<IRunner> _ManagerGroup = new();
    public GameMain(GameManager GameManager, PlayerManager PlayerManager, InputManager InputManager, GGPOManager GGPOManage, SocketManager SocketManager)
    {
        _ManagerGroup.Add(PlayerManager);
        _ManagerGroup.Add(InputManager);
        _ManagerGroup.Add(GGPOManage);
        _ManagerGroup.Add(SocketManager);
        _ManagerGroup.Add(GameManager);
    }
    public void Start()
    {
        foreach (var Manager in _ManagerGroup)
        {
            Manager.RunInit();
        }
    }
    public void FixedTick()
    {
        foreach (var Manager in _ManagerGroup)
        {
            Manager.Runner();
        }
    }


}