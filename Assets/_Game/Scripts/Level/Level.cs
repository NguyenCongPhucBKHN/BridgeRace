using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject StartPoint;
    private Player player;
    private Rigidbody rbPlayer;
    public bool isWin;
    [SerializeField] Enemy enemyPrefab;
    
    [SerializeField] private FinishPoint finishPoint;

    private List<EColorType> listColor = new List<EColorType>();
    private List<Vector3> listPoint = new List<Vector3>();

    public int numberEnemy;
    private List<Enemy> listEnemy = new List<Enemy>();
    [SerializeField]
    private Stage[] stages;
    void Awake()
    {
        player = FindObjectOfType<Player>();
        rbPlayer = player.gameObject.GetComponent<Rigidbody>();
    }

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
        rbPlayer.isKinematic=false;
        listColor.RemoveAt(index);
        listPoint.RemoveAt(index);
        for(int i =0; i< listColor.Count; i++)
        {
            Enemy enemy = Instantiate(enemyPrefab, listPoint[i], Quaternion.identity);
            listEnemy.Add(enemy);
            enemy.SetColor(listColor[i]);
        }
    }

    public void OnStart()
    {
        foreach(Enemy enemy in listEnemy)
        {
            enemy.OnStart();
        }
        finishPoint.currentLevel = this;
    }








}
