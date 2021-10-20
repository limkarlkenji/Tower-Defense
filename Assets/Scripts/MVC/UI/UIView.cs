using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class UIView : BaseView<UIModel, UIController>
{
    [Header("Menu")]
    [SerializeField] private GameObject _waveStart;
    [SerializeField] private TMP_Text _waveCountdown;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Text _gameOverMessage;
    [SerializeField] private Text _gameOverFinalScore;
    [Header("Information")]
    [SerializeField] private HUDInfoUI _hudInfo;
    [SerializeField] private Text _lblLives;
    [SerializeField] private Text _lblWave;
    [SerializeField] private Text _lblGold;
    [SerializeField] private Text _lblScore;
    [Header("Actions")]
    [Header("Tower Actions")]
    [SerializeField] private TowerActionUI _towerActionUI;
    [Header("Tower Builder")]
    [SerializeField] private GameObject _towerBuilderUI;

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
            _waveStart.SetActive(false);
            return;
        }
        else
        {
            _waveCountdown.text = countDown.ToString();
        }
        _waveStart.SetActive(true);
    }

    public void DisplayGameOver(float finalScore, string message = "")
    {
        _gameOver.SetActive(true);
        _gameOverMessage.text = message;
        _gameOverFinalScore.text = finalScore.ToString();
    }

    // =====================================================================================================
    // Game Info
    // =====================================================================================================
    public void Unselect()
    {
        _hudInfo.SetHUDInfo();
        SetActionUI(null);
    }

    public void SetScore(float score)
    {
        _lblScore.text = "Score: " + score;
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
        _hudInfo.SetHUDInfo(tower.Portrait, tower.TowerName, tower);
        DisplayTowerAction(tower);
    }

    public void DisplayEnemyInfo(Enemy enemy)
    {
        _hudInfo.SetHUDInfo(enemy.Portrait, enemy.EnemyName, enemy);
        SetActionUI(null);
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
        if(current == null) { if (currentActionUI != null) { currentActionUI.SetActive(false); } return; }

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
        _hudInfo.SetHUDInfo();
        // TODO pool this
        Controller.DisplayShop(towers, _towerBuilderUI.transform, onClick);
        SetActionUI(_towerBuilderUI);
    }

    /// <summary>
    /// Display actions a player can do when a tower is selected
    /// </summary>
    /// <param name="tower"></param>
    public void DisplayTowerAction(Tower tower)
    {
        _towerActionUI.SetButton(()=> { 
            tower.Sell();
            Unselect();
        });
        SetActionUI(_towerActionUI.gameObject);
    }

}
