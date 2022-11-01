using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    [SerializeField] private float minNumberTarget =4;
    [SerializeField] private float maxNumberTarget = 10;
    public NavMeshAgent agent;
    public float numberBrick => listBrick.Count;
    public bool haveBrick;
    public float numberTarget;
    private IState<Enemy> currentState;
    private int randBridge;


    private void Update()
    {
        if(GameManagerr.Instance.IsState(EGameState.GamePlay))
        {
            ChangeAnim(Const.ANIM_RUN);
            if(currentState!= null)
            {
                currentState.OnExecute(this);
            }
        }
        if(GameManagerr.Instance.IsState(EGameState.Finish))
        {
            agent.speed =0;
            
        }

    }

    public void OnInit()
    {
        ChangeAnim(Const.ANIM_IDLE);
    }
    public void OnStart()
    {
        if(currentState== null)
        {
            ChangeState(new CollectState());
        }
    }

    //Get target position
    public Vector3 GetTargetPostion()
    {
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
    
    //Move to target position
    public void SetDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    //Collection brick
    public void CollectBrick()
    {
        // ChangeAnim(Const.ANIM_RUN);
        numberTarget = Random.Range(minNumberTarget, maxNumberTarget);
        if( numberBrick < numberTarget)
        {
            Vector3 target = GetTargetPostion();
            if(haveBrick)
            {
                SetDestination(target);
            }
            else
            { 
                ChangeState(new MoveToBridgeState());
            }
        }
        else
        {
            ChangeState(new MoveToBridgeState());
        }  
    }

    // public void MoveToBrigde()
    // {
    //     ChangeAnim(Const.ANIM_RUN);
    //     if(currentStage!=null)
    //     {
    //         randBridge = Random.Range(0, currentStage.listBridge.Count);
    //     }
    //     Vector3 nextNewStage = currentStage.listBridge[randBridge].nextNewStage.position;
    //     SetDestination(nextNewStage);
    //     CheckStair();
    // }

    //Move to Bridge
    public void MoveToBrigde()
    {
        // ChangeAnim(Const.ANIM_RUN);
        if(currentStage!=null && CheckStair())
        {
            randBridge = Random.Range(0, currentStage.listBridge.Count);
            Vector3 nextNewStage = currentStage.listBridge[randBridge].nextNewStage.position;
            SetDestination(nextNewStage);
        }
        else
        {
            ChangeState(new CollectState());
        } 
    }

    //Change State
    public void ChangeState(IState<Enemy> state) {
        {
            if(currentState!= null)
            {
                currentState.OnExit(this);
            }
            currentState = state;
            if(currentStage!= null)
            {
                currentState.OnEnter(this);
            }
        }
    }
}
