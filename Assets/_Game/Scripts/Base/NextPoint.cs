using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPoint : MonoBehaviour
{
    [SerializeField] private Transform nextPoint;
    [SerializeField] private Character character;
    
    int stairLayer;
    void Start()
    {
        stairLayer = LayerMask.GetMask("LayerStair");

    }
    void Update()
    {
       
        MoveInBrigde();
        Debug.Log("isMove: "+ character.isMove);
        
    }

    bool CheckStair()
    {
        character.isMove = true;
        RaycastHit hit;
        Debug.DrawLine(nextPoint.position, nextPoint.position + Vector3.down * 10f);
        if(Physics.Raycast(nextPoint.position, Vector3.down,out hit, 10f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            Debug.Log("stair color: "+ stair.colorType);
            if(character.listBrick.Count>0 &&(stair.colorType != character.colorType))
            {
                character.RemoveBrick();
                stair.SetColor(character.colorType);
                character.currentStage.SpawnOneBrick(character.colorType);
            }
            else
            {
                character.isMove= false;
            }

           
        }
        return character.isMove;

    }

    void MoveInBrigde()
    {
        character.isMove = true;
        RaycastHit hit;
        if(Physics.Raycast(nextPoint.position, Vector3.down,out hit, 10f, stairLayer))
        {
            Stair stair = hit.collider.GetComponent<Stair>();
            if(character.listBrick.Count>0 &&(stair.colorType != character.colorType))
            {
                character.RemoveBrick();
                stair.SetColor(character.colorType);
                character.currentStage.SpawnOneBrick(character.colorType);
            }
            else
            {
                character.isMove= false;
            } 
        }
    }
}
