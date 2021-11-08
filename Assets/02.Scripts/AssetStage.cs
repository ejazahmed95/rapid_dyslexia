using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetStage : MonoBehaviour
{
    public GameObject[] allAssets;

    public Sprite[] comb1;
    public Sprite[] comb2;
    
    public void updateAssets(PlayerController player)
    {
        if (player.GetMental() == MentalStatus.normal || player.GetMental() == MentalStatus.worrying)
        {
            for (int i = 0; i < allAssets.Length; i++)
            {
                allAssets[i].GetComponent<SpriteRenderer>().sprite = comb1[i];
            }
        }
        else
        {
            for (int i = 0; i < allAssets.Length; i++)
            {
                allAssets[i].GetComponent<SpriteRenderer>().sprite = comb2[i];
            }
        }
    }
}
