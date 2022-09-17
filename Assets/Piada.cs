using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class Piada : NetworkBehaviour
{
    public Data.DICE color;
    [SyncVar(hook = "OnChangeValue")]
    public int value;
    public int localV;

    IEnumerator Start()
    {
        while (true)
        {
            localV++;
            CmdSetValue(localV);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update()
    {
        if (!hasAuthority) return;
        CmdSetValue(localV);
    }

    [Command]
    public void CmdSetValue(int v)
    {
        value = v;
    }
    public void OnChangeValue(int o, int n)
    {
        if(color == Data.DICE.Yellow)
        {
            this.transform.position = YellowPath.instance.pathDict[n].position;
        }
    }
}
