
using System.Collections.Generic;
using VContainer.Unity;

public interface IRunner
{
    void Init();
    void Runner();
}
public class GameMain : IStartable, IFixedTickable
{
    IRunner _GameManager;
    IRunner _PlayerManager;
    IRunner _SocketManager;
    IRunner _GGPOManager;
    List<IRunner> ManagerGroup;
    public GameMain(IRunner GameManager, IRunner GGPOManager, IRunner PlayerManager, IRunner SocketManager)
    {
        _GameManager = GameManager;
        _PlayerManager = PlayerManager;
        _SocketManager = SocketManager;
        _GGPOManager = GGPOManager;
    }
    public void Start()
    {
        ManagerGroup.Add(_GameManager);
        ManagerGroup.Add(_PlayerManager);
       // ManagerGroup.Add(_GGPOManager);
      //  ManagerGroup.Add(_SocketManager);
       
        foreach (var Manager in ManagerGroup)
        {
            Manager.Init();
        }
    }
    public void FixedTick()
    {
        foreach (var Manager in ManagerGroup)
        {
            Manager.Runner();
        }
    }


}