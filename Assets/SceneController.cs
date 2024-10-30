using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        // Singleton pattern to ensure there's only one SceneController instance
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scene loads
        }
        else
        {
            Destroy(gameObject); // Avoid duplicates
        }
    }

    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there are more scenes in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Load the next level
        }
        else
        {
            Debug.Log("No more levels to load. Game complete!");
        }
    }

    public void ReloadCurrentLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current level
    }
}
