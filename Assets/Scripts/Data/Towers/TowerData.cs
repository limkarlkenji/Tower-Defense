using UnityEngine;

[CreateAssetMenu(menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public GameObject prefab;
    public Sprite sprite;
    public float fireRate;
    public float cost;
    public float sellPrice;

    public ProjectileData projectile;

}
