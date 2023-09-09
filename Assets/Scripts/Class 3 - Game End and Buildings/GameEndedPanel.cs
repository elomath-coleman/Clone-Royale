using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameEndedPanel : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI panelText;
    [SerializeField] string playerWonText = "Game Over- You won!";
    [SerializeField] string playerLostText = "Game Over- You lost!";

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) PlayerWon();
        if (Input.GetKeyDown(KeyCode.Alpha2)) PlayerLost();
    }

    public void PlayerWon()
    {
        gameOverPanel.SetActive(true);
        panelText.text = playerWonText;
    }
    public void PlayerLost()
    {
        gameOverPanel.SetActive(true);
        panelText.text = playerLostText;
    }
}
