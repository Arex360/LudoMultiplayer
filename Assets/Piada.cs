using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Piada : NetworkBehaviour
{
    public Data.DICE color;
    [SyncVar(hook = "OnChangeValue")]
    public int value;

    void Start()
    {
        
    }

    private void Update()
    {
        if (!hasAuthority) return;
        CmdSetValue(value);
    }

    [Command]
    public void CmdSetValue(int v)
    {
        value = v;
    }
    public void OnChangeValue(int o, int n)
    {

    }
}
