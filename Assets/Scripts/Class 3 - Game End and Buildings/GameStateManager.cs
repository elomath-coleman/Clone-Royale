using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;

    [SerializeField] GameEndedPanel gameEndedPanel;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void PlayerWon()
    {
        gameEndedPanel.PlayerWon();
        // Disable Units
        // Play Special Effects and Sounds
    }
    public void PlayerLost()
    {
        gameEndedPanel.PlayerLost();
        // Disable Units
        // Play Special Effects and Sounds
    }
}
