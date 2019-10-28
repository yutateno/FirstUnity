using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;
    private bool move;
    private bool[] dire;
    private Rigidbody rb;


    private GameObject backObj;
    private PlayerHit backHit;

    private GameObject frontObj;
    private PlayerHit frontHit;

    private GameObject leftObj;
    private PlayerHit leftHit;

    private GameObject rightObj;
    private PlayerHit rightHit;

    public GameObject firstGimmickMoveWall;
    private bool firstGimmickMove;


    public bool gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        move = false;
        dire = new bool[4] { false, false, false, false };
        rb = GetComponent<Rigidbody>();


        backObj = GameObject.Find("BackHit");
        backHit = backObj.GetComponent<PlayerHit>();

        frontObj = GameObject.Find("FrontHit");
        frontHit = frontObj.GetComponent<PlayerHit>();

        leftObj = GameObject.Find("LeftHit");
        leftHit = leftObj.GetComponent<PlayerHit>();

        rightObj = GameObject.Find("RightHit");
        rightHit = rightObj.GetComponent<PlayerHit>();

        firstGimmickMove = false;

        gameEnd = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameEnd)
        {
            if (move)
            {
                if (dire[0])
                {
                    Vector3 pos = this.transform.position;
                    pos.x -= speed;
                    rb.MovePosition(pos);

                    if (leftHit.hit)
                    {
                        dire[0] = false;
                        move = false;
                    }
                }
                else if (dire[1])
                {
                    Vector3 pos = this.transform.position;
                    pos.x += speed;
                    rb.MovePosition(pos);

                    if (rightHit.hit)
                    {
                        dire[1] = false;
                        move = false;
                    }
                }
                else if (dire[2])
                {
                    Vector3 pos = this.transform.position;
                    pos.z -= speed;
                    rb.MovePosition(pos);

                    if (backHit.hit)
                    {
                        dire[2] = false;
                        move = false;
                    }
                }
                else if (dire[3])
                {
                    Vector3 pos = this.transform.position;
                    pos.z += speed;
                    rb.MovePosition(pos);

                    if (frontHit.hit)
                    {
                        dire[3] = false;
                        move = false;
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.A) && !leftHit.hit)
                {
                    move = true;
                    dire[0] = true;
                }

                if (Input.GetKeyDown(KeyCode.D) && !rightHit.hit)
                {
                    move = true;
                    dire[1] = true;
                }

                if (Input.GetKeyDown(KeyCode.S) && !backHit.hit)
                {
                    move = true;
                    dire[2] = true;
                }

                if (Input.GetKeyDown(KeyCode.W) && !frontHit.hit)
                {
                    move = true;
                    dire[3] = true;
                }
            }

            if (firstGimmickMove)
            {
                Vector3 pos = firstGimmickMoveWall.transform.position;
                if (pos.x <= 0.0)
                {
                    pos.x += 0.1f;
                    firstGimmickMoveWall.transform.position = pos;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.Application.Quit();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FirstGimmick"))
        {
            firstGimmickMove = true;
        }
    }
}
