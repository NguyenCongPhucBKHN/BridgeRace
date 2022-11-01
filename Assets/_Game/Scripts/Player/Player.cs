using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [SerializeField] Rigidbody player;
    [SerializeField] Transform tfCenterJoystick;

    private void Awake() {
        player.isKinematic=true;
    }

    private void Start() {
        OnInit();
    }
   
    private void Update()
    {
        

        if(!CheckStair() || Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)<0.1 )
        {
            player.velocity= Vector3.zero;
            ChangeAnim("Idle");
        }
        else
        {
            JoystickInput.Instance.Move();
            ChangeAnim("Run");
        }
    }

    private void OnInit()
    {
        ChangeAnim("Idle");
        player.velocity= Vector3.down*100;
    }
}
