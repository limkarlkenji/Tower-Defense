using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIView : BaseView<UIModel, UIController>
{
    [Header("Menu")]
    [SerializeField] private GameObject waveStart;
    [SerializeField] private TMP_Text waveCountdown;
    [SerializeField] private GameObject gameOver;
    [Header("Information")]
    [SerializeField] private HUDInfoUI hudInfo;
    [SerializeField] private Text _lblLives;
    [SerializeField] private Text _lblWave;
    [SerializeField] private Text _lblGold;
    [Header("Actions")]
    [Header("Tower Actions")]
    [SerializeField] private TowerActionUI towerActionUI;
    [Header("Tower Builder")]
    [SerializeField] private GameObject towerBuilderUI;

    [Header("Data(Don't edit)")]
    [SerializeField] private GameObject currentActionUI;
    [SerializeField] private GameObject previousActionUI;


    // =====================================================================================================
    // Menu
    // =====================================================================================================
    public void DisplayWaveCountdown(float countDown = 0)
    {
        if(countDown == 0)
        {
            waveStart.SetActive(false);
            return;
        }
        else
        {
            waveCountdown.text = countDown.ToString();
        }
        waveStart.SetActive(true);
    }

    public void DisplayGameOver()
    {
        gameOver.SetActive(true);
    }

    // =====================================================================================================
    // Game Info
    // =====================================================================================================
    public void Unselect()
    {
        hudInfo.SetHUDInfo();
        SetActionUI(null);
    }

    public void SetGold(float gold)
    {
        _lblGold.text = "Gold: " + gold;
    }

    public void SetLife(int currLives)
    {
        _lblLives.text = "Lives: " + currLives;
    }

    public void SetWave(int currWave)
    {
        _lblWave.text = "Current Wave: " + currWave;
    }

    /// <summary>
    /// Display tower information
    /// </summary>
    /// <param name="tower"></param>
    public void DisplayTowerInfo(Tower tower)
    {
        hudInfo.SetHUDInfo(tower.Portrait, tower.TowerName);
        DisplayTowerAction(tower);
    }
    // =====================================================================================================
    // Selected Actions
    // =====================================================================================================

    /// <summary>
    /// Set active ui
    /// </summary>
    /// <param name="current">Set current to null to hide all</param>
    private void SetActionUI(GameObject current)
    {
        if(current == null) { currentActionUI.SetActive(false); return; }

        previousActionUI = (currentActionUI != null) ? currentActionUI : null;
        if (previousActionUI != null) { previousActionUI.SetActive(false); }

        currentActionUI = current;
        currentActionUI.SetActive(true);

    }

    /// <summary>
    /// Display list of all towers a player can build
    /// </summary>
    /// <param name="towers"></param>
    /// <param name="onClick"></param>
    public void DisplayTowerList(TowerSetData towers, UnityAction<TowerData> onClick)
    {
        hudInfo.SetHUDInfo();
        // TODO pool this
        Controller.DisplayShop(towers, towerBuilderUI.transform, onClick);
        SetActionUI(towerBuilderUI);
    }

    /// <summary>
    /// Display actions a player can do when a tower is selected
    /// </summary>
    /// <param name="tower"></param>
    public void DisplayTowerAction(Tower tower)
    {
        towerActionUI.SetButton(()=> { 
            tower.Sell();
            Unselect();
        });
        SetActionUI(towerActionUI.gameObject);
    }

}
