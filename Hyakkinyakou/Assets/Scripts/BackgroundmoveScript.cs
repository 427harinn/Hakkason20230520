using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundmoveScript : MonoBehaviour
{
    public float MoveSpeed = -0.01f;
    private Vector3 StartPosition;
    [SerializeField] GameObject fadePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(MoveSpeed, 0, 0, Space.World);
    }

    public void FadeActive()
    {
        fadePrefab.SetActive(true);
    }
}
