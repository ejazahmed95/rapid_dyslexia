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
                //if (i == allAssets.Length)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                //}
                //else if (i == 0)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.5923923f, 0.823942f, 1f);
                //}
                //else if (i == 3)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                //}
                //else if (i == 7)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                //}
                //else
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 1f);
                //}
            }
        }
        else
        {
            for (int i = 0; i < allAssets.Length; i++)
            {
                allAssets[i].GetComponent<SpriteRenderer>().sprite = comb2[i];

                //if (i == 5 || i == 6)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                //}
                //else if (i == 7)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1f);
                //}
                //else if (i == 0)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.5923923f, 0.823942f, 1f);
                //}
                //else if (i == 3)
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.3f, 0.3f, 1f);
                //}
                //else
                //{
                //    allAssets[i].GetComponent<Transform>().localScale = new Vector3(0.6f, 0.6f, 1f);
                //}
            }
        }
    }
}
