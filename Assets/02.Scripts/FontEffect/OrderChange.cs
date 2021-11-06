using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OrderChange : MonoBehaviour
{
    public GameObject textObj;
    private Text text;
    private List<string> mText;
    int timeTick = 0;

    // Start is called before the first frame update
    void Start()
    {
        mText = new List<string>();
        textObj = this.gameObject;
        text = textObj.GetComponent<Text>();
        int startIndext = 0;
        for (int i = 0; i < text.text.ToString().Length; i++)
        {
            string t = text.text.ToString().Substring(i, 1);
            if (!IsCN(t))
            {
                mText.Add(text.text.ToString().Substring(startIndext, i - startIndext + 1));
                startIndext = i + 1;
            }
        }

        foreach (string t in mText)
        {
            Debug.Log(t);
        }
    }

    static bool IsCN(string strInput)
    {
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[\u4e00-\u9fa5]+$");
        return reg.IsMatch(strInput);
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        //Debug.Log("tick!");
        timeTick++;

        if (timeTick >= 5)
        {
            updateMText();
            string newT = "";
            foreach (string t in mText)
            {
                newT += t;
            }
            text.text = newT;

            timeTick = 0;
        }
    }
    private void Update()
    {

    }

    private void updateMText()
    {
        for(int j = 0; j < mText.Count; j ++)
        {
            char[] currentT = new char[mText[j].Length];
            for (int i = 0; i < mText[j].Length; i++)
            {
                currentT[i] = mText[j][i];
            }

            //for (int i = currentT.Length - 1; i > 0; i--)
            //{
                UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
                int index1 = UnityEngine.Random.Range(0, currentT.Length - 1);
                int index2 = UnityEngine.Random.Range(0, currentT.Length - 1);
                char tmp = currentT[index2];
                currentT[index2] = currentT[index1];
                currentT[index1] = tmp;
            //}

            string s = new string(currentT);

            mText[j] = s;
        }
    }
}
