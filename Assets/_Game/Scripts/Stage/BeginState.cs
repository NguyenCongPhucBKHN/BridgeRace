using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginState : MonoBehaviour
{
    [SerializeField] private Stage stage;
    private List<Character> listChar = new List<Character>();

    void OnTriggerEnter(Collider other)
    {
        Character character = Cache.GetCharacter(other);
        if(character!= null && !listChar.Contains(character))
        {
            listChar.Add(character);
            character.currentStage = stage;
            stage.numberColor = listChar.Count;
            stage.SpawByCharacter(character);
            character.isNewState = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Character character = Cache.GetCharacter(other);
        if(character!= null)
        {
        character.isNewState = false;
    }
    }
}
