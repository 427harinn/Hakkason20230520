using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelectScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject irainin_stage2;
    [SerializeField] GameObject stage2button;

    public Image stage2image;
    private Sprite stage2sprite;
    void Start()
    {
        if(GManager.instance.stagecount >= 1)
        {
            irainin_stage2.SetActive(true);
            stage2sprite = Resources.Load<Sprite>("UI/map_kisetu");
            stage2image = stage2button.GetComponent<Image>();
            stage2image.sprite = stage2sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
