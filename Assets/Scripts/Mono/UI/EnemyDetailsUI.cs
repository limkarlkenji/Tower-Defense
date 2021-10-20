using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDetailsUI : MonoBehaviour
{
    [SerializeField] private Text _health;
    [SerializeField] private Image _healthBar;
    [SerializeField] private Text _damage;
    [SerializeField] private Text _speed;

    public EnemyDetailsUI SetProperties(float health, int damage, float speed)
    {
        _health.text = health.ToString();
        _damage.text = damage.ToString();
        _speed.text = speed.ToString();

        return this;
    }
}
