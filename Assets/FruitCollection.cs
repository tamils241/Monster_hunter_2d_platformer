using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FruitCollection : MonoBehaviour
{
    public TMP_Text Red_text;
    public TMP_Text Yellow_text;
    public TMP_Text Green_text;
    public TMP_Text Pink_text;

    private int Red_increas = 0;
    private int Yellow_increas = 0;
    private int Green_increas = 0;
    private int Pink_increas = 0;

    public int requiredFruitsToProceed = 10;  // Set how many fruits to collect to progress to the next level
    public AudioSource Audio;
    public AudioClip fruits_Sound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            Destroy(other.gameObject);
            Red_increas++;
            Red_text.text = "x" + Red_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Yellow"))
        {
            Destroy(other.gameObject);
            Yellow_increas++;
            Yellow_text.text = "x" + Yellow_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Green"))
        {
            Destroy(other.gameObject);
            Green_increas++;
            Green_text.text = "x" + Green_increas;
            Audio.PlayOneShot(fruits_Sound);
        }
        if (other.gameObject.CompareTag("Pink"))
        {
            Destroy(other.gameObject);
            Pink_increas++;
            Pink_text.text = "x" + Pink_increas;
            Audio.PlayOneShot(fruits_Sound);
        }

        // Check if the required number of fruits has been collected
        CheckLevelProgression();
    }

    void CheckLevelProgression()
    {
        // Calculate the total number of fruits collected
        int totalFruits = Red_increas + Yellow_increas + Green_increas + Pink_increas;

        // Check if total fruits collected is greater or equal to required number
        if (totalFruits >= requiredFruitsToProceed)
        {
            // Load the next level based on the current active level
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Assuming Level 1 is index 1, Level 2 is index 2, etc.
        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1); // Load the next scene in the build index
    }
}
