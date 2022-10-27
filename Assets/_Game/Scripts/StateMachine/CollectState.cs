using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : IState<Enemy>
{
    private float numberBirck;
    public void OnEnter(Enemy t)
    {
        t.CollectBrick();
    }

    public void OnExecute(Enemy t)
    {
        Debug.Log("State collection");
         if(!t.haveBrick)
        {
            t.ChangeState(new MoveToBridgeState() );
        }
        else
        {
            t.CollectBrick();
           
        }

    }

    public void OnExit(Enemy t)
    {

    }
}
