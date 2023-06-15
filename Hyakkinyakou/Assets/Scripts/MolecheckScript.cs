using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolecheckScript : MonoBehaviour
{
    private Animator moleanim = null;

    string catTag = "Cat";
    int count = 0;


    int xVector = -1;
    // Start is called before the first frame update
    void Start()
    {
        moleanim = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == catTag && count == 0)
        {
            count++;
            moleanim.SetBool("attack", true);
        }
    }
}
