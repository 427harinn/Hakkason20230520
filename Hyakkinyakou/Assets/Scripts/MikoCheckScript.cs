using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MikoCheckScript : MonoBehaviour
{
    private Animator kappaanim = null;
    string catTag = "Cat";

    int count;
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
            if(count == 0)
            {
                Invoke("attack", 0.5f);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == catTag)
        {
            kappaanim.SetBool("attack", false);
        }
    }

    void attack()
    {
        count++;
        Vector3 instantiatepos = this.gameObject.transform.position;
        int scale = 0;
        if (this.gameObject.transform.localScale.x == 1)
        {
            scale = 1;
            instantiatepos.x -= 1.3f;
        }
        else
        {
            scale = -1;
            instantiatepos.x += 1.3f;
        }
        GameObject obj = Instantiate((GameObject)Resources.Load("Prefab/mikoattackImage"), instantiatepos, Quaternion.identity, GameObject.Find("backImage").transform);
        obj.transform.localScale = new Vector3(scale, 1, 1);
    }
}
