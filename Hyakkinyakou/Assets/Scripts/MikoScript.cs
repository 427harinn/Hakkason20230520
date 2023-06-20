using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoScript : MonoBehaviour
{
    private string fireattackTag = "FireAttack";
    private string specialattackTag = "SpecialAttack";

    public bool animationflag;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == fireattackTag || collision.collider.tag == specialattackTag)
        {
            Destroy(this.gameObject);
        }
    }
}
