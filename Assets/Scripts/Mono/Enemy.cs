using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public float health;
    public float speed;
    public int damage;
    public float goldReward;

    public event Action OnKill;

    public void TakeDamage(float damageReceived)
    {
        health -= damageReceived;
        if(health <= 0)
        {
            OnKill?.Invoke();
            Destroy(gameObject);
        }
    }

    public void SetProperties(EnemyData d)
    {
        health = d.health;
        speed = d.speed;
        damage = d.damage;
        goldReward = d.goldReward;
    }

    public void Move(List<Transform> path)
    {
        StartCoroutine(cMove(path));
    }

    private IEnumerator cMove(List<Transform> path)
    {
        int i = 0;
        while(i <= path.Count-1)
        {
            while(transform.position != path[i].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[i].position, speed * Time.deltaTime);
                transform.LookAt(path[i].position);
               
                yield return null;
            }
            i++;
            yield return null;
        }
    }
}
