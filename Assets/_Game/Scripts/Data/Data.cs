using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data:Singleton<Data>
{
    private int level;

    public int GetLevel()
    {
        Debug.Log("Level Manager: "+ level);
        return level;
    }
    public void SetLevel(int lv)
    {
        Debug.Log("Level Manager: "+ level);
        this.level =lv;
    }

    public int GetNextLevel()
    {
        level = MathMod(level, LevelManager.Instance.levels.Length);
        level++;
        
        Debug.Log("Level Manager: "+ level);
        return level;
    }

    public int MathMod(int a, int b) 
    {
        return (Mathf.Abs(a * b) + a) % b;
    }


   
}
