using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float moveSpeed;

    private void FixedUpdate() {
        
        rigidbody.velocity = new Vector3(joystick.Horizontal *moveSpeed, rigidbody.velocity.y, joystick.Vertical*moveSpeed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
           rigidbody.transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
        }
        rigidbody.AddForce(Vector3.down*5);
    }
}
