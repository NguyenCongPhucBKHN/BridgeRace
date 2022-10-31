using UnityEngine;
using UnityEngine.AI;
public class Enemy : Character
{
    
    public NavMeshAgent agent;

    public float numberBrick => listBrick.Count;
   public bool haveBrick;
   public float numberTarget;
    private IState<Enemy> currentState;
    private int randBridge;

   void Start()
   {
    // if(currentState== null)
    // {
    //     ChangeState(new CollectState());
        
    // }
    // if(currentStage!=null)
    // {
    //     randBridge = Random.Range(0, currentStage.listBridge.Count);
    // }

    // OnStart();
    
   }
    private void Update()
    {
        if(GameManagerr.Instance.currentState == EGameState.GamePlay)
        {
            if(currentStage!= null)
            {
                currentState.OnExecute(this);
            }
        }
 
    }
    public Vector3 GetTargetPostion()
    {
        if(currentStage!= null)
        {
            for (int i =0; i<currentStage.bricks.Count; i++)
            {
                if(currentStage.bricks[i].colorType == colorType ||currentStage.bricks[i].colorType == EColorType.Default )
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
        numberTarget = Random.Range(7, 15);
        if(numberBrick<numberTarget)
        {
            Vector3 target = GetTargetPostion();
            if(haveBrick)
            {
                SetDestination(target);
            }
        }
        else
        {
            ChangeState(new MoveToBridgeState());
        }
        
        
        
    }

    public void MoveToBrigde()
    {
       
        Vector3 nextNewStage = currentStage.listBridge[randBridge].nextNewStage.position;
        SetDestination(nextNewStage);
        CheckStair();
    }

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

    public void OnStart()
    {
        if(currentState== null)
    {
        ChangeState(new CollectState());
        
    }
    if(currentStage!=null)
    {
        randBridge = Random.Range(0, currentStage.listBridge.Count);
    }
    }

    
}
