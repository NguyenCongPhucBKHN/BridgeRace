using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Brick birckPrefab;
    [SerializeField] GameObject ground;
    

    [SerializeField] private float minNumberBrick=10;
    [SerializeField] private float maxNumberBrick=15;
    [SerializeField] private GameObject listBrick;
    [SerializeField] public List<Bridge> listBridge;
    [SerializeField] private ColBrick ColBrickPrefab;
    public int numberColor;
    public List<Brick> bricks = new List<Brick>();
    private List<Brick> listColBrick = new List<Brick>();
    private List<Vector3> listPoint;
    private List<Vector3> emptyPoint;
    private float numberBirck;
    
    private float wGround;
    private float hGround;

    void Awake()
   {
        wGround = ground.transform.localScale.x;
        hGround = ground.transform.localScale.z;
        listPoint = new List<Vector3>();
        emptyPoint = new List<Vector3>();
   }
    public void OnInit()
    {
        numberBirck = Random.Range(minNumberBrick, maxNumberBrick);
        emptyPoint = GenListPostion();
        listPoint = GenListPostion();
    }

    List<Vector3> GenListPostion()
    {
        List<Vector3> genList = new List<Vector3>();
        Vector3 position;
        for(int i =0; i< numberBirck-1; i++)
        {
            for (int j =0; j<numberBirck -1; j++)
            {
                position.x = ground.transform.position.x -wGround/2+ (wGround/numberBirck)*(i+1);
                position.z = ground.transform.position.z -hGround/2 + (hGround/numberBirck)*(j+1);
                position.y = listBrick.transform.position.y;
                genList.Add(position);
                
            }
        }
        return genList;

    }

    public void SpawnAllBrick(int numberEnemy)
    { 
        foreach(Vector3 position in listPoint)
        {
            int i = Random.Range(0, numberEnemy+1);
            Brick brick = Instantiate(birckPrefab, position, listBrick.transform.rotation, listBrick.transform);
            brick.stage= this;
            brick.SetColor((EColorType) i);
            bricks.Add(brick);
        } 
        emptyPoint.Clear();
    }

    public void SpawnOneBrick(EColorType eColorType)
    {
        if(emptyPoint.Count>0)
        {
            int id = Random.Range(0, emptyPoint.Count);
            Vector3 position = emptyPoint[id];
            Brick brick = Instantiate(birckPrefab, position, listBrick.transform.rotation, listBrick.transform);
            brick.stage= this;
            brick.SetColor(eColorType);
            bricks.Add(brick);
            emptyPoint.Remove(brick.transform.position);
        }
    }

    public void SpawByCharacter(Character character)
    {
        if(emptyPoint.Count>0)
        {
            numberBirck = Random.Range(minNumberBrick, maxNumberBrick);
            for(int i =0; i < numberBirck; i++)
            { 
                SpawnOneBrick(character.colorType);
            }
        }
    }

    public void SpawnBrickCollider(Character character)
    {
        if(character!= null)
        {
            for(int i =0; i< character.listBrick.Count; i++)
            {
                character.RemoveBrick();
                Vector3 position = character.transform.position;
                position.y = 4f;
                ColBrick colBrick = Instantiate(ColBrickPrefab, position, Quaternion.identity);
                listColBrick.Add(colBrick);
                colBrick.stage = this;
            }
        }
        
    }
    
    public void OnDespawn()
    {
        foreach(Brick  brick in bricks)
        {
            Destroy(brick.gameObject);
        }
        foreach(Brick brick in listColBrick)
        {
            Destroy(brick.gameObject);
        }
        
        bricks.Clear();
        listColBrick.Clear();
        emptyPoint.Clear();
    }
    
    public void OnDespawn(Brick brick)
    {
        bricks.Remove(brick);
        emptyPoint.Add(brick.transform.position);
        Destroy(brick.gameObject);
    }  

    public void OnDespawnColBrick(Brick brick)
    {
        bricks.Remove(brick);
        listColBrick.Remove(brick);
        Destroy(brick.gameObject);

    }
    
    


    

}
