using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    // public void WinButton()
    // {
    //     UIManager.Instance.OpenUI<Win>().score.text = Random.Range(100, 200).ToString();
    //     Close();
    // }

    // public void LoseButton()
    // {
    //     UIManager.Instance.OpenUI<Lose>().score.text = Random.Range(0, 100).ToString(); 
    //     Close();
    // }

    // public void SettingButton()
    // {
    //     UIManager.Instance.OpenUI<Setting>();
    // }

    public void RePlayButton()
    {
        UIManager.Instance.OpenUI<MianMenu>();
        GameManagerr.Instance.ChangeState(EGameState.MainMenu);
        LevelManager.Instance.LoadLevel(1);
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
