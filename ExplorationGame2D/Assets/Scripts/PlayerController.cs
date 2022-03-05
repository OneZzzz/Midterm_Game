using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    private void Awake()
    {
        instance = this;
    }



    private  float speed=8f;
    private float cameraFollowSpeed=6;
    private float jumpForce=600;

    private int score = 0;

    public Transform checkPoint01,checkPoint02,forwardCheckPoint;

    Animator anim;

    public bool isFindGem;

    public bool isFindKey;

    public Transform door;
    public BoxCollider2D boxCollider;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
        CameraFallow();
        FowardCheck();
        ReturnStartScene();
    }
    void ReturnStartScene()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("startscene");
    }

    void FowardCheck()
    {
        if (UIManager.isInDiaState) return;
        if (Input.GetKeyDown(KeyCode.J) || Input.GetMouseButtonDown(0))
        {
            Vector3 dir;
            if (transform.localScale.x == -1)
                dir = Vector3.left;
            else
                dir = Vector3.right;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(forwardCheckPoint.position, dir,1f);
            if (raycastHit2D)
            {
                if (raycastHit2D.collider.gameObject.tag == "door")
                {
                    if (!isFindKey) return;
                    door.eulerAngles = new Vector3(0, 0, 0);
                    boxCollider.enabled = false;
                    AudioManager.instance.PlayAudio(AudioManager.instance.openDoor);
                }

                if (raycastHit2D.collider.gameObject.tag == "NPC")
                {
                    if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
                        raycastHit2D.collider.gameObject.GetComponent<NPCController>().NPCEvent();
                }
                else if (raycastHit2D.collider.gameObject.tag == "TaskNpc")
                {
                    if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
                    {
                        if (isFindGem)
                        {
                            isFindKey = true;
                            raycastHit2D.collider.gameObject.GetComponent<TaskNpc>().ElseNpcEvent();

                            AudioManager.instance.PlayAudio(AudioManager.instance.key);
                        }
                        else
                        {
                            raycastHit2D.collider.gameObject.GetComponent<TaskNpc>().NPCEvent();

                        }
                    }
                }


            }
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (x != 0)
            anim.SetBool("run", true);
        else if (x == 0)
            anim.SetBool("run", false);
        transform.Translate(Vector2.right * speed * Time.deltaTime*x);
    }
    bool CheckInGround(Transform checkPoint)
    {
        RaycastHit2D raycastHit2D=  Physics2D.Raycast(checkPoint.position, Vector2.down, 0.05f);
        if (raycastHit2D)
        {
            if(raycastHit2D.collider.gameObject.tag == "ground")
            return true;
        }
        return false;


    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CheckInGround(checkPoint01) || CheckInGround(checkPoint02))
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
                anim.SetTrigger("jump");
                AudioManager.instance.PlayAudio(AudioManager.instance.jump);
            }
        }
    }
    void CameraFallow()
    {
        print(11);
        float distance = Vector3.Distance(Camera.main.transform.position, new Vector3(transform.position.x, 0, -10));
        int dirction=(transform.position.x - Camera.main.transform.position.x > 0)? 1 : -1;
        if (distance < 0.03f) return;
        else if (distance <= 3)
        {
            Camera.main.transform.Translate(1 * cameraFollowSpeed * Time.deltaTime*dirction, 0, 0);
        }
        else
        {
            Camera.main.transform.Translate(1 * speed * Time.deltaTime *dirction, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("deadline"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.CompareTag("Gold"))
        {
            score++;
            Destroy(collision.gameObject);
            UIManager.instance.ShowScore(score);
            AudioManager.instance.PlayAudio(AudioManager.instance.coin);
        }
        else if (collision.gameObject.CompareTag("gem"))
        {
            isFindGem = true;
            AudioManager.instance.PlayAudio(AudioManager.instance.gem);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.CompareTag("startCreat"))
        {
            EnemyCreater.instance.StartCreat();
        }
        else if (collision.gameObject.CompareTag("stopCreat"))
        {
            EnemyCreater.instance.StopCreat() ;
        }
        else if (collision.gameObject.CompareTag("endpoint"))
        {
            SceneController co= collision.gameObject.GetComponent<SceneController>();
            if (co == null) return;
            co.EndPointChangeScene();
        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("NPC"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
    //            collision.GetComponent<NPCController>().NPCEvent();
    //    }
    //    else if (collision.gameObject.CompareTag("TaskNpc"))
    //    {
    //        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.Space))
    //        {
    //            if (isFindGem)
    //            {
    //                isFindKey = true;
    //                collision.GetComponent<TaskNpc>().ElseNpcEvent();
    //                AudioManager.instance.PlayAudio(AudioManager.instance.key);
    //            }
    //            else
    //            {
    //                collision.GetComponent<TaskNpc>().NPCEvent();
                    
    //            }
    //        }
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.CompareTag("door"))
        {
            if (!isFindKey) return;
            door.eulerAngles = new Vector3(0, 0, 0);
            boxCollider.enabled = false;
            AudioManager.instance.PlayAudio(AudioManager.instance.openDoor);
        }
    }

}
