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

    // Set all the end screen components' alpha to 0, making them see-through.
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
        // Win if all bricks are destroyed.
        if (CountChildren(bricks) == 0)
        {
            EndScreenWin();
        }
    }

    /// <param name="a">Transform object the amount of children are to be determined of</param>
    /// <returns>Amount of children of the given Transform</returns>
    int CountChildren(Transform a)
    {
        int childCount = 0;
        foreach (Transform b in a)
        {
            childCount++;
        }

        return childCount;
    }

    /// <summary>
    /// If the Game is won, activate all the end screen components:
    /// Background in green, text to "You've won!".
    /// </summary>
    public void EndScreenWin()
    {
        Time.timeScale = 0f;
        endScreenBackground.color = new Color(0, 255, 0, 0.5f);
        endScreenText.color = new Color(255, 255, 255, 1);
        endScreenText.text = "You've won!";
        endScreenButtons.SetActive(true);
    }

    /// <summary>
    /// If the Game is lost, activate all the end screen components:
    /// Background in red, text to "You've lost!".
    /// </summary>
    public void EndScreenLose()
    {
        Time.timeScale = 0f;
        endScreenBackground.color = new Color(255, 0, 0, 0.5f);
        endScreenText.color = new Color(255, 255, 255, 1);
        endScreenText.text = "You've lost!";
        endScreenButtons.SetActive(true);
    }

    /// <summary>
    /// Restart the current Scene.
    /// Requires the Scene to be in the build settings.
    /// </summary>
    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Load another Scene.
    /// Requires the Scene to be in the build settings.
    /// </summary>
    /// <param name="otherLevelName">Name of the other level.</param>
    public void LoadOtherLevel(string otherLevelName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(otherLevelName);
    }
}