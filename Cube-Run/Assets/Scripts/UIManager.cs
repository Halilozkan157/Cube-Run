using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager instance;

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

    private void OnEnable()
    {
        DelegateStore.GameStateChange += OnGameStateChange;
    }

    private void OnDisable()
    {
        DelegateStore.GameStateChange -= OnGameStateChange;
    }

    public GameObject ButtonPlay;

    public void PlayGame()
    {
        DelegateStore.GameStateChange?.Invoke(GameState.SessionisPlaying);
    }

    private void OnGameStateChange(GameState _gameState)
    {
        if(_gameState == GameState.SessionisPlaying)
        {
            ButtonPlay.SetActive(false);
        }
        else if (_gameState == GameState.MainMenu)
        {
            ButtonPlay.SetActive(true);
        }
    }


}
