using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoAttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    private string enemyTag = "Enemy";
    private string groundTag = "Ground";
    private string deadAreaTag = "DeadArea";

    [Header("à⁄ìÆë¨ìx")] public float speed;
    [Header("èdóÕ")] public float gravity;

    private Rigidbody2D rb = null;
    int xVector = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (GameObject.Find("mikoImage").transform.localScale.x == 1)
        {
            xVector = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xVector * speed, -gravity);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == enemyTag || collision.collider.tag == groundTag || collision.collider.tag == deadAreaTag)
        {
            Destroy(this.gameObject);
        }
    }
}
