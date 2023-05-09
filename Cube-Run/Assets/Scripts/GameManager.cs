using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.CodeDom;


public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Singleton()
    {
        if(instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion
    #region MonoBehaviour
    private void Awake()
    {
        Singleton();
    }
    #endregion

    private GameState gameState = GameState.MainMenu;
    public GameObject GameOverScreen;
    public GameObject Finish;
    public bool IsSessionPlaying => gameState == GameState.SessionisPlaying;


    private void OnEnable()
    {
        DelegateStore.GameStateChange += OnGameStateChange;
    }


    #region Callback
    private void OnGameStateChange(GameState _gameState)
    {
        gameState = _gameState;
    }
    #endregion

    public void GameOver()
    {
        GameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Success()
    {
        Finish.SetActive(true);
    }
}

public enum GameState
{
    SessionisPlaying,
    MainMenu
}