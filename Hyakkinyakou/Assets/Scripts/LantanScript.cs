using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LantanScript : MonoBehaviour
{
    private string fireattackTag = "FireAttack";
    private string specialattackTag = "SpecialAttack";

    private Animator lantananim = null;
    private BoxCollider2D collider = null;
    // Start is called before the first frame update
    void Start()
    {
        lantananim = GetComponent<Animator>();
        collider = transform.Find("attack").GetComponent<BoxCollider2D>();
        collider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == fireattackTag || collision.collider.tag == specialattackTag)
        {
            lantananim.SetBool("lantanstart", true);
        }
    }

    void Attackstop()
    {
        Destroy(this.gameObject);
    }
    void Attackstart()
    {
        collider.enabled = true;
    }
}
