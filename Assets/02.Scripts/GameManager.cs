using EAUtils;
using UnityEngine;

enum GameState { normal, gameON }

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public GameWords gameWords;
    public new Camera camera;
    public GameObject GameWordsButton;
    public GameObject GameWordsExitButton;
    public GameObject ReadingScene;

    public GameObject NavMeshMap;
    public GameObject GameWordsMap;
    private GameObject cameraDes;
    private float cameraSpeed = 0.3f;
    private Vector3 velocity = new Vector3(20, 0, 0);
    private bool cameraMove;

    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(NavMeshMap.transform.position.x, NavMeshMap.transform.position.y, -10);
        cameraMove = false;

        GameWordsExitButton.SetActive(false);
        ReadingScene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            startGameWords();
        }

        if (cameraMove)
        {
            camera.transform.position = new Vector3(Mathf.SmoothDamp(camera.transform.position.x, cameraDes.transform.position.x, ref velocity.x, cameraSpeed), 0, -10);
            if (camera.transform.position == cameraDes.transform.position)
            {
                cameraMove = false;
            }
        }
        
    }

    public void startGameWords()
    {
        player.SetCanControll(false);
        cameraDes = GameWordsMap;
        cameraMove = true;
        GameWordsButton.SetActive(false);
        GameWordsExitButton.SetActive(true);
    }

    public void exitGameWords()
    {
        player.SetCanControll(true);
        cameraDes = NavMeshMap;
        cameraMove = true;
        //GameWordsButton.SetActive(true);
        GameWordsExitButton.SetActive(false);
    }

    public void startReading()
    {
        player.SetCanControll(false);
        cameraDes = GameWordsMap;
        cameraMove = true;
        ReadingScene.SetActive(true);
        //GameWordsButton.SetActive(false);
        //GameWordsExitButton.SetActive(true);
    }

    public void exitReading()
    {
        player.SetCanControll(true);
        cameraDes = NavMeshMap;
        cameraMove = true;
        ReadingScene.SetActive(false);
    }

    public void LoadQuizScene()
    {
        DI.Get<AppManager>().SetCurrentActivity(Activity.ActivityType.WordGame);
    }
}
