using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Map")]
public class MapBuilder : ScriptableObject
{
    public int mapSize;
    public int[,] map = new int[10,10];
    public string towerTileLayer;
    public GameObject tileStructure;
    public GameObject tileEnemyPath;
    public GameObject tileSpawn;
    public GameObject tileEnd;
    public int tileOffset;
    public List<Vector2> pathOrder = new List<Vector2>();

    public void BuildMap()
    {
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                if(map[x, y] == 1)
                { }
            }
        }

        GameObject mapRoot = new GameObject("Map");
        GameObject enemyRoot = new GameObject("Enemies");
        GameObject pathRoot = new GameObject("Path");
        GameObject towerRoot = new GameObject("Tower Tiles");

        enemyRoot.transform.parent = mapRoot.transform;
        pathRoot.transform.parent = mapRoot.transform;
        towerRoot.transform.parent = mapRoot.transform;

        for (int i = 0; i < pathOrder.Count; i++)
        {
            GameObject t = GameObject.Instantiate(tileEnemyPath, pathRoot.transform);
            t.name = "Path";
            t.transform.position = new Vector3(pathOrder[i].x + Vector3.right.x * tileStructure.transform.localScale.x, 0, pathOrder[i].y + Vector3.forward.z * tileStructure.transform.localScale.z);
        }

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                int tid = map[x, y];
                if(tid == 1) { continue; }
                GameObject t = GameObject.Instantiate(
                    (tid == 0) ? tileStructure : 
                            (tid == 2) ? tileSpawn :
                                (tid == 3) ? tileEnd : tileStructure, 
                    (map[x, y] == 0) ? towerRoot.transform : pathRoot.transform);


                if(tid == 0)
                {
                    t.name = "Empty";
                    t.layer = LayerMask.NameToLayer("towerTilelayer");
                }
                else if (tid == 2)
                {
                    t.transform.SetAsFirstSibling();
                    t.name = "Start";
                }
                else if (tid == 3)
                {
                    t.transform.SetAsLastSibling();
                    t.name = "End";
                }
                t.transform.position = new Vector3(x + Vector3.right.x * tileStructure.transform.localScale.x , 0, y + Vector3.forward.z * tileStructure.transform.localScale.z);
                
            }
        }

        Map m = mapRoot.AddComponent<Map>();
        m.pathRoot = pathRoot.transform;
        m.enemyParent = enemyRoot.transform;
    }

    public void RemoveFromPathOrder(int x, int y)
    {
        pathOrder.Remove(pathOrder.FirstOrDefault(p => p.x == x && p.y == y));
    }

    public void ClearMap()
    {
        map = new int[mapSize, mapSize];
        pathOrder.Clear();
    }
}
