using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// The main reason for this class' name is that I did not want to name it GameController and needed an alternative
public class GameEndDecider : MonoBehaviour
{

    [SerializeField] private PlayerShip player;
    [SerializeField] private Canvas endScreen;
    [SerializeField] private AsteroidGameController asteroidController;

    private Image endScreenBackground;
    private Text endScreenText;

    // Start is called before the first frame update
    void Start()
    {
        endScreenBackground = endScreen.GetComponentInChildren<Image>();
        endScreenText = endScreen.GetComponentInChildren<Text>();

        endScreenBackground.color = new Color(255, 0, 0, 0f);
        endScreenText.color = new Color(255, 255, 255, 0);

        asteroidController = this.gameObject.GetComponent<AsteroidGameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Lose when the Player's hit points hit zero
        if (player.GetHitPoints() == 0)
        {
            Time.timeScale = 0f;
            endScreenBackground.color = new Color(255, 0, 0, 0.5f);
            endScreenText.color = new Color(255, 255, 255, 1);
            endScreenText.text = "You died.\nRestart by pressing R";
        }
        
        // Win if all asteroids are destroyed
        if (!asteroidController.GetActiveAsteroids().Any())
        {
            Time.timeScale = 0f;
            endScreenBackground.color = new Color(0, 255, 0, 0.5f);
            endScreenText.color = new Color(255, 255, 255, 1);
            endScreenText.text = "You've won!\nRestart by pressing R";
        }

        // Restart the Game at any given time
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1f;
            endScreenBackground.color = new Color(255, 0, 0, 0f);
            endScreenText.color = new Color(255, 255, 255, 0);
        }
    }
}
