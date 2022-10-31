using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    // EColorType color;
    [SerializeField] protected Transform brickHolder;
    [SerializeField] protected ChaBrick chaBrick;
    [SerializeField] private Transform nextPoint;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private ColBrick ColBrickPrefab;
    public bool isMove= true;
    public bool isGround = true;
    public List<ChaBrick> listBrick = new List<ChaBrick>();
    public Stage currentStage; 
    public bool isNewState= false;
    public bool isForward => JoystickInput.Instance._joystick.Vertical > 0;
    
    
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    

    public void AddBirck()
    {
        ChaBrick brick = Instantiate(chaBrick, brickHolder);
        brick.SetColor(colorType);
        brick.transform.localPosition = Vector3.up * listBrick.Count *0.1f;
        listBrick.Add(brick);
    }

    public void RemoveBrick()
    {
        if(listBrick.Count>0)
        {
            ChaBrick brick= listBrick[listBrick.Count-1];
            listBrick.RemoveAt(listBrick.Count-1);
            Destroy(brick.gameObject);
        }
       
    }

    
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<Brick>()!=null)
        {   
            isGround= true;
            Brick gbrick = other.GetComponent<Brick>();
            if(gbrick.colorType ==colorType )
            {
                AddBirck();
                gbrick.OnDespawn();
                // currentStage = gbrick.stage;
            }

            if( gbrick.colorType == EColorType.Default)
            {
                AddBirck();
                gbrick.OnDespawnColBrick();
            }
        }
        if(other.GetComponent<Character>()!=null && isGround )
        {
            Character character = other.GetComponent<Character>().listBrick.Count > this.listBrick.Count ? this: other.GetComponent<Character>() ;
            if(currentStage!= null)
            {
                currentStage.SpawnBrickCollider(character);
                
            }
            
        }
    }

    void SpawnBrickCollider(Character character)
    {
        if(character!= null)
        {
            for(int i =0; i< character.listBrick.Count; i++)
            {
                character.RemoveBrick();
                Vector3 position = character.transform.position;
                position.y = currentStage.gameObject.transform.position.y +5f;
                position.x = position.x + Random.Range(-0.5f, 0.5f);
                position.z = position.z + Random.Range(-0.5f, 0.5f);
                ColBrick colBrick = Instantiate(ColBrickPrefab, position, Quaternion.identity);
                colBrick.stage = currentStage;
                
                // colBrick.rd.Sleep();
                // colBrick.collider.isTrigger= true;


            }
        }
        
    }

    // void ClearBrick()
    // {
    //     for(int i =0; i<listBrick.Count; i++)
    //     {
    //         RemoveBrick();
    //     }
    //     listBrick.Clear();
    // }

  public bool CheckStair()
    {
        isMove= true;
        RaycastHit hit;
        if(Physics.Raycast(nextPoint.position, Vector3.down,out hit, 10f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            if(stair!= null)
            {
                isGround = false;
            }
            if(listBrick.Count>0 && (stair.colorType != colorType))
            {
                RemoveBrick();
                Debug.Log("colorType: "+ colorType);
                stair.SetColor(colorType);
                currentStage.SpawnOneBrick(colorType);
            }
            if( isForward && (stair.colorType != colorType))
            {
                isMove= false;
            }           
        }
        return isMove;

    }  
}
