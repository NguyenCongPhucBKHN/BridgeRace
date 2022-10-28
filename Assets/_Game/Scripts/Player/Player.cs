using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody player;
    private void Update()
    {
        CheckStair();
        Debug.Log("player isMove: "+ isMove);
        Debug.Log("Player velocity: "+ player.velocity);
        Vector3 velocity = player.velocity;
        velocity.y =0;
        if(!isMove)
        {
           
            player.velocity= velocity;
        }
    }
}
