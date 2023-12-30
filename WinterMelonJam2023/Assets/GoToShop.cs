using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class GoToShop : MonoBehaviour
{
    private void OnMouseDown()
    {
        // Load the "Shop" scene when the object is clicked.
        SceneManager.LoadScene("Shop");
    }
}
