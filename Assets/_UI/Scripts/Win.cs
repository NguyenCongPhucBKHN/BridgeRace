using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : UICanvas
{
    public Text score;

    public void MainMenuButton()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        Close();
    }

    public void RePlayButton()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        LevelManager.Instance.LoadLevel(1);
        Data.Instance.SetLevel(1);
        Close();

    }

    public void LoadNextLevel()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        LevelManager.Instance.LoadLevel(Data.Instance.GetNextLevel());
        Close();
    }

}
