using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Transform pathRoot;
    public List<Transform> path;
    public Transform spawnPosition;
    public Transform endPosition;
    public Transform enemyParent;

    public void GetPath()
    {
        for(int i = 0; i < pathRoot.childCount; i++)
        {
            path.Add(pathRoot.GetChild(i));
        }
        spawnPosition = path[0];
        endPosition = path[path.Count - 1];
    }
}
