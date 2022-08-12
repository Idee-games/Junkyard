using UnityEngine;

public static class Constants{

#if UNITY_ANDROID

    public const string moreGamesLink = "";
    public const string appLink = "https://play.google.com/store/apps/details?id=com.mvgames.mega.ramps.extreme.race";

#elif UNITY_IOS
    public const string moreGamesLink = "https://apps.apple.com/pk/developer/muhammad-salman-gurmani/id1549650722";
    public const string appLink = "https://apps.apple.com/pk/app/id1577175721";

#endif


    public const string privacyPolicy = "https://docs.google.com/document/d/1Gf1rEWPgCMXkmyJzdQcoTZyyWAVbtbEW/edit";
    public const string fb = "";

    public const string serverPrefsLink = "";

    public const int iAd_SceneID = 0;

    public const int sceneIndex_Menu = 1;
    public const int sceneIndex_Game_1 = 1;
    public const int sceneIndex_Game_2 = 1;
    public const int sceneIndex_Game_3 = 1;
    public const int sceneIndex_Game_4 = 1;

    public const int maxLevels = 200;
    public const int maxPlayerObjects = 9;
    public const int maxPlayerUpgradeLevel = 2;

    public const int playerUpgradeCost = 1000;
    public const int playerPaintCost = 500;

    public static readonly float [] maxSpecValue = { 500, 550, 90000, 500 };

    public static readonly int[] maxLevelsOfMode = { 10, 10, 10, 10 };


    #region AdMob Ids

#if UNITY_ANDROID
    public const string admobId_Banner = "ca-app-pub-8238060461072991/1613341018";
    public const string admobId_Interstitial = "ca-app-pub-8238060461072991/7408593170";
    public const string admobId_RewardedVid = "ca-app-pub-8238060461072991/3588767667";
    public const string admobId_Native = "ca-app-pub-8238060461072991/8175321538";

    public const string unityId_Appkey = "4882537";
    public const string unityId_IADkey = "Interstitial_Android";
    public const string unityId_RADkey = "Rewarded_Android";

#elif UNITY_IOS
    public const string unityId_Appkey = "4882536";
    public const string unityId_IADkey = "Interstitial_iOS";
    public const string unityId_RADkey = "Rewarded_iOS";
    
    public const string admobId_Banner = "ca-app-pub-9544941219013764/7034425799";
    public const string admobId_Interstitial = "ca-app-pub-9544941219013764/7824956807";
    public const string admobId_RewardedVid = "ca-app-pub-9544941219013764/6540629449";
    public const string admobId_Native = "";

#endif




    //TestID
    //public const string admobId_Banner = "ca-app-pub-3940256099942544/6300978111";
    //public const string admobId_Interstitial = "ca-app-pub-3940256099942544/1033173712";
    //public const string admobId_RewardedVid = "ca-app-pub-3940256099942544/5224354917";
    //public const string admobId_Native = "ca-app-pub-3940256099942544/2247696110";

    #endregion

    #region InApp

#if UNITY_ANDROID

    public const string coins_1 = "pack_1";
    public const string coins_2 = "pack_2";
    public const string coins_3 = "pack_3";
    public const string coins_4 = "pack_4";
    public const string coins_5 = "pack_5";
    public const string unlockPlayerObj = "unlock_all_playerobj";
    public const string unlockLevels = "unlock_all_levels";
    public const string noAds = "noads";

#elif UNITY_IOS

    public const string coins_1 = "	com.rivalwheels.Taxisim.inapppurchase.economypack";
    public const string coins_2 = "pack_2";
    public const string unlockPlayerObj = "com.rivalwheels.Taxisim.InAppPurchase.BuyAllCar";
    public const string unlockLevels = "com.rivalwheels.Inapppurchase.UnlockAllLevels";
    public const string noAds = "com.rivalwheels.Taxisim.InAppPurchase.RemoveAllAds";

#endif

    #endregion

    #region ResourcesLinks

    public const string menuFolderPath = "Menues/";
    public const string PrefabFolderPath = "Prefabs/";
    public const string LevelsFolderPath = "Levels/";
    public const string LevelsScriptablesFolderPath = "LevelsScriptables/";
    public const string PlayerFolderPath = "PlayerObj/";
    public const string PlayerScriptablesFolderPath = "PlayerObjScriptables/";

    #endregion
}
