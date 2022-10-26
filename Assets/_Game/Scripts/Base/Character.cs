using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : ColorObject
{
    // EColorType color;
    [SerializeField] protected Transform brickHolder;
    [SerializeField] protected ChaBrick chaBrick;
    private List<ChaBrick> listBrick = new List<ChaBrick>();
    public Stage currentStage; 

    public void AddBirck()
    {
        ChaBrick brick = Instantiate(chaBrick, brickHolder);
        brick.SetColor(colorType);
        brick.transform.localPosition = Vector3.up * listBrick.Count *0.25f;
        listBrick.Add(brick);
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
}
