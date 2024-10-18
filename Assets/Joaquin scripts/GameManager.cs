using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHUE player;
    public GameObject gameOverPanel;
    public GameObject gameWinPanel;
    [SerializeField] private HandlerEventoSO handlerfloat;
    [SerializeField] private int vida;

    public GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        //gameOverPanel.SetActive(false);
        //gameWinPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WinGame()
    {
        Time.timeScale = 0f;
        //gameWinPanel.SetActive(true);

    }
    public void LoseGame()
    {
        Time.timeScale = 0f;
        //gameOverPanel.SetActive(true);
    }

}


