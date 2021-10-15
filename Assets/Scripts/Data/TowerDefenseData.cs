using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tower Defense Data")]
public class TowerDefenseData : ScriptableObject
{
    public float timeBetweenWaves;

    public TowerSetData towerSet;
    public WaveSetData waveSet;
    
}
