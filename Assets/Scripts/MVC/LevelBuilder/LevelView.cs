using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelView : BaseView<LevelModel, LevelController>
{
    public Map currentMap;
    public int nextWave;

    [Header("References")]
    [SerializeField] private UIView ui;
    [SerializeField] private PlayerView player;

    public void SpawnWave()
    {
        if(nextWave == Model.waveSet.waves.Count) { GameEnd(); return; }

        currentMap.GetPath();
        StartCoroutine(Controller.cSpawnWave(Model.waveSet.waves[nextWave].enemyCount, nextWave, currentMap, PollEnemyCount, 
            (source, gold, score) => {
                player.AddCoins(gold);
                player.AddScore(score);
            }));
        nextWave += 1;
    }

    public void PollEnemyCount()
    {
        StartCoroutine(Controller.cWaitForWaveComplete(currentMap.enemyParent, WaitForNextWave));
    }

    public void  WaitForNextWave()
    {
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
        ui.DisplayGameOver(player.currentScore);
        Debug.Log("End");
    }
}
