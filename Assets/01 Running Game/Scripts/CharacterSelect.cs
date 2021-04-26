using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    
    [SerializeField] GameObject characterSpriteModel;
    [SerializeField] private Sprite[] characterSprite;
    
    private int indexOfSpriteArray=0;

    // Gets the SpriteModel's SpriteRenderer and sets the new Sprite
    public void UpdateSpriteModel(int increment)
    {
        indexOfSpriteArray += increment;
        indexOfSpriteArray = indexOfSpriteArray !< 0 ? 0 : indexOfSpriteArray;
        indexOfSpriteArray = indexOfSpriteArray !> characterSprite.Length ? indexOfSpriteArray : 0;
        characterSpriteModel.GetComponent<SpriteRenderer>().sprite = characterSprite[indexOfSpriteArray];
    }
}
