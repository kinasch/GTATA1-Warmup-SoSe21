using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.UI;

// The main reason for this class' name is that I did not want to name it GameController and needed an alternative
public class GameEndDecider : MonoBehaviour
{

    [SerializeField] private PlayerShip player;
    [SerializeField] private Canvas endScreen;

    private CanvasGroup endScreenController;
    private Text endScreenText;
    

    // Start is called before the first frame update
    void Start()
    {
        endScreenController = endScreen.GetComponent<CanvasGroup>();
        endScreenText = endScreen.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHitPoints() == 0)
        {
            Time.timeScale = 0f;
            endScreenController.alpha = 0.5f;
            endScreenText.color = new Color(255, 255, 255, 1);
        }

        if (Input.anyKey && Time.timeScale == 0)
        {
            Time.timeScale = 1f;
            player.ResetHitPoints();
            endScreenController.alpha = 0f;
            endScreenText.color = new Color(255, 255, 255, 0);
        }
    }
}
