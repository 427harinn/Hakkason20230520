using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatmoveScript : MonoBehaviour
{
    [SerializeField] GameObject loseImage;
    [SerializeField] GameObject winImage;

    [SerializeField] AudioSource stagesource;
    [SerializeField] AudioClip badmusic;
    [SerializeField] AudioClip winmusic;
    [SerializeField] AudioClip attackAudioClip;
    [SerializeField] AudioClip attackitemAudioClip;

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
    private string deadAreaTag = "DeadArea";
    private string goalTag = "goal";
    private string attackitemTag = "AttackItem";
    private bool isDown = false;

    AudioSource attackaudioSource;

    int itemgetcount = 0;

    bool finish;

    // Start is called before the first frame update
    void Start()
    {
        catanim = GetComponent<Animator>();
        catrb = GetComponent<Rigidbody2D>();
        attackaudioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Fireattack();
        SpecialAttack();
        itemgetcount++;
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

    private void Fireattack()
    {
        if(Input.GetMouseButtonDown(0) && isGround) {
            attackaudioSource.PlayOneShot(attackAudioClip);
            transform.Find("fireattackImage").gameObject.SetActive(true);
        }
    }

    private void SpecialAttack()
    {
        if (Input.GetMouseButtonDown(1) && GManager.instance.specialatackNum != 0)
        {
            attackaudioSource.PlayOneShot(attackAudioClip);
            GManager.instance.specialatackNum--;
            Vector3 instantiatepos = this.gameObject.transform.position;
            int scale = 0;
            if(this.gameObject.transform.localScale.x == 1)
            {
                scale = 1;
                instantiatepos.x += 1;
            } else
            {
                scale = -1;
                instantiatepos.x -= 1;
            }
            GameObject obj = Instantiate((GameObject)Resources.Load("Prefab/specialattackImage"), instantiatepos, Quaternion.identity, GameObject.Find("backImage").transform);
            obj.transform.localScale = new Vector3(scale, 1, 1);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == deadAreaTag)
        {
            Invoke("activelose", 1.0f);
        }
        if (collision.tag == goalTag)
        {
            GManager.instance.stagecount++;
            Invoke("activewin", 1.0f);
        }
        if(collision.tag == attackitemTag)
        {
            if(itemgetcount > 10)
            {
                attackaudioSource.PlayOneShot(attackitemAudioClip);
                GManager.instance.specialatackNum++;
                itemgetcount = 0;
            }
        }
    }

    void activelose()
    {
        if(!finish)
        {
            finish = true;
            GManager.instance.specialatackNum = 0;
            stagesource.PlayOneShot(badmusic);
            loseImage.SetActive(true);
            transform.parent.GetComponent<BackgroundmoveScript>().FadeActive();
            Invoke("ChangeScene", 2.5f);
        }

    }
    void activewin()
    {
        if (!finish)
        {
            finish = true;
            GManager.instance.specialatackNum = 0;
            stagesource.PlayOneShot(winmusic);
            winImage.SetActive(true);
            transform.parent.GetComponent<BackgroundmoveScript>().FadeActive();
            Invoke("ChangeScene", 2.5f);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
