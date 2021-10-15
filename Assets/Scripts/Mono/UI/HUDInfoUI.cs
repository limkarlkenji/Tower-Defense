using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDInfoUI : MonoBehaviour
{
    [SerializeField] private Image _portrait;
    [SerializeField] private Text _infoTitle;

    private Sprite _defaultSprite;
    private string _defaultTitle;

    private void Start()
    {
        _defaultSprite = _portrait.sprite;
        _defaultTitle = _infoTitle.text;
    }

    public void SetHUDInfo()
    {
        _portrait.sprite = _defaultSprite;
        _infoTitle.text = _defaultTitle;
    }

    public void SetHUDInfo(Sprite portrait, string infoTitle)
    {
        _portrait.sprite = portrait;
        _infoTitle.text = infoTitle;
    }
}
