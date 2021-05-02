using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField] GameObject characterSpriteModel;
    [SerializeField] private Sprite[] characterSprite;
    [SerializeField] private RunGameController gameControllerInstance;
    [SerializeField] private AnimationHandling animationHandling;

    private int indexOfSpriteArray = 0;

    // Gets the SpriteModel's SpriteRenderer and sets the new Sprite
    public void UpdateSpriteModel(int increment)
    {
        if (!gameControllerInstance.hasGameStarted && !Input.anyKey)
        {
            indexOfSpriteArray += increment;
            indexOfSpriteArray = indexOfSpriteArray < 0 ? characterSprite.Length - 1 : indexOfSpriteArray;
            indexOfSpriteArray = indexOfSpriteArray >= characterSprite.Length ? 0 : indexOfSpriteArray;
            characterSpriteModel.GetComponent<SpriteRenderer>().sprite = characterSprite[indexOfSpriteArray];
            animationHandling.ChangeSprite(indexOfSpriteArray*2);
        }
    }
}