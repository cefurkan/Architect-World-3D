using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    Default,
    Tutorial,
    InGame,   
}
public class GameHandler : MonoBehaviour
{
    public UnityAction<GameState, GameState> OnGameSateChange;
    public GameState gameState;
    private static GameHandler instance;
    public static GameHandler Instance => instance;
    private void Start()
    {
        instance = this;
        gameState = GameState.Default;

    }
    public void ChangeGameState(GameState newState)
    {
        GameState oldGameState = gameState;
        gameState = newState;
        OnGameSateChange?.Invoke(oldGameState,gameState);

    }

}

