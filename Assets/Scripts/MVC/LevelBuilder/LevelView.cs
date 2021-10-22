using UnityEngine;

public class LevelView : BaseView<LevelModel, LevelController>
{
    public Map currentMap;
    public int nextWave;

    [Header("References")]
    [SerializeField] private UIView ui;
    [SerializeField] private PlayerView player;

    public void SpawnWave()
    {
        currentMap.GetPath();
        StartCoroutine(Controller.cSpawnWave(Model.waveSet.waves[nextWave].enemyCount, nextWave, currentMap, PollEnemyCount, 
            (source, gold, score) => {
                player.AddCoins(gold);
                player.AddScore(score);
            },
            Camera.main.transform));
        nextWave += 1;
    }

    public void PollEnemyCount()
    {
        StartCoroutine(Controller.cWaitForWaveComplete(currentMap.enemyParent, WaitForNextWave));
    }

    public void  WaitForNextWave()
    {
        if (nextWave == Model.waveSet.waves.Count) { GameEnd(); return; }
        StartCoroutine(Controller.cWaitForNextWave(Model.waveSet.intervalBetweenWaves, ui.DisplayWaveCountdown, WaitComplete));
    }

    public void WaitComplete()
    {
        ui.DisplayWaveCountdown(0);
        ui.SetWave(nextWave);
        SpawnWave();
    }

    public void GameEnd()
    {
        StopAllCoroutines();
        ui.DisplayGameOver(player.currentScore, (player.currentLives > 0) ? "You have completed all waves!" : "Game Over");
        Debug.Log("End");
    }
}
