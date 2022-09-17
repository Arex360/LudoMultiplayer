using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowPath : MonoBehaviour
{
    public float radius;
    public List<Transform> path;
    public Dictionary<int, Transform> pathDict;
    void Start()
    {
        pathDict = new Dictionary<int, Transform>();
        int id = 0;
        foreach (Transform obj in this.transform)
        {
            Gizmos.DrawSphere(obj.position, radius);
            path.Add(obj);
            if (!obj.GetComponent<PathPoint>())
            {
                obj.gameObject.AddComponent<PathPoint>();
            }
            obj.GetComponent<PathPoint>().index = id;
            pathDict.Add(id, obj);
            id++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        int id = 0;
       
    }
}
