using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MianMenu : UICanvas
{
    
    public void PlayButton()
    {
        // UIManager.Instance.OpenUI<GamePlay>();

        LevelManager.Instance.OnStart();
        GameManagerr.Instance.ChangeState(EGameState.GamePlay);
        Close();
    }
}
