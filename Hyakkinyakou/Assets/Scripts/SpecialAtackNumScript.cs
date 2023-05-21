using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAtackNumScript : MonoBehaviour
{
    private Text atacknumText = null;
    private int oldatackNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        atacknumText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldatackNum != GManager.instance.specialatackNum)
        {
            atacknumText.text = GManager.instance.specialatackNum.ToString();
            oldatackNum = GManager.instance.specialatackNum;
        }
    }
}
