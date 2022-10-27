using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectState : IState<Enemy>
{
    private float numberBirck;
    public void OnEnter(Enemy t)
    {
        numberBirck = Random.Range(3, 6);
        t.CollectBrick();
    }

    public void OnExecute(Enemy t)
    {
        Debug.Log("State collection");
         if(t.numberBrick<numberBirck)
        {
            t.CollectBrick();
        }
        else
        {
            t.ChangeState(new MoveToBridgeState() );
        }

    }

    public void OnExit(Enemy t)
    {

    }
}
