using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;

    public int specialatackNum;

    public int stagecount;
    public int nowstage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void fadeanimation()
    {
        Instantiate((GameObject)Resources.Load("Prefab/fadePanel1"), new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity, GameObject.Find("backImage").transform);
    }
}