using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [SerializeField] Rigidbody player;
    // [SerializeField] Transform tfCenterJoystick;

    // private bool isControl => Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)>0.1;

    private void Start() 
    {
        OnInit();
    }
   
    private void Update()
    {
        if(currentLevel!= null)
        {
            if(!CheckStair() || (!JoystickInput.Instance.isControl && !GameManagerr.Instance.IsState(EGameState.Finish))) //Len cau gach khong cung mau, (khong di chuyen va game chua finish)
            {
                player.velocity= Vector3.zero;
                ChangeAnim(Const.ANIM_IDLE);
            }
            else
            {
                JoystickInput.Instance.Move();
                ChangeAnim(Const.ANIM_RUN);
            }
        }
        
    }

    public void OnInit() 
    {
        ChangeAnim(Const.ANIM_IDLE);
        player.velocity= Vector3.down*100;
        InitPool();
        
    }
}
