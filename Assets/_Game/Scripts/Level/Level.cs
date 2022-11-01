using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject StartPoint;
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] private FinishPoint finishPoint;
    [SerializeField] private Stage[] stages;
    private Player player;
    private Rigidbody rbPlayer;
    public bool isWin;
    private CameraFollow cam;
    

    private List<EColorType> listColor = new List<EColorType>();
    private List<Vector3> listPoint = new List<Vector3>();

    public int numberEnemy;
    private List<Enemy> listEnemy = new List<Enemy>();
    
    void Awake()
    { 
        player = FindObjectOfType<Player>();
        rbPlayer = player.gameObject.GetComponent<Rigidbody>();
        cam = FindObjectOfType<CameraFollow>();
    }

    //Ham khoi tao cac Object trong 1 level: Stages, GenBrick, OnInit Player
    public void OnInit()
    {
        foreach( Stage stage in stages)
        {
            stage.OnInit();
        }
        stages[0].SpawnAllBrick(numberEnemy);
        GetListColor();
        GenListPoint();
        GenCharacter();
        isWin= false;
    }

    public void OnStart()
    {
        foreach(Enemy enemy in listEnemy)
        {
            enemy.OnStart();
        }
        player.currentLevel = this;
        finishPoint.currentLevel = this;
    }

    public void Despawn()
    {
        foreach(Stage stage in stages)
        {
            stage.OnDespawn();
        }
        foreach(Enemy enemy in listEnemy)
        {
            Destroy(enemy.gameObject);
        }
        player.ClearCharBrick();
        listColor.Clear();
        listPoint.Clear();
    }
    void GetListColor()
    {
        for(int i =0; i< numberEnemy+1; i++)
        {
            listColor.Add((EColorType) i);
        }
    }

    void GenListPoint()
    {
        float wGround = StartPoint.transform.localScale.x;
        Vector3 position= StartPoint.transform.position;
        for(int i =0; i< numberEnemy+1; i++)
        {
            position.x = StartPoint.transform.position.x -wGround/2+ (wGround/numberEnemy)*(i)+2f;
            position.y = StartPoint.transform.position.y +1.5f;
            listPoint.Add(position);
        }
    }

    void GenCharacter()
    {
        int index = Random.Range(0, numberEnemy+1);
        player.SetColor(listColor[index]);
        player.transform.position = listPoint[index];
        player.OnInit();
        rbPlayer.isKinematic=false;
        listColor.RemoveAt(index);
        listPoint.RemoveAt(index);
        for(int i =0; i< listColor.Count; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, listPoint[i], Quaternion.identity);
            enemy.OnInit();
            listEnemy.Add(enemy);
            enemy.SetColor(listColor[i]);
        }
    }

    
}
