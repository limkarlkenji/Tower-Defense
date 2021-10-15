using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerActionUI : MonoBehaviour
{
    [SerializeField] private Button _sell;
    
    public void SetButton(UnityAction onClick)
    {
        _sell.onClick?.RemoveAllListeners(); // Clear previous listeners
        _sell.onClick.AddListener(onClick);
    }
}
