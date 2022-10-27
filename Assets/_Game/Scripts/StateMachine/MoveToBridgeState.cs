using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBridgeState : IState<Enemy>
{
    
    public void OnEnter(Enemy t)
    {
        t.MoveToBrigde();
        t.CheckStair();
    }

    public void OnExecute(Enemy t)
    {

        Debug.Log("t.numberBrick: "+ t.numberBrick);
        Debug.Log("t.isNewState: "+ t.isNewState);
       if(t.numberBrick==0 || t.isNewState)
       {
        t.ChangeState(new CollectState());
       }
       else
       {
        t.MoveToBrigde();
        t.CheckStair();
       }
    }

    public void OnExit(Enemy t)
    {

    }
}
