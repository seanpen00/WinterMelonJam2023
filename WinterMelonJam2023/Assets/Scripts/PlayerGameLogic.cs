using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerGameLogic : MonoBehaviour
{
    // Make sure there's only one instance of this script
    private static PlayerGameLogic instance;

    [SerializeField] TextMeshProUGUI text;
    int JUNK_COUNTER = 0;

    private void Awake()
    {
        // Check if an instance already exists
        if (instance == null)
        {
            // If not, set this instance as the singleton
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist this game object between scenes
        }
        else
        {
            // If an instance already exists, destroy this one
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // You can initialize any other variables or settings here
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceJunk"))
        {
            JUNK_COUNTER += 1;
            Destroy(collision.gameObject);
            text.text = "Junk Counter: " + JUNK_COUNTER;
        }
    }
}
