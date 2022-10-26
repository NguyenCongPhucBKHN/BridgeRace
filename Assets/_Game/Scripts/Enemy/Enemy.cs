using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    private bool haveBrick;
    public NavMeshAgent agent;
    public Transform newStage;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        CollectBrick();
    }
    public Vector3 GetTargetPostion()
    {
        // Debug.Log(currentStage);
        if(currentStage!= null)
        {
            for (int i =0; i<currentStage.bricks.Count; i++)
            {
                if(currentStage.bricks[i].colorType == colorType)
                {
                    haveBrick =true;
                    return currentStage.bricks[i].transform.position;
                }
            }
        }
        
        haveBrick = false;
        return Vector3.zero;
    }

    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void CollectBrick()
    {
        Vector3 target = GetTargetPostion();
        if(haveBrick)
        {
            SetDestination(target);
        }
        
    }



    
}
