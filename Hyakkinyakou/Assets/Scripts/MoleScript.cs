using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleScript : MonoBehaviour
{
    
    private BoxCollider2D collider = null;


    bool moveflag;

    string catTag = "Cat";
    // Start is called before the first frame update
    void Start()
    {
        collider = this.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(moveflag)
        {
            Transform myTransform = this.transform;

            Vector3 worldPos = myTransform.position;

            worldPos.x -= 0.08f;

            myTransform.position = worldPos; 
        }
    }

    

    void Attackstop()
    {
        collider.enabled = false;
    }
    void Attackstart()
    {
        moveflag = false;
        collider.enabled = true;
    }

    void Movestart()
    {
        moveflag = true;
    }
}
