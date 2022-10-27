using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToBridgeState : IState<Enemy>
{
    
    public void OnEnter(Enemy t)
    {
        t.MoveToBrigde();
    }

    public void OnExecute(Enemy t)
    {
       if(t.numberBrick==0||t.isNewState==true)
       {
        t.ChangeState(new CollectState());
       }
    }

    public void OnExit(Enemy t)
    {

    }
}
