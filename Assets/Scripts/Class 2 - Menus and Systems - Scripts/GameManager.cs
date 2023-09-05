using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // The singleton variable, accessible at the script level without a direct object reference (static)
    public static GameManager instance;

    private void Awake()
    {
        // If the singleton value is empty, assign this script as the singleton
        //  otherwise, destroy this as it was created in duplicate fashion.
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // Protect this object from being destroyed in the hierarchy when scenes change
        //  - This ensures that the object it is attached to is persistently available across scenes
        //    unless it is otherwise destroyed
        DontDestroyOnLoad(gameObject);
    }
}

