using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data:Singleton<Data>
{
    private int level;

    public int GetLevel()
    {
        return level;
    }
    public void SetLevel(int lv)
    {
        this.level =lv;
    }

    public int GetNextLevel()
    {
        level++;
        level = MathMod(level, LevelManager.Instance.levels.Length+1);
        Debug.Log("Level Manager: "+ level);
        return level;
    }

    public int MathMod(int a, int b) 
    {
        return (Mathf.Abs(a * b) + a) % b;
    }


   
}
