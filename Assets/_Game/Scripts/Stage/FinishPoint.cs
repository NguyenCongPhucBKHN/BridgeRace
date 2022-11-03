using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] public Transform TF;
    public Level currentLevel;

    public CameraFollow cam;
    void Awake()
    {
        TF= gameObject.transform;
    }

    void Start()
    {
        cam= FindObjectOfType<CameraFollow>();
        
    }
     void OnTriggerEnter(Collider other)
    {
        if(currentLevel!=null)
        {
            cam.FollowEndGame(TF.position);
            Character character = other.GetComponent<Character>();
            if(character != null)
            {
                character.ClearCharBrick();
                character.ChangeAnim(Constant.ANIM_WIN);
                Type playerType = (new Player()).GetType();
                Type characterType = character.GetType();
                if(characterType.IsAssignableFrom(playerType))
                {
                    currentLevel.isWin = true;
  
                }
                else
                {
                    currentLevel.isWin = false;
                }
                
                LevelManager.Instance.OnFinish();
            }
        }
       
    }

    
}
