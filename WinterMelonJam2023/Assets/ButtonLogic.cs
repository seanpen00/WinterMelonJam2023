using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line

public class ButtonLogic : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoBack()
    {
        SceneManager.LoadScene("LevelOne");
    }
}
