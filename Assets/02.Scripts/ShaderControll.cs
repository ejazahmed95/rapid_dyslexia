using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderControll : MonoBehaviour
{
    public GameObject readingMonitor;
    public GameObject sceneMonitor;

    public Material readingM1;
    public Material readingM2;
    public Material sceneM1;
    public Material sceneM2;

    public void updateMaterial(PlayerController player)
    {
        if (player.GetMental() == MentalStatus.normal || player.GetMental() == MentalStatus.worrying)
        {
            readingMonitor.GetComponent<SpriteRenderer>().material = readingM1;
            sceneMonitor.GetComponent<SpriteRenderer>().material = sceneM1;
        }
        else
        {
            readingMonitor.GetComponent<SpriteRenderer>().material = readingM2;
            sceneMonitor.GetComponent<SpriteRenderer>().material = sceneM2;
        }
    }
    
}
