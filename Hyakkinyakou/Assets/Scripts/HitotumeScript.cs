using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitotumeScript : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    [Header("重力")] public float gravity;
    [Header("画面外でも行動する")] public bool nonVisibleAct;

    private Rigidbody2D rb = null;
    private SpriteRenderer sr = null;
    private bool rightTleftF = false;

    public HitotumeCollisionScript checkCollision;

    private string fireattackTag = "FireAttack";
    private string specialattackTag = "SpecialAttack";
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sr.isVisible || nonVisibleAct)
        {
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }
            int xVector = -1;
            if (rightTleftF)
            {
                xVector = 1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            rb.Sleep();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == fireattackTag || collision.collider.tag == specialattackTag)
        {
            Debug.Log(collision.collider.tag);
            Destroy(this.gameObject);
        }
    }






}
