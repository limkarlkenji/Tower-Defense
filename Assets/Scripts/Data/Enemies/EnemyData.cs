using UnityEngine;

[CreateAssetMenu(menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public Sprite portrait;
    public GameObject prefab;
    public float health;
    public float speed;
    public int damage; // Damage to player life
    public float goldReward;
    public float scoreReward;
}
