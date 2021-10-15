using System.Collections.Generic;
using UnityEngine;
using TowerDefense; 

[CreateAssetMenu(menuName = "Model/Level")]
public class LevelModel : BaseModel
{
    public MapBuilder levelTemplate;
    public WaveSetData waveSet;
    public EnemyData enemyData;
    public float spawnRate;

}
