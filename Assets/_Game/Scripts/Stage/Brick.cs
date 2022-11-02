using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : ColorObject
{
    // public Transform tf;
    public Stage stage;
    public void OnSpawn()
    {

    }
    public void Remove()
    {
        // base.OnDespawn();
        stage.OnDespawn(this);
    }

    public void OnDespawnColBrick()
    {
        stage.OnDespawnColBrick(this);
    }
}
