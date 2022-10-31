using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level[] levels;
    private Level currentLevel;
    
    
    private void Start() {
        Data.Instance.SetLevel(1);

        Debug.Log("level: "+ Data.Instance.GetLevel());
        LoadLevel(Data.Instance.GetLevel());
        OnInit();
        
    }
    public void LoadLevel(int index)
    {
        Data.Instance.SetLevel(index);
        if(currentLevel != null)
        {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(levels[index-1]);
    }

    
   public void OnInit()
   {
        currentLevel.OnInit();
   }

   public void OnStart()
   {

        currentLevel.OnStart();
        GameManagerr.Instance.currentState = EGameState.GamePlay;
   }

   public void OnFinish()
   {
        
        GameManagerr.Instance.ChangeState(EGameState.Finish);
        if(currentLevel.isWin)
        {
            UIManager.Instance.OpenUI<Win>();
        }
        else
        {
            UIManager.Instance.OpenUI<Lose>();
        }
        
   }
   
}
