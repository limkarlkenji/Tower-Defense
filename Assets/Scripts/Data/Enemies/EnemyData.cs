using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public GameObject prefab;
    public float health;
    public float speed;
    public int damage;
    public float goldReward;
    public float scoreReward;
}
