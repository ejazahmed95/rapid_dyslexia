using System.Collections;
using System.Collections.Generic;
using EAUtils;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public enum MentalStatus { normal, worrying, pain, breakdown}

public class PlayerController : MonoBehaviour
{
    public GameObject floor;

    MentalStatus mental = MentalStatus.pain;

    private NavMeshAgent agent;
    private bool canControll;
    [SerializeField]private Animator _animator;

    private void Awake() {
        mental = DI.Get<StatsController>().GetMentalStatus();
    }

    // Start is called before the first frame update
    void Start()
    {
        //floor = GameObject.FindGameObjectWithTag("Floor");
        SetCanControll(true);

        _animator = this.GetComponent<Animator>();

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    public void SetCanControll(bool setValue)
    {
        canControll = setValue;
    }

    public bool GetCanControll()
    {
        return canControll;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Vector3.zero;

        if (canControll)
        {
            if (Input.touches.Length > 0)
            {
                Vector3 mapSize = floor.transform.localScale;
                Vector2 screenpos = Input.touches[0].position;
                Vector2 screenpos2;
                screenpos2.x = screenpos.x - (Screen.width / 2);
                screenpos2.y = screenpos.y - (Screen.height / 2);
    
                targetPos.x = screenpos2.x * (mapSize.x / Screen.width);
                targetPos.y = screenpos2.y * (mapSize.y / Screen.height);
                //targetPos.x = screenpos2.x  / Screen.width;
                //targetPos.y = screenpos2.y  / Screen.height;
                targetPos.z = 0;
            }
            else
            {
                Vector3 mapSize = floor.transform.localScale;
                Vector2 screenpos = Input.mousePosition;
                //Debug.Log(screenpos);
                Vector2 screenpos2;
                screenpos2.x = screenpos.x - (Screen.width / 2);
                screenpos2.y = screenpos.y - (Screen.height / 2);

                targetPos.x = screenpos2.x * (mapSize.x / Screen.width);
                targetPos.y = screenpos2.y * (mapSize.y / Screen.height);
                //targetPos.x = screenpos2.x  / Screen.width;
                //targetPos.y = screenpos2.y  / Screen.height;
                targetPos.z = 0;
            }
            
            agent.SetDestination(targetPos);
        }

        Debug.Log(agent.velocity);
        _animator.SetBool("WalkLeft", false);
        _animator.SetBool("WalkRight", false);
        if (agent.velocity.x > 0)
        {
            _animator.SetBool("WalkRight", true);
        }
        if (agent.velocity.x < 0)
        {
            _animator.SetBool("WalkLeft", true);
        }

        if (Input.touches.Length > 0)
        {

        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    Debug.Log("yes!");
                }
            }
        }

    }

    public void SetMental(MentalStatus newStatus)
    {
        this.mental = newStatus;
    }

    public MentalStatus GetMental()
    {
        return this.mental;
    }
}
