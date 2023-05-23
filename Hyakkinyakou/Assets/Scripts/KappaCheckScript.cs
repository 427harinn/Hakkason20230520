using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaCheckScript : MonoBehaviour
{
    private Animator kappaanim = null;
    string catTag = "Cat";
    // Start is called before the first frame update
    void Start()
    {
        kappaanim = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == catTag)
        {
            kappaanim.SetBool("attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == catTag)
        {
            kappaanim.SetBool("attack", false);
        }
    }
}
