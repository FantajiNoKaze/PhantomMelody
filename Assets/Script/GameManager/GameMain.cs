
using System;
using UnityEngine;
using UnityEngine.Events;

public class GameMain : MonoBehaviour
{
    public static Action gameUpdate;
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameUpdate.Invoke();
    }
}
