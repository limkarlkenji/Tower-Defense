using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _Img_healthBar;

    [SerializeField] private string _enemyName;
    [SerializeField] private Sprite _portrait;
    [SerializeField] private float _health;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _goldReward;
    [SerializeField] private float _scoreReward;


    public string EnemyName { get { return _enemyName; } private set { _enemyName = value; } }
    public Sprite Portrait { get { return _portrait; } private set { _portrait = value; } }
    public float Health { get { return _health; } private set { _health = value; } }
    public float Speed { get { return _speed; } private set { _speed = value; } }
    public int Damage { get { return _damage; } private set { _damage = value; } }
    public float GoldReward { get { return _goldReward; } private set { _goldReward = value; } }
    public float ScoreReward { get { return _scoreReward; } private set { _scoreReward = value; } }

    public event Action<string, float, float> OnKill;

    private float _initialHealth;
    private Transform _uiTarget;

    public void TakeDamage(float damageReceived, float goldReward, float scoreReward, string source)
    {
        if(_health > 0)
        {
            _health -= damageReceived;
            if (_health <= 0)
            {
                _animator.Play("Die");
                OnKill?.Invoke(source, goldReward, scoreReward);
                _speed = 0;
                StartCoroutine(cDestroy());
            }
            UpdateHealthBar(damageReceived);
        }
    }

    public void SetProperties(EnemyData d, Transform cam)
    {
        EnemyName = d.enemyName;
        Portrait = d.portrait;
        _health = d.health;
        _speed = d.speed;
        Damage = d.damage;
        GoldReward = d.goldReward;
        ScoreReward = d.scoreReward;

        _uiTarget = cam;
        _initialHealth = Health;


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
                transform.position = Vector3.MoveTowards(transform.position, path[i].position, _speed * Time.deltaTime);
                transform.LookAt(path[i].position);

                _Img_healthBar.canvas.transform.LookAt(-_uiTarget.transform.forward * 1000);

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

    private void UpdateHealthBar(float damage)
    {
        _Img_healthBar.fillAmount = (Health / _initialHealth);
    }
}
