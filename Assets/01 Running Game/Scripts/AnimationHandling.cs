using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class AnimationHandling : MonoBehaviour
{
    [SerializeField] private Sprite[] characterSpriteCollection;
    [SerializeField] private Sprite[] characterJumpCollection;
    [SerializeField] private GameObject characterSpriteModel;
    [SerializeField] private RunCharacterController characterController;

    private SpriteRenderer spriteRenderer;
    private float timer, framerate = 0.35f;
    private int currentFrame;
    private Sprite[] currentCharacterSprite = new Sprite[2];
    private Sprite[] currentJumpSprite = new Sprite[2];

    private double lastCharacterY;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = characterSpriteModel.GetComponent<SpriteRenderer>();
        ChangeSprite(0);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= framerate && characterController.GetCanJump())
        {
            timer -= framerate;
            currentFrame = (currentFrame + 1) % currentCharacterSprite.Length;
            spriteRenderer.sprite = currentCharacterSprite[currentFrame];
        }

        if (!characterController.GetCanJump())
        {
            var currentSpriteForJump = currentJumpSprite[0];
            if (lastCharacterY > characterController.GetCharacterY())
            {
                currentSpriteForJump = currentJumpSprite[1];
            }

            spriteRenderer.sprite = currentSpriteForJump;

            lastCharacterY = characterController.GetCharacterY();
        }
    }

    public void ChangeSprite(int pos)
    {
        currentCharacterSprite[0] = characterSpriteCollection[pos];
        currentCharacterSprite[1] = characterSpriteCollection[pos + 1];

        currentJumpSprite[0] = characterJumpCollection[pos];
        currentJumpSprite[1] = characterJumpCollection[pos + 1];
    }
}