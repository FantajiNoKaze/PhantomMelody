
using VContainer.Unity;

public class GameManager : IRunner
{
    private IWorldData _WorldData;
    public GameManager(IWorldData WorldData){
        _WorldData =  WorldData;
    }
    public void RunInit()
    {
        
    }

    public void Runner()
    {
       _WorldData.ClockTimeFrame();
    }
}