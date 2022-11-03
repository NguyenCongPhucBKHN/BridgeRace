using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [SerializeField] private Brick birckPrefab;
    [SerializeField] GameObject ground;
    [SerializeField] public Transform TF;
    

    [SerializeField] private float minNumberBrick=10;
    [SerializeField] private float maxNumberBrick=15;
    [SerializeField] private GameObject listBrick;
    [SerializeField] public List<Bridge> listBridge;
    [SerializeField] private Brick ColBrickPrefab;
    [SerializeField] public Transform groundTF;
    [SerializeField] public Transform listBrickTF;
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
        groundTF = ground.transform;
        wGround = groundTF.localScale.x;
        hGround = groundTF.localScale.z;
        listPoint = new List<Vector3>();
        emptyPoint = new List<Vector3>();
        TF = gameObject.transform;
        listBrickTF = listBrick.transform;
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
                position.x = groundTF.position.x -wGround/2+ (wGround/numberBirck)*(i+1);
                position.z = groundTF.position.z -hGround/2 + (hGround/numberBirck)*(j+1);
                position.y = listBrickTF.position.y;
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
            Brick brick= SimplePool.Spawn<Brick>(PoolType.birckPrefab, position, listBrickTF.rotation);
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
            Brick brick= SimplePool.Spawn<Brick>(PoolType.birckPrefab, position, listBrickTF.rotation);
            brick.stage= this;
            brick.SetColor(eColorType);
            bricks.Add(brick);
            emptyPoint.Remove(brick.TF.position);
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
                Vector3 position = character.TF.position;
                position.y = TF.position.y + 1f;
                ColBrick colBrick = SimplePool.Spawn<ColBrick>(PoolType.ColBrick, position, Quaternion.identity);
                // ColBrick colBrick = Instantiate(ColBrickPrefab, position, Quaternion.identity);
                listColBrick.Add(colBrick);
                colBrick.stage = this;
            }
        }
        
    }
    
    public void OnDespawn()
    {
        foreach(Brick  brick in bricks)
        {
            
            brick.OnDespawn();
        }
        foreach(Brick brick in listColBrick)
        {
            brick.OnDespawn();
            // Destroy(brick.gameObject);
        }

        bricks.Clear();
        listColBrick.Clear();
        emptyPoint.Clear();
    }
    
    public void OnDespawn(Brick brick)
    {
        bricks.Remove(brick);
        emptyPoint.Add(brick.TF.position);
        brick.OnDespawn();

        // Destroy(brick.gameObject);
        
    }  

    public void OnDespawnColBrick(Brick brick)
    {
        // bricks.Remove(brick);
        listColBrick.Remove(brick);
        brick.OnDespawn();
        // Destroy(brick.gameObject);

    }
    
    


    

}
