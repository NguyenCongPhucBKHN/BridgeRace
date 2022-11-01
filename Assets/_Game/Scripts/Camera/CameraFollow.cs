using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public float lerpRate;
    // public bool gameOver;
    

    // Start is called before the first frame update
    // void Start()
    // {
    //     gameOver = false;
        
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        if( !GameManagerr.Instance.IsState(EGameState.Finish)  )
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = player.transform.position + offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate*Time.deltaTime);
        transform.position = pos;
    }
    
    public void FollowEndGame(Vector3 position)
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = position + offset;
        transform.position = targetPos;
    }
}
