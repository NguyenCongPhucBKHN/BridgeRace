using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    [SerializeField] Rigidbody player;

    private void Awake() {
        player.isKinematic=true;
    }
   
    private void Update()
    {
        if(!CheckStair())
        {
            player.velocity= Vector3.zero;
        }
        else
        {
            JoystickInput.Instance.Move();
        }
    }

    private void OnInit()
    {
        
    }
}
