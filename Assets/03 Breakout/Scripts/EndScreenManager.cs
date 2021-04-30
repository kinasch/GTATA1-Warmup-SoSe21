using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreenManager : MonoBehaviour
{

    [SerializeField] private Image endScreenBackground;
    [SerializeField] private Text endScreenText;
    [SerializeField] private GameObject endScreenButtons;
    [SerializeField] private Transform bricks;

    // Start is called before the first frame update
    void Start()
    {
        endScreenButtons.SetActive(false);
        endScreenBackground.color = new Color(255, 0, 0, 0f);
        endScreenText.color = new Color(255, 255, 255, 0);
        endScreenText.transform.localScale = new Vector3(2, 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        // Win if all asteroids are destroyed
        if (CountChildren(bricks) == 0)
        {
            EndScreenWin();
        }

        // TODO: Buttons with Levelselect
    }
    
    int CountChildren(Transform a)
    {
        int childCount = 0;
        foreach (Transform b in a)
        {
            childCount ++;
        }
        return childCount;
    }
    
    public void EndScreenWin()
    {
        Time.timeScale = 0f;
        endScreenBackground.color = new Color(0, 255, 0, 0.5f);
        endScreenText.color = new Color(255, 255, 255, 1);
        endScreenText.text = "You've won!";
        endScreenButtons.SetActive(true);
    }

    public void EndScreenLose()
    {
        Time.timeScale = 0f;
        endScreenBackground.color = new Color(255, 0, 0, 0.5f);
        endScreenText.color = new Color(255, 255, 255, 1);
        endScreenText.text = "You've lost!";
        endScreenButtons.SetActive(true);
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadOtherLevel(string otherLevelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(otherLevelName);
    }
}
