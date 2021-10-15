using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    public GameObject Target { get { return _target; } private set { _target = value; } }

    private float _damage;
    private float _speed;
    private Action<Enemy> _onHit;

    public void SetProperties(ProjectileData projectileData, Transform initialPos, GameObject target, Action<Enemy> onHit)
    {
        Target = target;
        _onHit = onHit;
        _damage = projectileData.damage;
        _speed = projectileData.speed;

        transform.position = initialPos.position;

        StartCoroutine(cFire());
    }

    private IEnumerator cFire()
    {
        while (Target != null)
        {
            if (Target != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
            }
            yield return null;
        }
        _onHit?.Invoke(null);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Enemy e = collider.GetComponent<Enemy>();
        if(e != null)
        {
            e.TakeDamage(_damage);
            _onHit?.Invoke(e);
        }
    }
}
