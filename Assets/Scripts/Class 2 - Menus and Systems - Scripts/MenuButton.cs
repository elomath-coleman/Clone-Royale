using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneChanger.instance.LoadMenuScene();
    }

    public void LoadSettingsScene()
    {
        SceneChanger.instance.LoadSettingsScene();
    }
    public void LoadFriendsScene()
    {
        SceneChanger.instance.LoadSettingsScene();
    }

    public void LoadCreditsScene()
    {
        SceneChanger.instance.LoadCreditsScene();
    }

    public void LoadGameScene()
    {
        SceneChanger.instance.LoadGameScene();
    }
}


