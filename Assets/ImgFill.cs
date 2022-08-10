using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgFill : MonoBehaviour
{
    Image img;
    float fill;
    // Start is called before the first frame update
    void Start()
    {
       fill =  Toolbox.GameplayScript.levelsManager.CurLevelData.progressPic;
        img = GetComponent<Image>();

      
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = Mathf.MoveTowards(img.fillAmount, fill, 0.2f * Time.deltaTime);
        Debug.Log(img.fillAmount);
    }
}
