using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Check if an instance of MusicManager already exists
        if (instance == null)
        {
            // If not, set this to be the instance and make it persist across scenes
            instance = this;
            DontDestroyOnLoad(gameObject); // Don't destroy this object on scene load
        }
        else
        {
            // If an instance already exists, destroy this duplicate
            Destroy(gameObject);
        }
    }
}
