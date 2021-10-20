using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInfoUI : MonoBehaviour
{
    [SerializeField] private Image _portrait;
    [SerializeField] private Text _infoTitle;
    [SerializeField] private EnemyDetailsUI _enemyDetailsUI;
    [SerializeField] private TowerDetailsUI _towerDetailsUI;

    private Sprite _defaultSprite;
    private string _defaultTitle;

    private GameObject _currentHudInfo;
    private GameObject _prevHudInfo;

    private void Start()
    {
        _defaultSprite = _portrait.sprite;
        _defaultTitle = _infoTitle.text;
    }

    public void SetHUDInfo()
    {
        _portrait.sprite = _defaultSprite;
        _infoTitle.text = _defaultTitle;
        SetCurrentHudInfo(null);
    }

    public void SetHUDInfo(Sprite portrait, string infoTitle)
    {
        _portrait.sprite = portrait;
        _infoTitle.text = infoTitle;
        SetCurrentHudInfo(null);

    }

    public void SetHUDInfo(Sprite portrait, string infoTitle, Enemy e)
    {
        _portrait.sprite = portrait;
        _infoTitle.text = infoTitle;
        _enemyDetailsUI.SetProperties(e.Health, e.Damage, e.Speed);

        SetCurrentHudInfo(_enemyDetailsUI.gameObject);
    }

    public void SetHUDInfo(Sprite portrait, string infoTitle, Tower t)
    {
        _portrait.sprite = portrait;
        _infoTitle.text = infoTitle;
        _towerDetailsUI.SetProperties(t.Projectile.damage, t.FireRate);

        SetCurrentHudInfo(_towerDetailsUI.gameObject);
    }

    private void SetCurrentHudInfo(GameObject current)
    {
        if (current == null) { if (_currentHudInfo != null) { _currentHudInfo.SetActive(false); } return; }

        _prevHudInfo = (_currentHudInfo != null) ? _currentHudInfo : null;
        if (_prevHudInfo != null) { _prevHudInfo.SetActive(false); }

        _currentHudInfo = current;
        _currentHudInfo.SetActive(true);
    }
}
