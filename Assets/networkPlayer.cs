using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;
public class networkPlayer : NetworkBehaviour
{
    [SyncVar(hook = "OnCreateTicker")]
    public string ticker;
    public GameObject canvas;
    public TMP_InputField tickerText;

    void Start()
    {
        if (!isLocalPlayer)
        {
            canvas.SetActive(false);
        }
        for(int i = 0; i < 100; i++)
        {
            print(Dice.Roll());
        }
    }
    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        CmdSetTicker(Data.ticker);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdSpawn();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CmdSpawnTeam((int) Data.DICE.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CmdSpawnTeam((int)Data.DICE.Red);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CmdSpawnTeam((int)Data.DICE.Green);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CmdSpawnTeam((int)Data.DICE.Blue);
        }
    }
    public void SetTicker()
    {
        Data.ticker = tickerText.text;
    }
    [Command]
    public void CmdSpawnTeam(int team)
    {
        GameObject plr = Instantiate(NetworkManager.singleton.spawnPrefabs[team]);
        NetworkServer.Spawn(plr, connectionToClient);
    }
    [Command]
    public void CmdSpawn()
    {
        GameObject plr = Instantiate(NetworkManager.singleton.spawnPrefabs[0]);
        NetworkServer.Spawn(plr,connectionToClient);
    }
    [Command]
    public void CmdSetTicker(string t)
    {
        ticker = t;
    }
    public void OnCreateTicker(string o, string n)
    {
        if (n == "") return;
        GameManager.instance.Register();
    }
}
