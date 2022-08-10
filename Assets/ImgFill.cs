using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImgFill : MonoBehaviour
{
    private LevelData curLevelData;
    public Sprite[] imgs;
    public Sprite[] imgsBG;

    public Image imgforthere;
    public Image imgforthereBG;
    Image img;
    float fill;
    // Start is called before the first frame update
    void Start()
    {
        string path;
        path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        curLevelData = (LevelData)Resources.Load(path);


        imgforthere.sprite = imgs[curLevelData.transformerIMGIndex];
        imgforthereBG.sprite = imgsBG[curLevelData.transformerIMGIndex];



        fill =  Toolbox.GameplayScript.levelsManager.CurLevelData.progressPic;
        img = imgforthere;

      
    }

    // Update is called once per frame
    void Update()
    {
        img.fillAmount = Mathf.MoveTowards(img.fillAmount, fill, 0.2f * Time.deltaTime);
        Debug.Log(img.fillAmount);
    }
}
