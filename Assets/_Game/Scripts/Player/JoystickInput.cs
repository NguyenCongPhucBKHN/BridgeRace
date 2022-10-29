using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : Singleton<JoystickInput>
{
    [SerializeField] private Rigidbody _rigidbody;
    
    [SerializeField] public FixedJoystick _joystick;
    [SerializeField] private float _moveSpeed;

    

    public void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal *_moveSpeed, _rigidbody.velocity.y, _joystick.Vertical*_moveSpeed);
        // Debug.Log("_joystick.Vertical: "+ _joystick.Vertical);
        // Debug.Log("_joystick.Horizontal: "+ _joystick.Horizontal);
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
           transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        _rigidbody.AddForce(Vector3.down*10f);
    }
}
