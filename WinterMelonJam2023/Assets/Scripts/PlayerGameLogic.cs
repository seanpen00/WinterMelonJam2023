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
    [SerializeField] TextMeshProUGUI tutorialText;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    int JUNK_COUNTER = 0;
    public int HEALTH = 10;
    bool IS_DEAD = false;

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
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine("deleteTutorialText");
        // You can initialize any other variables or settings here
    }

    // Update is called once per frame
    void Update()
    {
        // Your update logic here
    }

    private void FixedUpdate()
    {
        if (HEALTH <= 0 && IS_DEAD == false)
        {
            // Change to death animation
            IS_DEAD = true;
            StartCoroutine("death");

        }
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

    IEnumerator deleteTutorialText()
    {
        yield return new WaitForSeconds(5);
        tutorialText.text = "";
    }

    IEnumerator death()
    {
        sr.enabled = false;
        rb.velocity = new Vector2(0, 0);
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(1);
        IS_DEAD = false;
        JUNK_COUNTER = 0;
        HEALTH = 10;
        text.text = "Junk Counter: " + JUNK_COUNTER;
        transform.position = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        sr.enabled = true;


    }
}
