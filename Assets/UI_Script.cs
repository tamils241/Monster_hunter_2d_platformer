using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Script : MonoBehaviour
{
   public Button[] levelButtons; // Array of level buttons in the UI
   public GameObject Volume_Panel;
   public GameObject Menu_Panel;
    // Start is called before the first frame update

   private void Awake()
   {
    // Get the highest unlocked level from PlayerPrefs (default to 1, meaning only level 1 is unlocked initially)
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Loop through all level buttons and lock/unlock based on the player's progress
        for (int i = 0; i < levelButtons.Length; i++)
        {
            // If the level number (i + 1) is less than or equal to unlockedLevel, make the button interactable (unlocked)
            if (i + 1 <= unlockedLevel)
            {
                levelButtons[i].interactable = true; // Unlock the button
            }
            else
            {
                levelButtons[i].interactable = false; // Lock the button
            }
        }
    }


    public void Back_Button()
    {
         if (Volume_Panel != null) // Check if Volume_Panel is assigned
        {
            Volume_Panel.SetActive(false); // Hide the panel
        }
        else
        {
            Debug.LogWarning("Volume_Panel is not assigned in the Inspector.");
        }
    }

    // scene load function
    public void Level_Button(int sceneID)
    {
         if (sceneID <= PlayerPrefs.GetInt("UnlockedLevel", 1))
        {
           SceneManager.LoadScene(sceneID);
        }
    }
     
}

