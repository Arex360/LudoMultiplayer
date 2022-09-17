using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class NetworkObject : NetworkBehaviour
{
    [SyncVar(hook = "OnChangeTicker")]
    public string network_ticker;
    void Start()
    {
        if (!hasAuthority) return;
        this.transform.position = this.transform.position +  new Vector3(Random.Range(0, 35), Random.Range(0, 15), Random.Range(0,35));
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority) return;
        if (Data.ticker == "") return;
        CmdSetTicker(Data.ticker);
    }
    [Command]
    public void CmdSetTicker(string ticker)
    {
        network_ticker = ticker;
    }
    public void OnChangeTicker(string o, string n)
    {
        if (n == "") return;
        else
        {
            if(n != Data.ticker)
            {
                this.gameObject.SetActive(false);
            }
        }
            
    }
}
