using UnityEngine;
/// <summary>
/// This script will hold everything that is needed to be global only in Game scene
/// </summary>
public class GameplayScript : MonoBehaviour {
    public bool testMode = true;
    public bool isLevelsScene = true;
    public GameObject playerController;
    public GameObject playerControllerTransformer;
    public bool levelCompleted = false;
    public bool levelFailed = false;
    public int counterJunk;
    public PlayerController player;
    public Cinemachine.CinemachineBrain camBrain;
    public Cinemachine.CinemachineVirtualCamera playerCamMachine;
    public CinemachineShake camShake;
    public GameObject [] environments;
    //public GameObject [] resourceObjects;
   // public StructureHandler buildStructureHandler;
   // public GameObject traffic;

    public float finalDecisionDelay = 0;

    [HideInInspector]
    private int levelCompleteTime = 0;

    private bool doubleRewardBought = false;
    
    [Header("Components")]
    public AudioListener camListner;
    public bool canShowReviewMenu = false;
    public LevelsManager levelsManager;
   // public DisasterHandler disasterHandler;

    [Header("Colors")]
    public Color[] randomColors;


    [Header("Truck")]
    public bool truckON;
    private LevelData curLevelData;
    //screenshot requirement
    int screenShotPicName = 0;

    public int LevelCompleteTime { get => levelCompleteTime; set => levelCompleteTime = value; }
    public bool DoubleRewardBought { get => doubleRewardBought; set => doubleRewardBought = value; }

    void Awake() {
        if (Toolbox.DB.prefs.LastSelectedLevel > 14)
        {

            Toolbox.DB.prefs.LastSelectedLevel = 0;


        }
        string path;
        path = Constants.PrefabFolderPath + Constants.LevelsScriptablesFolderPath + Toolbox.DB.prefs.LastSelectedMode.ToString() + "/" + Toolbox.DB.prefs.LastSelectedLevel.ToString();
        curLevelData = (LevelData)Resources.Load(path);
        //if (!FindObjectOfType<Toolbox>())
        //    Instantiate(Resources.Load("Toolbox"), Vector3.zero, Quaternion.identity);
        if (curLevelData.isTransformer)
        {
            playerControllerTransformer.SetActive(true);
            playerCamMachine.Follow = playerControllerTransformer.transform;
        }
        else 
        {
            playerController.SetActive(true);
            playerCamMachine.Follow = playerController.transform;
        }
        Toolbox.Set_GameplayScript(this.GetComponent<GameplayScript>());
    }

    void Start()
    {
        levelCompleted = false;
      //  Toolbox.DB.prefs.ResetResources();

        AdsManager.instance.RequestAd(AdsManager.AdType.INTERSTITIAL);
        AdsManager.instance.RequestAd(AdsManager.AdType.REWARDED);

        //EnableEnvHandling();
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.P))
        {
            string name = "Pic_" + screenShotPicName + ".png";
            Toolbox.GameManager.Log("Screenshot Taked!");
            ScreenCapture.CaptureScreenshot(name);
            screenShotPicName++;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
          //  OnStormHandling();
        }
#endif
    }

    public void StartGame()
    {
        Toolbox.HUDListner.EnableHUD();
        Toolbox.HUDListner.StartTime(levelsManager.CurLevelData.time);
        Debug.Log(levelsManager.CurLevelData.time);
        Toolbox.Soundmanager.PlayBGSound(Toolbox.Soundmanager.gameBG);
    }

    public void EnableEnvHandling(int _val)
    {
        environments[_val].gameObject.SetActive(true);
       
    }

    public void IncrementGoldCoins(int cost)
    {
        Toolbox.DB.prefs.GoldCoins += cost;
        Toolbox.GameManager.Instantiate_RewardAnim();

        if (FindObjectOfType<MainMenuListner>())
        {
            FindObjectOfType<MainMenuListner>().UpdateTxt();
        }
    }

    public void DeductGoldCoins(int cost) {

        Toolbox.DB.prefs.GoldCoins -= cost;

        if (FindObjectOfType<MainMenuListner>()) {

            FindObjectOfType<MainMenuListner>().UpdateTxt();
        }
    }

    public void InitEffectOnpoint(GameObject effect, Vector3 pos) {

        Instantiate(effect, pos, Quaternion.identity);
    }
    
    public Color Get_RandomColor() {

        return randomColors[Random.Range(0, randomColors.Length - 1)];
    }

    public void LevelCompleteHandling() {

        if (levelFailed || levelCompleted)
            return;

        levelCompleted = true;

        Toolbox.GameManager.Instantiate_LevelComplete(finalDecisionDelay);
        Toolbox.HUDListner.DisableHUD();

    }

    public void LevelFailHandling() {

        if (levelFailed || levelCompleted)
            return;

        levelFailed = true;

        Toolbox.GameManager.Instantiate_LevelFail(finalDecisionDelay);
        Toolbox.HUDListner.DisableHUD();
    }

    public void SetSkybox(Material _mat) { 
    
        RenderSettings.skybox = _mat;
    }

    //public void EnableResource(int _val) {

    //    resourceObjects[_val].SetActive(true);
    //}

    //public void OnStormHandling() {

    //    playerCamMachine.Follow = levelsManager.CurLevelHandler.houseObj.transform;
    //    Toolbox.HUDListner.DisableHUD();
    //    player.gameObject.SetActive(false);
    //    Toolbox.HUDListner.startTime = false;

    //    buildStructureHandler.DisableAllSpecs();

    //    Toolbox.GameManager.InstantiatePopup_MessageBar( levelsManager.CurLevelData.disaster.ToString() + " IS COMING");

    //    Invoke("InitDisaster", 3);
    //    Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.siren);

    //}

    public void FinalDecisionHandling(float _delay) {

        finalDecisionDelay = _delay;

        if (Toolbox.HUDListner.progress >= 0.5f)
        {
            LevelCompleteHandling();
        }
        else
        {
            LevelFailHandling();
        }
    }

    //void InitDisaster() {

    //    StopTraffic();
    //    Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.panicSound);
    //    Time.timeScale = 1.1f;

    //    switch (levelsManager.CurLevelData.disaster)
    //    {
    //        case DisasterType.EARTHQUAKE:
    //            disasterHandler.EarthQuakes();
    //            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.EarthQuake);

    //            break;
    //        case DisasterType.STORM:
    //            disasterHandler.Storm();
    //            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Storm);

    //            break;
    //        case DisasterType.VOLCANO:
    //            disasterHandler.Volcano();
    //            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.fire);

    //            break;
    //        case DisasterType.TSUNAMI:
    //            disasterHandler.Tsunami();
    //            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Storm);

    //            break;
    //        case DisasterType.TORNADO:
    //            disasterHandler.Tornado();
    //            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Tornado);

    //            break;
    //        default:
    //            break;
    //    }

    //    //buildStructureHandler.InitDistruction();
    //}

    //public void StartBuildingDistruction() {

    //    //Debug.LogError("Destruction");
    //    buildStructureHandler.InitDistruction();
    //    Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.vehicleExplosion);

    //}

    //public void StopTraffic() {

    //    foreach (var item in traffic.GetComponentsInChildren<VehicleHandler>())
    //    {
    //        item.Stop();
    //    }
    //}
}
