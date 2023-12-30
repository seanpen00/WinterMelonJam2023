using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopLogic : MonoBehaviour
{
    // Start is called before the first frame update
    PlayerGameLogic playerGameLogic;
    public TextMeshProUGUI JUNK_COUNTER_TEXT;
    Rigidbody2D rb;
    void Start()
    {
        playerGameLogic = GameObject.Find("The Kevin").GetComponent<PlayerGameLogic>();
        rb = GameObject.Find("The Kevin").GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        JUNK_COUNTER_TEXT.text = "Junk Counter: " + playerGameLogic.JUNK_COUNTER;
    }
}
