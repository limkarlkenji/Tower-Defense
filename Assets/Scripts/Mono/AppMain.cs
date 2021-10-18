using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class AppMain : MonoBehaviour
{
    public static AppMain Instance;

    public UIView ui;
    public PlayerView player;
    public BuilderView builder;
    public LevelView level;

    [Header("Helpers")]
    [SerializeField] private ObjectPool objectPool;

    [Header("Data")]
    [SerializeField] private GameObject clicked;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        objectPool.InstantiatePool();
        player.RegisterEvents(ui);
        level.WaitForNextWave();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            if (!EventSystem.current.IsPointerOverGameObject()) // Prevent raycast from going through UI
            {
                Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        clicked = hit.collider.gameObject;
                        switch(clicked.tag)
                        {
                            case ("Tower"):
                                ui.DisplayTowerInfo(clicked.GetComponent<Tower>());
                                break;
                            case ("TowerTile"):
                                builder.TowerTileClicked(clicked, clicked.GetComponent<TowerTile>(), objectPool);
                                break;
                        }
                    }

                }
            }

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
