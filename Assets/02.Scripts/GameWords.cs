using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWords : MonoBehaviour
{
    private GameObject wordsContainer;
    private Vector3 containerPos;
    private List<GameObject> allWords;

    public GameObject formOffset;
    public GameObject word;
    public string words;

    // Start is called before the first frame update
    void Start()
    {
        wordsContainer = this.gameObject;
        containerPos = wordsContainer.transform.position;
        allWords = new List<GameObject>();

        for (int i = 0; i < words.Length; i++)
        {
            GameObject obj = Instantiate(word, Vector3.zero, Quaternion.identity);
            
            TextMesh text = obj.GetComponentInChildren<TextMesh>();
            text.text = words[i].ToString();

            obj.transform.parent = wordsContainer.transform;
            obj.transform.localPosition = Vector3.zero;
            allWords.Add(obj);
        }

        //Layout init
        float wordWidth = word.transform.localScale.x / formOffset.transform.localScale.x;
        float offset = -allWords.Count * wordWidth / 2 + wordWidth / 2;
        Debug.Log(wordWidth);
        foreach (GameObject obj in allWords)
        {
            Vector3 pos = new Vector3(offset, 0, 0);
            obj.transform.localPosition = pos;
            offset += wordWidth;
        }

    }

    // Update is called once per frame
    void Update()
    {
        containerPos.y -= 0.01f;
        wordsContainer.transform.position = containerPos;
    }
}
