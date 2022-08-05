using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgFill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       GetComponent<Image>().fillAmount =  Toolbox.GameplayScript.levelsManager.CurLevelData.progressPic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
