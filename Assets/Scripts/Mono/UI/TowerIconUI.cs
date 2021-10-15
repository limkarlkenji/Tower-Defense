using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerIconUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Button _button;

    private TowerData _tower;

    public void SetComponents(TowerData tower, UnityAction<TowerData> onClick)
    {
        _tower = tower;

        _image.sprite = _tower.sprite;
        _button.onClick.AddListener(()=> { onClick(tower); });
    }
}
