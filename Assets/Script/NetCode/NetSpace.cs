using System.Collections;
using UnityEngine;
using VContainer.Unity;


public class NetSpace : MonoBehaviour
{
   
    public NetSpace()
    {
  
    }
    public void Fly(int PlayerID, string Packet)
    {
        StartCoroutine(DeliberatelyDelayPacket());

        IEnumerator DeliberatelyDelayPacket()
        {
            System.Random random = new System.Random();
            yield return new WaitForSeconds(random.Next(100, 100) / 1000);//延遲豪秒  預設先固定100ms              
        }
        if (!NotLost())
        {
           // _FakeNetTest.OnReceive(PlayerID, Packet);
            Debug.Log("PlayerID :" + PlayerID + " Packet :" + Packet);
        }
    }



    bool NotLost()
    {
        System.Random random = new System.Random();
        if (random.Next(1, 1) != 1) //隨機遺失封包 預設先不遺失
        {
            return true;
        }
        return false;
    }
}