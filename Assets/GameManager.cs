using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public networkPlayer[] players;
    public networkPlayer localPlayer;
    public static GameManager instance;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Register()
    {
        players = FindObjectsOfType<networkPlayer>();
        foreach(networkPlayer plr in players)
        {
            if (plr.isLocalPlayer)
            {
                localPlayer = plr;
            }
        }
        Filter();
    }
    public void Filter()
    {
        players = players.Where(player=> player.ticker == Data.ticker).ToArray();
    }
}
