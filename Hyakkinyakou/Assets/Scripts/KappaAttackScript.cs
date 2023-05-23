using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KappaAttackScript : MonoBehaviour
{
    [Header("移動速度")] public float speed;
    private Rigidbody2D rb = null;

    int xVector;

    public KappaScript kappascript;
    bool animationflag = false;

    Vector3 initPosi; //元の座標
    Transform myTransform ;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initPosi = this.gameObject.transform.position;
        myTransform = this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        animationflag = kappascript.animationflag;
        Debug.Log(animationflag);
        if (animationflag)
        {
            Transform myTransform = this.transform;

            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x -= 0.02f;    // x座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
        } else
        {
            myTransform.position = transform.parent.gameObject.transform.position;

        }
    }


}
