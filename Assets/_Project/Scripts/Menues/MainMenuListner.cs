using UnityEngine;
using UnityEngine.UI;

public class MainMenuListner : MonoBehaviour {

	public Text goldTxt;
	public Text lvlTxt;
	public GameObject noAdsBtn;
    private void OnEnable()
    {
		UpdateTxt();

		//AdsManager.instance.HideBannerAd();
		PurchaseCheck();
	}

    private void Start()
    {
		Toolbox.HUDListner.DisableHUD();

	}
	public void PurchaseCheck() {

		if (Toolbox.DB.prefs.NoAdsPurchased)
			noAdsBtn.SetActive(false);
	}

    public void UpdateTxt(){

		lvlTxt.text = (Toolbox.DB.prefs.LastSelectedLevel + 1).ToString();
		goldTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();

	}


    ////	public void OnPress_Shop()
    //	{
    //		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
    //		Toolbox.GameManager.Instantiate_Shop();
    //	}

    public void OnPress_Settings()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
		Toolbox.GameManager.Instantiate_SettingsMenu();	
	}
	public void OnPress_Store()
    {
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
		Toolbox.GameManager.Instantiate_Shop();
	}

	public void OnPress_Fb()
	{
		Application.OpenURL(Constants.fb);
	}

	public void OnPress_RateUs()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
		Application.OpenURL(Constants.appLink);
	}
	public void OnPress_RemoveAds()
	{
		//Toolbox.InAppHandler.BuyProductID(Constants.noAds);
		IAPManager.instance.BuyIAP();
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
	}
	public void OnPress_DailyReward()
    {
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
		Toolbox.GameManager.Instantiate_DailyRewardMenu();

	}
	public void OnPress_MoreGames()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
		Application.OpenURL(Constants.moreGamesLink);
	}

	public void OnPress_Back()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressNo);
		Toolbox.MenuHandler.Show_PrevUI();
	}
	public void OnPress_Play()
    {
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
		//Toolbox.GameManager.OnPlay_Pressed();
		//Toolbox.HUDListner.EnableHUD();
		Toolbox.GameplayScript.StartGame();
		Destroy(gameObject);
    }

    public void OnPress_Next()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
		Toolbox.MenuHandler.Show_NextUI();
	}
	public void OnPress_StoreSkin()
    {
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
		Toolbox.GameManager.Instantiate_StoreSkin();
	}
	public void OnPress_StoreCars()
	{
		Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressYes);
		Toolbox.GameManager.Instantiate_StoreCars();
	}
	//public void OnPress_DailReward()
	//   {
	//	Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.Select);
	//	Toolbox.GameManager.Instantiate_DailyRewardMenu();
	//}

}
