using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense;

public class TowerTile : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    public Tower Tower { get { return _tower; } private set { _tower = value; } }

    public void SetTower(Tower t)
    {
        Tower = t;
    }
}
