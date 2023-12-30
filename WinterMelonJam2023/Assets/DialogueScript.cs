using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    TextMeshProUGUI dialogue;
    public string[] stringArray;
    int count = 0;

    void Start()
    {
        dialogue = GameObject.FindWithTag("Dialogue").GetComponent<TextMeshProUGUI>();
        DisplayNextDialogue();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextDialogue();
        }
        if (count == -1)
        {
            Destroy(this.gameObject);
        }
    }

    void DisplayNextDialogue()
    {
        if (count < stringArray.Length)
        {
            dialogue.text = stringArray[count];
            count++;
        }
        else
        {
            // No more dialogues, you can handle this case as needed.
            Debug.Log("No more dialogues." + count);
            count = -1;
        }
    }
}
