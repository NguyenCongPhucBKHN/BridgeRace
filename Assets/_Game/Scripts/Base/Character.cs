using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    // EColorType color;
    [SerializeField] protected Transform brickHolder;
    [SerializeField] protected ChaBrick chaBrick;
    [SerializeField] private Transform nextPoint;
    public bool isMove= true;
    public List<ChaBrick> listBrick = new List<ChaBrick>();
    public Stage currentStage; 
    public bool isNewState= false;
    // private int stairLayer;
    [SerializeField] private LayerMask stairLayer;
    
    

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
        if(other.CompareTag("brick"))
        {   
            Brick gbrick = other.GetComponent<Brick>();
            if(gbrick.colorType ==colorType)
            {

                AddBirck();
                gbrick.OnDespawn();
            }
        }
    }

  public bool CheckStair()
    {
        RaycastHit hit;
        Debug.DrawLine(nextPoint.position, nextPoint.position + Vector3.down * 10f);

        Debug.Log("bool: "+ Physics.Raycast(nextPoint.position, Vector3.down,out hit, 10f, stairLayer));
        if(Physics.Raycast(nextPoint.position, Vector3.down,out hit, 10f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            Debug.Log("stair color: "+ stair.colorType);
            if(listBrick.Count>0 && (stair.colorType != colorType))
            {
                RemoveBrick();
                stair.SetColor(colorType);
                currentStage.SpawnOneBrick(colorType);
            }
            else
            {
                isMove= false;
            }

           
        }
        return isMove;

    }  
}
