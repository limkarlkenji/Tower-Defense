using System;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public event Action<int> OnBaseHit;


    public void BaseHit(int damage)
    {
        OnBaseHit?.Invoke(damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
            BaseHit(enemy.damage);
            enemy.TakeDamage(10000000, 0, 0, "Base");
        }
    }
}
