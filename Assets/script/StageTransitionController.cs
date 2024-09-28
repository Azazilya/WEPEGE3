using UnityEngine;
using UnityEngine.SceneManagement; // For loading new scenes

public class StageTransitionController : MonoBehaviour
{
    public string nextStageName; // The name of the next stage/scene to load
    public GameObject requiredItem; // The item that must be obtained to activate the transition
    public GameObject player; // Reference to the player
    public float interactDistance = 2.0f; // Max distance to interact with the transition object

    private bool itemObtained = false; // Tracks if the required item has been collected

    private void Update()
    {
        // Check if the item has been collected
        if (requiredItem == null)
        {
            itemObtained = true;
        }

        // Check if the player is close enough to the transition object and presses the "E" key
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
            TryTransition();
        }
    }

    private void TryTransition()
    {
        if (itemObtained)
        {
            // Load the next stage if the item has been collected
            SceneManager.LoadScene(nextStageName);
        }
        else
        {
            Debug.Log("You need to collect the required item before moving to the next stage!");
        }
    }
}
