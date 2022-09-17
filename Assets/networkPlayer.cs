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
    }
    public void SetTicker()
    {
        Data.ticker = tickerText.text;
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
