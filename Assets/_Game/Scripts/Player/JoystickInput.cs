using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class JoystickInput : Singleton<JoystickInput>
{
     private Rigidbody _rigidbody;
    
    // [SerializeField] public FixedJoystick _joystick;
    [SerializeField] public DynamicJoystick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] Transform tfCenterJoystick;

    public bool isControl => Vector3.Distance(tfCenterJoystick.localPosition, Vector3.zero)>0.1;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    // private void Update()
    // {
    //     _rigidbody.velocity = new Vector3(_joystick.Horizontal *_moveSpeed, _rigidbody.velocity.y, _joystick.Vertical*_moveSpeed);
    //     if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
    //     {
    //        transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    //     }
    //     _rigidbody.AddForce(Vector3.down*10f);
    // }
    private void Awake() {
        _rigidbody = FindObjectOfType<Player>().GetComponent<Rigidbody>();
    }
    public void Move()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal *_moveSpeed, _rigidbody.velocity.y, _joystick.Vertical*_moveSpeed);
        if(_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
           _rigidbody.transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        _rigidbody.AddForce(Vector3.down*10f);
    }
}
