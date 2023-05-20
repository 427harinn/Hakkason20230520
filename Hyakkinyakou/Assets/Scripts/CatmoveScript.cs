using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatmoveScript : MonoBehaviour
{
    [SerializeField] GameObject loseImage;

    private Animator catanim = null;
    private Rigidbody2D catrb = null;

    public float speed;
    public float gravity; 

    //地面判定
    public GroundCheckScript ground;
    private bool isGround = false;

    //ジャンプ系
    private bool isJump = false;
    public float jumpSpeed;
    private float jumpPos = 0.0f;
    public float jumpHeight;
    public float jumpLimitTime;
    private float jumpTime = 0.0f;

    public GroundCheckScript head;//頭ぶつけた判定
    private bool isHead = false;

    
    private string enemyTag = "Enemy";
    private bool isDown = false;

    // Start is called before the first frame update
    void Start()
    {
        catanim = GetComponent<Animator>();
        catrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xSpeed = 0.0f;
        float ySpeed = -gravity;

        isGround = ground.IsGround();
        isHead = head.IsGround();

        catanim.SetBool("catjumpflag", isJump);
        catanim.SetBool("catgroundflag", isGround);



        if (!isDown)
        {
            if (Input.GetKey("d"))
            {
                //向き
                transform.localScale = new Vector3(1, 1, 1);
                catanim.SetBool("catwalkflag", true);
                //歩く
                xSpeed = speed;
            }
            else if (Input.GetKey("a"))
            {
                transform.localScale = new Vector3(-1, 1, 1);
                catanim.SetBool("catwalkflag", true);
                xSpeed = -speed;
            }
            else
            {
                catanim.SetBool("catwalkflag", false);
                xSpeed = 0.0f;
            }

            if (isGround)
            {
                if (Input.GetKey("w"))
                {
                    ySpeed = jumpSpeed;
                    jumpPos = transform.position.y; //ジャンプした位置を記録する
                    isJump = true;
                    jumpTime = 0.0f;
                }
                else
                {
                    isJump = false;
                }
            }
            else if (isJump)
            {
                //上方向キーを押しているか
                bool pushUpKey = Input.GetKey("w");
                //現在の高さが飛べる高さより下か
                bool canHeight = jumpPos + jumpHeight > transform.position.y;
                //ジャンプ時間が長くなりすぎてないか
                bool canTime = jumpLimitTime > jumpTime;
                //上ボタンを押されている。かつ、現在の高さがジャンプした位置から自分の決めた位置より下ならジャンプを継続する
                if (pushUpKey && canHeight && canTime && !isHead)
                {
                    ySpeed = jumpSpeed;
                    jumpTime += Time.deltaTime;
                }
                else
                {
                    isJump = false;
                    jumpTime = 0.0f; //New
                }
            }

            catrb.velocity = new Vector2(xSpeed, ySpeed);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag)
        {
            catanim.Play("normalcatdeadanimation");
            catrb.constraints = RigidbodyConstraints2D.FreezeAll;
            isDown = true;
            Invoke("activelose", 2.0f);
        }
    }

    void activelose()
    {
        //loseImage.SetActive(true);

        transform.parent.GetComponent<BackgroundmoveScript>().FadeActive();

        //GManager.instance.fadeanimation();
        Invoke("ChangeScene", 2.5f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
