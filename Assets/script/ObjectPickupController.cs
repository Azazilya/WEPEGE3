using UnityEngine;
using UnityEngine.UI; // For UI elements
using System.Collections; // For using Coroutines

public class ObjectPickupController : MonoBehaviour
{
    public GameObject uiElement;   // Assign your UI element in the inspector
    public float displayTime = 2.0f; // Time the UI will be enabled (in seconds)
    public Transform player; // Player reference
    public float pickupDistance = 2.0f; // Max distance to pick up the object
    public GameObject objectToDisappear; // The object (e.g., a cube) that will disappear after the UI

    private bool isNearObject = false; // Check if the player is near the object

    private void Update()
    {
        // Calculate distance between player and object
        float distance = Vector3.Distance(player.position, transform.position);

        // Check if the player is within range
        if (distance <= pickupDistance)
        {
            isNearObject = true;

            // If the player presses the pickup button (e.g., "E")
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(DisplayPickupUI());
            }
        }
        else
        {
            isNearObject = false;
        }
    }

    // Coroutine to display UI for a set amount of time and destroy the object afterward
    private IEnumerator DisplayPickupUI()
    {
        uiElement.SetActive(true); // Enable the UI
        yield return new WaitForSeconds(displayTime); // Wait for 'displayTime' seconds
        uiElement.SetActive(false); // Disable the UI

        // Make the object disappear (destroy it)
        if (objectToDisappear != null)
        {
            Destroy(objectToDisappear); // Destroy the specified object
        }
    }
}
