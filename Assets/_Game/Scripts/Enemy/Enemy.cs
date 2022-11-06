using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    [SerializeField] private float minNumberTarget =4;
    [SerializeField] private float maxNumberTarget = 10;
    [SerializeField] private float moveSpeed =5;
    public NavMeshAgent agent;
    public float numberBrick => listBrick.Count;
    public bool haveBrick;
    public float numberTarget;
    private IState<Enemy> currentState;
    private int randBridge;

    void Start() {
        OnInit();
    }
    private void Update()
    {
        if(GameManagerr.Instance.IsState(EGameState.GamePlay))
        {
            ChangeAnim(Constant.ANIM_RUN);
            if(currentState!= null)
            {
                currentState.OnExecute(this);
            }
            agent.speed = moveSpeed;
        }
        if(GameManagerr.Instance.IsState(EGameState.Finish)  )
        {
            agent.speed = 0;
            
        }
        if(GameManagerr.Instance.IsState(EGameState.Pause))
        {
            agent.speed =0;
            ChangeAnim(Constant.ANIM_IDLE);
        }

    }

    public void OnInit()
    {
        ChangeAnim(Constant.ANIM_IDLE);
        InitPool();

        agent.speed =5;

    }
    public void OnStart()
    {
        if(currentState== null)
        {
            // ChangeAnim(Constant.ANIM_RUN);
            ChangeState(new CollectState());
            
        }
        // ChangeAnim(Constant.ANIM_RUN);
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
                    return currentStage.bricks[i].TF.position;
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
        // position.y = this.TF.position.y;
        // Debug.Log("Distance > 0.1: "+ (Vector3.Distance(position, this.TF.position)>0.1));
        // if(Vector3.Distance(position, this.TF.position)>0.1)
        // {
        //     agent.SetDestination(position);
        // }
        
    }

    //Collection brick
    public void CollectBrick()
    {
        // ChangeAnim(Constant.ANIM_RUN);
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



    //Move to Bridge
    public void MoveToBrigde()
    {
        // ChangeAnim(Constant.ANIM_RUN);
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
