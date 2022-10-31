using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
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
        Close();

    }

    public void ReLoadLevel()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        LevelManager.Instance.LoadLevel(Data.Instance.GetLevel());
        Close();
    }
}
