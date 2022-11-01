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
        Debug.Log("camera: "+ cam);
    }
     void OnTriggerEnter(Collider other)
    {
        if(currentLevel!=null)
        {
            cam.FollowEndGame(transform.position);
            Player player = other.GetComponent<Player>();
            Enemy enemy = other.GetComponent<Enemy>();
            if(player != null)
            {
                player.ClearCharBrick();
                player.ChangeAnim("Win");
                currentLevel.isWin = true;
                LevelManager.Instance.OnFinish();
                

            }
            if(enemy!= null)
            {
                enemy.ClearCharBrick();
                enemy.ChangeAnim("Win");
                currentLevel.isWin = false;
                LevelManager.Instance.OnFinish();
            }
        }
        

    }
}
