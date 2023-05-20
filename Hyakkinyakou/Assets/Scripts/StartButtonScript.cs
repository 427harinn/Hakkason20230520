using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked_startbutton()
    {
        GManager.instance.fadeanimation();
        Invoke("ChangeScene", 2.0f);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("StageSelectScene");
    }
}
