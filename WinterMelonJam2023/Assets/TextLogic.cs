using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextLogic : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshProUGUI TUTORIAL_TEXT;
    TextMeshProUGUI JUNK_COUNTER;
    PlayerGameLogic player;

    bool tutFound = false;
    bool junkFound = false;
    bool playerFound = false;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while (TUTORIAL_TEXT == null && tutFound == false)
        {
            tutFound = true;
            TUTORIAL_TEXT = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
            StartCoroutine("deleteTutorialText");
        }
        while (JUNK_COUNTER == null && junkFound == false)
        {
            junkFound = true;
            JUNK_COUNTER = GameObject.Find("JunkCounter").GetComponent<TextMeshProUGUI>();
        }
        while (player == null && playerFound == false)
        {
            playerFound = true;
            player = GameObject.Find("TheKevin").GetComponent<PlayerGameLogic>();
        }
    }

    IEnumerator deleteTutorialText()
    {
        yield return new WaitForSeconds(5);
        TUTORIAL_TEXT.text = "";
    }
}
