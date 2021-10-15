using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Wave Set")]
public class WaveSetData : ScriptableObject
{
    public float intervalBetweenWaves;
    public List<WaveData> waves = new List<WaveData>();
}
