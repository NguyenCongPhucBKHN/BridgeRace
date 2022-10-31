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

            }

            if( gbrick.colorType == EColorType.Default && Mathf.Abs(gbrick.gameObject.transform.position.y - currentStage.gameObject.transform.position.y)<0.2)
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
