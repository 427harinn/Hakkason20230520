using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClicked_1stbutton()
    {
        GManager.instance.fadeanimation();
        Invoke("ChangeScene1st", 1.5f);
    }

    public void onClicked_2ndbutton()
    {
        if(GManager.instance.stagecount >= 1)
        {
            GManager.instance.fadeanimation();
            Invoke("ChangeScene2nd", 1.5f);
        }
    }
    void ChangeScene1st()
    {
        SceneManager.LoadScene("1ststageScene");
    }

    void ChangeScene2nd()
    {
        SceneManager.LoadScene("2ndstageScene");
    }

}
