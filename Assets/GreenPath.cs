using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenPath : MonoBehaviour
{
    public float radius;
    public List<Transform> path;
    public Dictionary<int, Transform> pathDict;
    public static GreenPath instance;
    void Start()
    {
        instance = this;
        pathDict = new Dictionary<int, Transform>();
        int id = 0;
        foreach (Transform obj in this.transform)
        {
            path.Add(obj);
            if (!obj.GetComponent<PathPoint>())
            {
                obj.gameObject.AddComponent<PathPoint>();
            }
            obj.GetComponent<PathPoint>().index = id;
            pathDict.Add(id, obj);
            print(pathDict[id].position);
            id++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
