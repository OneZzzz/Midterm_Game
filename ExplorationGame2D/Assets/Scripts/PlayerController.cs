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
    private float cameraFollowOffsetY = 2;
    private float jumpForce=600;

    [HideInInspector]
    public int score = 0;

    public Transform checkPoint01,checkPoint02,forwardCheckPoint;

    Animator anim;

    public bool isFindGem;

    public bool isFindKey;

    [HideInInspector]
    public Vector3 savePoint;


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
        if (Input.GetKeyDown(KeyCode.J))
        {
            Vector3 dir;
            if (transform.localScale.x == -1)
                dir = Vector3.left;
            else
                dir = Vector3.right;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(forwardCheckPoint.position, dir, 1f);
            if (!raycastHit2D) return;

            if (raycastHit2D.collider.gameObject.CompareTag("trigger") && raycastHit2D.collider.gameObject.GetComponent<ILevelEvent>() != null)
                raycastHit2D.collider.gameObject.GetComponent<ILevelEvent>().LevelEvent();


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
        RaycastHit2D raycastHit2D=  Physics2D.Raycast(checkPoint.position, Vector2.down, 0.1f);
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
                Rigidbody2D rg= GetComponent<Rigidbody2D>();
                rg.velocity = new Vector3(rg.velocity.x, 0, 0);
                rg.AddForce(Vector2.up * jumpForce);
                anim.SetTrigger("jump");
                AudioManager.instance.PlayAudio(AudioManager.instance.jump);
            }
        }
    }
    void CameraFallow()
    {
        float distanceX = transform.position.x - Camera.main.transform.position.x;

        float distanceY = transform.position.y+ cameraFollowOffsetY - Camera.main.transform.position.y;

        if (Mathf.Abs( distanceX) > 0.2f)
        {
            int dirctionX = (distanceX > 0) ? 1 : -1;
            if (distanceX <= 3)
            {
                Camera.main.transform.Translate(cameraFollowSpeed * Time.deltaTime * dirctionX, 0, 0);
            }
            else
            {
                Camera.main.transform.Translate(speed * Time.deltaTime * dirctionX, 0, 0);
            }
        }
        if (Mathf.Abs(distanceY) > 0.2f)
        {
            int dirctionY = (distanceY > 0) ? 1 : -1;
            if (distanceY <= 3)
            {
                Camera.main.transform.Translate(0, cameraFollowSpeed * Time.deltaTime * dirctionY, 0);
            }
            else
            {
                Camera.main.transform.Translate(0, speed * Time.deltaTime * dirctionY, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("trigger"))
        {
            IGameEvent[] its = collision.gameObject.GetComponents<IGameEvent>();
            for (int i = 0; i < its.Length; i++)
            {
                its[i].GameEvent();
            }
            
        }
        
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    public void MoveTargetRaw(Vector3 pos)
    {
        transform.position = pos;
        Camera.main.transform.position = new Vector3(pos.x,pos.y,-10);
    }
    public void SavePoint()
    {
        savePoint = transform.position;
    }
    public void LoadPoint()
    {
        if (savePoint == null || savePoint==Vector3.zero )
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        else
            MoveTargetRaw(savePoint);
    }
}
