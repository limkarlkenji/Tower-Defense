using UnityEngine;

[CreateAssetMenu(menuName = "Model/Level")]
public class LevelModel : BaseModel
{
    public MapBuilder levelTemplate;
    public WaveSetData waveSet;
    public float spawnRate;

}
