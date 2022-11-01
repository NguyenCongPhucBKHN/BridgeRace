using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    public Level currentLevel;

    public CameraFollow cam;
    void Start()
    {
        cam= FindObjectOfType<CameraFollow>();
        
    }
     void OnTriggerEnter(Collider other)
    {
        if(currentLevel!=null)
        {
            cam.FollowEndGame(transform.position);
            Character character = other.GetComponent<Character>();
            if(character != null)
            {
                character.ClearCharBrick();
                character.ChangeAnim(Const.ANIM_WIN);
                currentLevel.isWin = true;
                LevelManager.Instance.OnFinish();
            }
        }
    }

    
}
