using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour
{
    public GameObject trigger;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        trigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("is trigger!!!!");
        if (collision.tag == "Player" && player.GetCanControll())
        {
            trigger.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trigger.SetActive(false);
    }
}
