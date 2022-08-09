using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : MonoBehaviour
{
    int magnetPower;
    private LevelData curLevelData;
    public GameObject trigger;
    public Animator anim;
    public bool magnetOn = true;
    // Start is called before the first frame update
    void Start()
    {
        string path;
        path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        curLevelData = (LevelData)Resources.Load(path);
        magnetPower = curLevelData.magnetPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > magnetPower)
        {
            anim.transform.parent.gameObject.SetActive(true);
            anim.SetBool("isEmpty", false);
            trigger.SetActive(false);
        }
    }
}
