using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Point : MonoBehaviour
{
 
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger level completion and load the next level
        SceneController.instance.NextLevel(); 
        
        // Unlock the next level
        UnlockNextLevel();
    }

    // This method unlocks the next level
    void UnlockNextLevel()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // Get the highest unlocked level, default to level 1
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // If the current level is farther than what the player has reached, update it
        if (currentBuildIndex == unlockedLevel)
        {
            // Save the next unlocked level
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);

            // Save PlayerPrefs to store the new progress
            PlayerPrefs.Save();
        }
    }
}
