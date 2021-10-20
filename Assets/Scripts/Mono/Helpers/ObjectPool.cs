using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Queue<GameObject> items = new Queue<GameObject>();

    [SerializeField] private GameObject prefab;
    [SerializeField] private int initialSize;

    public void InstantiatePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            GameObject g = Instantiate(prefab, transform);
            ReturnToPool(g);
        }
    }

    public GameObject GetFromPool()
    {
        GameObject g = items.Dequeue();
        g.SetActive(true);
        return g;
    }

    public void ReturnToPool(GameObject g)
    {
        g.transform.position = transform.position;
        g.SetActive(false);
        items.Enqueue(g);
    }
}
