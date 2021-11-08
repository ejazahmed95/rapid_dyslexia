using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageControll : MonoBehaviour
{
    public GameObject[] stage;

    public void StageUpdate(MentalStatus newMental)
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].SetActive(false);
        }

        switch(newMental)
        {
            case MentalStatus.normal:
            case MentalStatus.worrying:
                stage[0].SetActive(true);
                break;
            case MentalStatus.pain:
            case MentalStatus.breakdown:
                stage[1].SetActive(true);
                break;
        }
    }
}
