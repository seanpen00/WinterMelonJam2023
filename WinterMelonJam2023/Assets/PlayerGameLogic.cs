using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerGameLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI text;
    int JUNK_COUNTER = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SpaceJunk"))
        {
            JUNK_COUNTER += 1;
            Destroy(collision.gameObject);
            text.text = "Junk Counter: " + JUNK_COUNTER;
        }
    }
}
