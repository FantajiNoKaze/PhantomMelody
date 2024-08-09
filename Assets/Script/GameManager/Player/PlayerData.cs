
using System.Collections.Generic;
using System.Linq;

public class Player
{

}
public interface IPlayerData
{
    void AddPlayer();
    List<int> GetPlayerGroup();
}
public class PlayerData : IPlayerData
{
    int PlayerID;
    private Dictionary<int, Player> _Players = new();
    public void AddPlayer()
    {
        _Players.Add(PlayerID += 1, new Player());
    }
    public List<int> GetPlayerGroup()//看到幫我修(功能:返回所有key)
    {
        List<int> _PlayerGroup = new();
        foreach (KeyValuePair<int, Player> kvp in _Players)
        {
            _PlayerGroup.Add(kvp.Key);
        }
        return _PlayerGroup;
    }

}