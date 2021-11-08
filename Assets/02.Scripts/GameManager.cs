using EAUtils;
using UnityEngine;

enum GameState { normal, gameON }

public class GameManager : MonoBehaviour
{
    public PlayerController player;
    public new Camera camera;
    public GameObject ReadingScene;

    public GameObject NavMeshMap;
    public GameObject GameWordsMap;
    private GameObject cameraDes;
    private float cameraSpeed = 0.3f;
    private Vector3 velocity = new Vector3(20, 20, 0);
    private bool cameraMove;

    public ShaderControll shaderControll;
    public AssetStage assetStage;

    // Start is called before the first frame update
    void Start()
    {
        camera.transform.position = new Vector3(NavMeshMap.transform.position.x, NavMeshMap.transform.position.y, -10);
        cameraMove = false;

        ReadingScene.SetActive(false);
        
        shaderControll.updateMaterial(player);
        assetStage.updateAssets(player);
    }

    // Update is called once per frame
    void Update()
    {

        if (cameraMove)
        {
            camera.transform.position = new Vector3(Mathf.SmoothDamp(camera.transform.position.x, cameraDes.transform.position.x, ref velocity.x, cameraSpeed), Mathf.SmoothDamp(camera.transform.position.y, cameraDes.transform.position.y, ref velocity.y, cameraSpeed), -10);
            if (camera.transform.position == cameraDes.transform.position)
            {
                cameraMove = false;
            }
        }
        
    }

    public void startReading()
    {
        player.SetCanControll(false);
        cameraDes = GameWordsMap;
        cameraMove = true;
        ReadingScene.SetActive(true);
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
