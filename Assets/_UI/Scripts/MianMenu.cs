using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MianMenu : UICanvas
{
    public Text level;
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        level.text= "Level: "+ Data.Instance.GetLevel().ToString();
    }
    public void PlayButton()
    {
        // UIManager.Instance.OpenUI<GamePlay>();

        LevelManager.Instance.OnStart();
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        Close();
    }
}
