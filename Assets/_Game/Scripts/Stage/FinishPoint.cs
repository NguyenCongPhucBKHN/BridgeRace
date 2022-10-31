using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public Level currentLevel;
     void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>()!= null)
        {
            currentLevel.isWin = true;
            LevelManager.Instance.OnFinish();
        }
        if(other.GetComponent<Enemy>()!= null)
        {
            currentLevel.isWin = false;
            LevelManager.Instance.OnFinish();
        }

    }
}
