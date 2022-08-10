using System;
using UnityEngine;
using UnityEngine.UI;

public class HUDListner : MonoBehaviour {

    public Text timeTxt;

    public GameObject uiParent;
    public RectTransform resourcesParent;
    private int resourceIndex = 0;
    public Image progressbar;
    [HideInInspector]public float progress;
    [Tooltip("Should be in the order of resources")]
    //public Text[] resourcesTxts;

    //public RectTransform [] resourcePosition;
    float reportTime = 10;

    public bool startTime { get; set; }
    public float tempTime { get; private set; }

    void Awake() {
        
        Toolbox.Set_HudListner(this.GetComponent<HUDListner>());
        //AdsManager.instance.RequestBannerWithSpecs( Tapdaq.TDMBannerSize.TDMBannerStandard, Tapdaq.TDBannerPosition.Top);
    }

    public void DisableHUD() 
    {        
        uiParent.SetActive(false);
    }
    public void OnPress_Settings()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
        Toolbox.GameManager.Instantiate_SettingsMenu();
    }
    public void EnableHUD()
    {
        uiParent.SetActive(true);
    }

    private void Update()
    {
        HandleTime();
    }

    public void StartTime(float _val) {

        tempTime = _val;
        startTime = true;
    }

    private void HandleTime()
    {
      
        if (startTime)
        {
            reportTime -= Time.deltaTime;
            
            tempTime -= Time.deltaTime;
            timeTxt.transform.parent.gameObject.SetActive(true);
            int roundedSec = Mathf.RoundToInt(tempTime);
            int min = roundedSec / 60;
            int seconds = roundedSec - (min * 60);

            timeTxt.text = String.Format("{0:D2} : {1:D2}", min, seconds);
            
            //Debug.LogError("roundedSec = " + roundedSec);

            //if (reportTime <= 0) {
            //    if (Toolbox.DB.prefs.LastSelectedLevel == 10 || Toolbox.DB.prefs.LastSelectedLevel == 11 || Toolbox.DB.prefs.LastSelectedLevel == 12)
            //    {
            //        reportTime = 25;
            //    }
            //    else
            //    {
            //        Toolbox.GameManager.InstantiatePopup_MessageBar("Disaster is coming in " + roundedSec + " seconds.");
            //        reportTime = 25;
            //    }
                    
            //}

            if (tempTime <= 0)
            {
                startTime = false;
                // Toolbox.GameManager.Instantiate_LevelComplete(0);



                if(Toolbox.GameplayScript.levelsManager.CurLevelData.isTransformer)
                {
                    Toolbox.GameplayScript.LevelFailHandling();
                }
                else
                {
                    Toolbox.GameplayScript.FinalDecisionHandling(1f);
                }
              




            }
        }
    }

   

   

    public void Press_Pause() {

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
        Toolbox.GameManager.Instantiate_PauseMenu();
    }

    public void Press_Camera()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
    }
    public void Press_ControlChange()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
    }

    public void Press_Settings()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);

        Toolbox.GameManager.Instantiate_SettingsMenu();
    }

    public void SetProgressBarFill(float _val) {
        //Debug.LogError("Fill = " + _val);
        progress = _val;
        progressbar.fillAmount = _val;
    }

}
