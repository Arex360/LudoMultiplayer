using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkConnection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Mirror.NetworkManager.singleton.StartHost();
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            System.Uri uri = new System.Uri("ws://192.168.0.103:7778/");
            print(uri);
            Mirror.NetworkManager.singleton.StartClient(uri);
        }
    }
}
