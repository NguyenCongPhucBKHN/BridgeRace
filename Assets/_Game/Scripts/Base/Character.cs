using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    [SerializeField] protected Transform brickHolder;
    [SerializeField] protected ChaBrick chaBrick;
    [SerializeField] private Transform nextPoint;
    [SerializeField] private LayerMask stairLayer;
    [SerializeField] private ColBrick ColBrickPrefab;
    [SerializeField] private Animator anim;
    private string currentAnimName;
    public bool isMove= true;
    public bool isGround = true;
    public List<ChaBrick> listBrick = new List<ChaBrick>();
    public Stage currentStage; 
    public Level currentLevel;

    public bool isNewState= false;
    public bool isForward => JoystickInput.Instance._joystick.Vertical > 0;

    //Trigger with brick to add brick; with character to remove brick
    private void OnTriggerEnter(Collider other) {
        Brick gbrick = other.GetComponent<Brick>();
        Character character = Cache.GetCharacter(other);
        if(gbrick!=null)
        {   
            isGround= true;
            if(gbrick.colorType ==colorType )
            {
                AddBirck();
                gbrick.OnDespawn();
            }
            if(currentStage!=null)
            {
                if( gbrick.colorType == EColorType.Default && Mathf.Abs(gbrick.gameObject.transform.position.y - currentStage.gameObject.transform.position.y)<0.2)
                {
                    AddBirck();
                    gbrick.OnDespawnColBrick();
                }

            } 
        }
        if(character!=null && isGround )
        {
            Character scharacter = character.listBrick.Count > this.listBrick.Count ? this: character ;
            if(currentStage!= null)
            {
                currentStage.SpawnBrickCollider(scharacter);   
            }
        }
    }
    
    //Add brick into character
    public void AddBirck()
    {
        ChaBrick brick = Instantiate(chaBrick, brickHolder);
        brick.SetColor(colorType);
        brick.transform.localPosition = Vector3.up * listBrick.Count *0.1f;
        listBrick.Add(brick);
    }

    //Remove brick from character
    public void RemoveBrick()
    {
        if(listBrick.Count>0)
        {
            ChaBrick brick= listBrick[listBrick.Count-1];
            listBrick.RemoveAt(listBrick.Count-1);
            if(brick != null)
            {
                Destroy(brick.gameObject);
            }
            
        }
    }

    //Check in bridge
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
    
    

    //Clear all brick in character
    public void ClearCharBrick()
    {
        foreach(ChaBrick brick in listBrick)
        {
            if(brick != null)
            {
                Destroy(brick.gameObject);
            }
            
        }
    }

    //Change Anim
    public void ChangeAnim(string animName)
    {
        if(currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }   
}
