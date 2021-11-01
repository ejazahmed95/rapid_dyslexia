using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public enum ShiftState { Off, Shift, CapsLock}

public class KeyInfo
{
    public Button key;
    public Vector2 keySize;
    public Vector2 position;
}

public enum CapsLockState { Upper, Lower }

public class CustomKeyboard : MonoBehaviour
{
    public Text targetText;
    private float screenSizeHeight;
    private float screenSizeWidth;
    public Texture2D selectionImage;
    public GameObject Layout;
    public GameObject background;
    public Vector3 visiablePosition;
    public Vector3 invisiablePosition;

    //Board and button sizes
    public Rect screenRect = new Rect(0, 0, 0, 0);
    public float buttonGap = 5;
    public int fontSize;
    public Vector2 stdKeySize = new Vector2(16, 32);
    public Vector2 midKeySize = new Vector2(32, 32);
    public Vector2 lgeKeySize = new Vector2(64, 32);
    public Vector2 slgeKeySize = new Vector2(64, 32);
    public List<KeyInfo> virtualKeys;

    //Key audio
    public AudioClip keyPressSound = null;

    //Shift settings
    public bool shiftStateSwitchEnabled = true;
    public CapsLockState capsLockState = CapsLockState.Upper;

    public string[] upperKeys = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "<row>",
     "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "<row>",
     "A", "S", "D", "F", "G", "H", "J", "K", "L", "<row>",
     "Caps", "Z", "X", "C", "V", "B", "N", "M", "del", "<row>",
     ".", "!", "?", "Space", "Done" };

    public string[] lowerKeys = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "<row>",
     "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "<row>",
     "a", "s", "d", "f", "g", "h", "j", "k", "l", "<row>",
     "Caps", "z", "x", "c", "v", "b", "n", "m", "del", "<row>",
     ".", "!", "?", "Space", "Done" };

    //0 near the left edge, 1 is empty and half a key's length
    public int[] rowIndents = { 0, 0, 1, 0, 0 };

    void Awake()
    {
        //Check that our key array sizes match
        if (upperKeys.Length != lowerKeys.Length)
        {
            print("Error: CustomKeyboard needs the same number of upper and lower case keys!");
            Destroy(this);
        }

        //Init the keyboard sizes
        screenSizeHeight = Screen.height;
        screenSizeWidth = Screen.width;
        fontSize = screenSizeHeight >= screenSizeWidth ? (int)screenSizeWidth / 1080 * 60 : (int)screenSizeHeight / 1080 * 60;
        float keyWidth = screenSizeWidth / 10 - buttonGap * 2;
        float keyHeight = screenSizeHeight / 14 - buttonGap * 2;
        stdKeySize = new Vector2(keyWidth, keyHeight);
        midKeySize = new Vector2(keyWidth * 1.5f, keyHeight);
        lgeKeySize = new Vector2(keyWidth * 3, keyHeight);
        slgeKeySize = new Vector2(keyWidth * 4.5f, keyHeight);
        Debug.Log(stdKeySize);
        Debug.Log(midKeySize);
        Debug.Log(lgeKeySize);

        Debug.Log(screenSizeHeight + "," +  screenSizeWidth);

        float keyboardWidth = screenSizeWidth;
        float keyboardHeight = (stdKeySize.y + buttonGap * 2) * rowIndents.Length;

        background = GameObject.Find("Background");
        background.GetComponent<RectTransform>().sizeDelta = new Vector2(keyboardWidth, keyboardHeight);

        screenRect = new Rect(0, screenSizeHeight - keyboardHeight, keyboardWidth, keyboardHeight);

        Layout = GameObject.Find("Layout");
        Layout.GetComponent<RectTransform>().sizeDelta = new Vector2(screenRect.width, screenRect.height); 
        visiablePosition = Layout.GetComponent<RectTransform>().anchoredPosition3D - new Vector3(0, (screenSizeHeight - keyboardHeight) / 2, 0);
        Layout.GetComponent<RectTransform>().anchoredPosition3D = visiablePosition;

        //Init Key info
        virtualKeys = new List<KeyInfo>();
        float offset_x = Layout.GetComponent<RectTransform>().sizeDelta.x / 2 - stdKeySize.x / 2;
        float offset_y = Layout.GetComponent<RectTransform>().sizeDelta.y / 2 - stdKeySize.y / 2;
        int row = 0;
        int col = 0;
        float blank = 0;
        float typeOffset = 0;
        float currentPos = 0;
        for (int i = 0; i < upperKeys.Length; i++)
        {
            if (upperKeys[i] != "<row>")
            {
                GameObject temp = GameObject.Find(upperKeys[i]);
                Button but = temp.GetComponent<Button>();
                KeyInfo key = new KeyInfo();
                key.key = but;
                if (but.name == "Caps" || but.name == "del")
                {
                    but.GetComponent<RectTransform>().sizeDelta = midKeySize;
                    typeOffset = (midKeySize.x - stdKeySize.x) / 2;
                }
                else if (but.name == "Done")
                {
                    but.GetComponent<RectTransform>().sizeDelta = lgeKeySize;
                    typeOffset = (lgeKeySize.x - stdKeySize.x) / 2;
                }
                else if (but.name == "Space")
                {
                    but.GetComponent<RectTransform>().sizeDelta = slgeKeySize;
                    typeOffset = (slgeKeySize.x - stdKeySize.x) / 2;
                }
                else
                {
                    but.GetComponent<RectTransform>().sizeDelta = stdKeySize;
                    typeOffset = 0;
                }
                key.keySize = but.GetComponent<RectTransform>().sizeDelta;
                Text tex = but.GetComponentInChildren<Text>();
                tex.text = but.name;
                tex.fontSize = fontSize;

                if (rowIndents[col] == 1)
                {
                    blank = (stdKeySize.x + buttonGap) / 2;
                }
                else
                {
                    blank = 0;
                }
                but.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-offset_x + blank + currentPos + typeOffset + buttonGap, offset_y - col * (stdKeySize.y + buttonGap * 2) - buttonGap, 0);
                currentPos += but.GetComponent<RectTransform>().sizeDelta.x + buttonGap * 2;
                virtualKeys.Add(key);

                row++;
            }
            else
            {
                col++;
                row = 0;
                typeOffset = 0;
                currentPos = 0;
            }
        }
        for (int i = 0; i < virtualKeys.Count; i++)
        {
            Debug.Log(virtualKeys[i].key.name);
        }

        Debug.Log(screenRect);

        //add button click EventListener
        foreach(KeyInfo k in virtualKeys)
        {
            k.key.onClick.AddListener(OnClick);
        }
    }

    public void OnClick()
    {
        var button = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        Debug.Log(button.name);

        switch (button.name)
        {
            case "Caps":
                //switch between upper and lower
                this.capsLockState = this.capsLockState == CapsLockState.Upper ? CapsLockState.Lower : CapsLockState.Upper;
                SwitchKey();
                break;
            case "del":
                if (targetText.text.Length > 0)
                    targetText.text = targetText.text.Substring(0, targetText.text.Length - 1);
                break;
            case "Space":
                targetText.text = targetText.text + " ";
                break;
            case "Done":
                //Finish Input

                break;
            default:
                targetText.text = targetText.text + button.name;
                break;
        }
    }

    public void SwitchKey()
    {
        if (this.capsLockState == CapsLockState.Upper)
        {
            foreach(KeyInfo k in this.virtualKeys)
            {
                for (int i = 0; i < this.lowerKeys.Length; i++)
                {
                    if (k.key.name == lowerKeys[i])
                    {
                        k.key.name = upperKeys[i];
                        Text tex = k.key.GetComponentInChildren<Text>();
                        tex.text = k.key.name;
                        tex.fontSize = fontSize;
                    }
                }
            }
        }
        else
        {
            foreach (KeyInfo k in this.virtualKeys)
            {
                for (int i = 0; i < this.upperKeys.Length; i++)
                {
                    if (k.key.name == upperKeys[i])
                    {
                        k.key.name = lowerKeys[i];
                        Text tex = k.key.GetComponentInChildren<Text>();
                        tex.text = k.key.name;
                        tex.fontSize = fontSize;
                    }
                }
            }
        }
    }

}
