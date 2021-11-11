using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class TimelineProgress : MonoBehaviour
{

    public Action OnTimelineEvent;
       
    
    public void TimelineEvent()
    {
        OnTimelineEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        OnTimelineEvent = GotoNextLevel;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GotoNextLevel()
    {
        Debug.Log("GotoNextLevel");
        SceneManager.LoadScene(2);
    }




}
