using UnityEngine;

public class LevelsManager : MonoBehaviour
{
    public bool testMode = false;
    public bool testPlayerObj = false;
    public int testPlayerObjVal = 0;
    

    private LevelHandler curLevelHandler;
    [SerializeField] private LevelData curLevelData;

    public LevelData CurLevelData { get => curLevelData; set => curLevelData = value; }
    public LevelHandler CurLevelHandler { get => curLevelHandler; set => curLevelHandler = value; }

    public PileHandler pileHandler;

    private void Start()
    {
        //if (testMode)
            StartLevelHandling();
        
    }

    public void StartLevelHandling() {
        if (Toolbox.DB.prefs.LastSelectedLevel > 9)
        {
            //Arooj
           // Toolbox.DB.prefs.LastSelectedLevel = 9;


        }

        if (testMode)
        {
            curLevelHandler = this.GetComponentInChildren<LevelHandler>();
        }
        else
        {
            InstantiateLevel();
        }

        LevelDataHandling();
        //PlayerDataHandling();
        SpawnPlayer();
        ExtraHandling();

        Toolbox.Soundmanager.PlayBGSound(Toolbox.Soundmanager.gameBG);
        Toolbox.GameManager.Analytics_LevelStart();

    }

    private void InstantiateLevel()
    {
        Time.timeScale = 1f;
        string path = Constants.PrefabFolderPath + Constants.LevelsFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        Toolbox.GameManager.Log("Lvl path = " + path);

        GameObject obj = (GameObject)Instantiate(Resources.Load(path), this.transform);
        
        curLevelHandler = obj.GetComponent<LevelHandler>();

    }

    private void SpawnPlayer()
    {

    }

    private void LevelDataHandling()
    {
        string path;

        if (testMode)
        {
             path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + int.Parse(this.GetComponentInChildren<LevelHandler>().name).ToString() ;
        }
        else
        { 
             path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        }
        
        curLevelData = (LevelData)Resources.Load(path);

        // Toolbox.HUDListner.SetLvlTxt("Level " + (Toolbox.DB.prefs.LastSelectedLevel + 1).ToString());
    }


    public void PlayTutorial() 
    {
        //Toolbox.GameplayScript.GameplayTutorial.SetActive(true);
    }


    private void ExtraHandling()
    {
        //if (curLevelData.envProfile)
        //{
        //    for (int i = 0; i < curLevelData.envProfile.materialChange.Length; i++)
        //    {
        //        curLevelData.envProfile.materialChange[i].mat.SetTexture(curLevelData.envProfile.materialChange[i].fieldName, curLevelData.envProfile.materialChange[i].albedoTex);

        //        if (curLevelData.weather == LevelData.Weather.RAINY)
        //        {
        //            //Toolbox.GameManager.Log("isRaining!");
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_Cutoff", curLevelData.envProfile.materialChange[i].alphaCutout);
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_Metallic", curLevelData.envProfile.materialChange[i].mettalic);
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_SmoothnessTextureChannel", curLevelData.envProfile.materialChange[i].smoothness);
        //        }
        //        else {
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_Cutoff", 0);
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_Metallic", 0);
        //            curLevelData.envProfile.materialChange[i].mat.SetFloat("_SmoothnessTextureChannel", 0);
        //        }
        //    }

        //    if (curLevelData.envProfile.skybox)
        //        Toolbox.GameplayScript.SetSkybox(curLevelData.envProfile.skybox);
        //}

        Toolbox.GameplayScript.EnableEnvHandling(curLevelData.environmentNumber);


        for (int i = 0; i < curLevelData.hasResources.Length; i++)
        {

            Toolbox.HUDListner.EnableResource((int)CurLevelData.hasResources[i]);
            Toolbox.GameplayScript.EnableResource((int)CurLevelData.hasResources[i]);

            if (Toolbox.GameplayScript.levelsManager.CurLevelData.truckOn)
            {
                pileHandler.EnablePileResource((int)Toolbox.GameplayScript.levelsManager.CurLevelData.hasResources[i]);
            }
        }
        if (Toolbox.GameplayScript.levelsManager.CurLevelData.truckOn)
        {
            pileHandler.StockUpLoop();
            pileHandler.truck.SetActive(true);
            pileHandler.truckON = true;
           
        }
        //Toolbox.HUDListner.StartTime(curLevelData.time);

        Toolbox.GameplayScript.player.InitResourcesValOnBack();
    }
}
