using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator _animator;

    public float health;
    public float speed;
    public int damage;
    public float goldReward;
    public float scoreReward;

    public event Action<string, float, float> OnKill;

    public void TakeDamage(float damageReceived, float goldReward, float scoreReward, string source)
    {
        if(health > 0)
        {
            health -= damageReceived;
            if (health <= 0)
            {
                _animator.Play("Die");
                OnKill?.Invoke(source, goldReward, scoreReward);
                speed = 0;
                StartCoroutine(cDestroy());
            }
        }
    }

    public void SetProperties(EnemyData d)
    {
        health = d.health;
        speed = d.speed;
        damage = d.damage;
        goldReward = d.goldReward;
        scoreReward = d.scoreReward;
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

    private IEnumerator cDestroy()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);

    }
}
