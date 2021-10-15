using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tower Set")]
public class TowerSetData : ScriptableObject
{
    public List<TowerData> towers = new List<TowerData>();
}
