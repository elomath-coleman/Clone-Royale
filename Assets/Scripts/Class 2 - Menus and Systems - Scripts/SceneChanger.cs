using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // The singleton variable, accessible at the script level without a direct object reference (static)
    public static SceneChanger instance;

    [SerializeField] string menuSceneName;
    [SerializeField] string howToPlaySceneName;
    [SerializeField] string creditsSceneName;
    [SerializeField] string gameSceneName;

    private void Awake()
    {
        // If the singleton value is empty, assign this script as the singleton
        //  -- We do not need to include a Destroy command, as the parent GameManager
        //  -- object will self-destroy upon detecting a duplicate
        if (instance == null) instance = this;
    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene(howToPlaySceneName);
    }

    public void LoadCreditsScene()
    {
        SceneManager.LoadScene(creditsSceneName);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}
