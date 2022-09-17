using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPath : MonoBehaviour
{
    public float radius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        foreach(Transform obj in this.transform)
        {
            Gizmos.DrawSphere(obj.position, radius);
        }
    }
}
