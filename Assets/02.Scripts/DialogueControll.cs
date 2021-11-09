using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControll : MonoBehaviour
{
    public GameObject dialogue;
    private bool isShowing = false;
    private int timer = 0;

    private void Start()
    {
        dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isShowing)
        {
            dialogue.SetActive(true);
            timer++;
            if (timer == 360)
            {
                isShowing = false;
                timer = 0;
                dialogue.SetActive(false);
            }
        }
    }

    public void showDialogue()
    {
        if (!isShowing)
        {
            isShowing = true;
            dialogue.SetActive(true);
        }
    }
}
