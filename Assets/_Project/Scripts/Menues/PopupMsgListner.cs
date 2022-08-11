using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMsgListner : MonoBehaviour
{
    public Text msgTxt;
    public GameObject unlockBtn; 
    public GameObject Unlock;
    public bool isPopupMsg = false;
    LevelData shineShow;
    public void UpdateMsg(string str) {

        msgTxt.text = str;
    }

    public void OnEnable()
    {
        if(isPopupMsg) Invoke("PauseTime", 1.2f);
    }
    private void Start()
    {
        string path;
        path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        shineShow = (LevelData)Resources.Load(path);
        if (shineShow.progressPic == 1f)
        {
            Unlock.SetActive(true); 
        }
    } 

    public void OnPress_Close() {

        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
        Destroy(this.gameObject);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void OnPress_UnlockMega() {

        OnPress_Close();
    }

    public void OnPress_PrivacyPolicy()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
        Application.OpenURL(Constants.privacyPolicy);
    }

    public void OnPress_AgreeOfConsent()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);

        Toolbox.DB.prefs.FirstRun = false;
        Toolbox.GameManager.LoadScene(Constants.sceneIndex_Menu, false, 0);
        Destroy(this.gameObject);
    }

    public void PauseTime()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
}
