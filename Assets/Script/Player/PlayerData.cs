
using System.Collections.Generic;
using System.Linq;
using Zenject.SpaceFighter;


public class Player
{

}
public interface IPlayerData
{
    void AddPlayer();
    List<int> GetAllPlayerID();
}
public class PlayerData : IPlayerData
{
    
    int PlayerID;
    private Dictionary<int, Player> _Players;


    public void AddPlayer()
    {
        _Players.Add(PlayerID += 1, new Player());
    }
    public List<int> GetAllPlayerID()//看到幫我修(功能:返回所有key)
    {
        List<int> _AllPlayerID = new();
        foreach (KeyValuePair<int, Player> kvp in _Players)
        {
            _AllPlayerID.Add(kvp.Key);
        }
        return _AllPlayerID;
    }
 
}