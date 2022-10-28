using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBridgeState : IState<Enemy>
{
    
    public void OnEnter(Enemy t)
    {
        t.MoveToBrigde();
        // t.CheckStair();
    }

    public void OnExecute(Enemy t)
    {

       if(t.numberBrick==0 || t.isNewState)
       {
        t.ChangeState(new CollectState());
       }
       else
       {
        t.MoveToBrigde();
        // t.CheckStair();
       }
    }

    public void OnExit(Enemy t)
    {

    }
}
