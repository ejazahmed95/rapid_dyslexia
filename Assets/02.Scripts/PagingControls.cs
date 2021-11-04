using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PagingControls : MonoBehaviour
{
    public PlayerController player;
    public GameObject Pre;
    public GameObject Next;

    public GameObject[] Page;

    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        setPageInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentIndex > Page.Length - 1 || currentIndex < 0)
        {
            setPageInit();
        }

        if (currentIndex == 0)
        {
            Pre.SetActive(false);
        }
        if (currentIndex == Page.Length - 1)
        {
            Next.SetActive(false);
        }
        if (currentIndex != 0 && currentIndex != Page.Length - 1)
        {
            Pre.SetActive(true);
            Next.SetActive(true);
        }
    }

    private void setPageInit()
    {
        currentIndex = 0;
        for (int i = 0; i < Page.Length; i++)
        {
            if (i == 0)
            {
                Page[i].SetActive(true);
            }
            else
            {
                Page[i].SetActive(false);
            }
        }
    }

    public void updatePagePre()
    {
        Page[currentIndex].SetActive(false);
        currentIndex--;
        Page[currentIndex].SetActive(true);
    }

    public void updatePageNext()
    {
        Page[currentIndex].SetActive(false);
        currentIndex++;
        Page[currentIndex].SetActive(true);
    }
}
