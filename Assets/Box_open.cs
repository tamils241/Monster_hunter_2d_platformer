using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_open : MonoBehaviour
{
 public GameObject[] itemPrefabs;      // Array of items to spawn randomly
    public Transform spawnPoint;          // Where the item should spawn
    private Animator Ani;                 // Animator reference

    // Start is called before the first frame update
    void Start()
    {
        Ani = GetComponent<Animator>();   // Get the Animator component
    }

    // Detect player collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Ani.SetTrigger("Box_Open");
            SpawnRandomItem(); // Call the method to spawn a random item
        }
    }

    // Method to spawn a random item from the itemPrefabs array
    private void SpawnRandomItem()
    {
        if (itemPrefabs.Length > 0 && spawnPoint != null)
        {
            // Select a random index from the array
            int randomIndex = Random.Range(0, itemPrefabs.Length);
            
            // Instantiate the randomly selected item at the spawn point
            Instantiate(itemPrefabs[randomIndex], spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Item Prefabs array is empty or Spawn Point is not assigned!");
        }
    }
}