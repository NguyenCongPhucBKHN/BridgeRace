using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public Level[] levels;
    private Level currentLevel;
    private void Start() {
        LoadLevel(1);
        OnInit();
    }
    void LoadLevel(int index)
    {
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
   
}
