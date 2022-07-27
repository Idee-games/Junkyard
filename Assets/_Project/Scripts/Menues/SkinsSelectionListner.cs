using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsSelectionListner : MonoBehaviour
{
    public GameObject[] Purchased;
    public GameObject[] prices;
    public Text shopTxt;
    public Text buttonTxt;
    public Text[] btnText;
    public bool purchaseSomething = false;

    public Button[] skinsBuyBtn;
    // Start is called before the first frame update
    private void OnEnable()
    {
        onStart();
        updateTxt();
    }
    void updateTxt()
    {
        shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
    }
    /*void Start()
    {
        shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();  
        onStart();
    }*/
    public void onStart()
    {
        //if (Toolbox.DB.prefs.SkinsUnlocked[0] == true)
        //{
        //    Purchased[0].SetActive(true);
        //    prices[0].SetActive(false);
        //    skinsBuyBtn[0].interactable = false;
        //}

        //if (Toolbox.DB.prefs.SkinsUnlocked[1] == true)
        //{
        //    Purchased[1].SetActive(true);
        //    prices[1].SetActive(false); 
        //    skinsBuyBtn[1].interactable = false;
        //}

        //if (Toolbox.DB.prefs.SkinsUnlocked[2] == true)
        //{
        //    Purchased[2].SetActive(true);
        //    prices[2].SetActive(false);
        //    skinsBuyBtn[2].interactable = false;
        //}
        for (int i = 0; i < Toolbox.DB.prefs.CharactersUnlocked.Length; i++)
        {
            if (Toolbox.DB.prefs.CharactersUnlocked[i] == true)
            {
                Purchased[i].SetActive(true);
                prices[i].SetActive(false);
                skinsBuyBtn[i].interactable = false;
            }
        }
        //if (Toolbox.DB.prefs.CharactersUnlocked[0] == true)
        //{
        //    Purchased[0].SetActive(true);
        //    prices[0].SetActive(false);
        //    skinsBuyBtn[0].interactable = false;
        //}

        //if (Toolbox.DB.prefs.CharactersUnlocked[1] == true)
        //{
        //    Purchased[1].SetActive(true);
        //    prices[1].SetActive(false);
        //    skinsBuyBtn[1].interactable = false;
        //}

        //if (Toolbox.DB.prefs.CharactersUnlocked[2] == true)
        //{
        //    Purchased[2].SetActive(true);
        //    prices[2].SetActive(false);
        //    skinsBuyBtn[2].interactable = false;
        //} 

    }

    // Update is called once per frame
    void Update()
    {

    }
    //public void weaponHandler(int _val)
    //{
    //    switch(_val)
    //    {
    //        case 0:
    //            if (int.Parse(buttonTxt.text) < Toolbox.DB.prefs.GoldCoins)
    //            {
    //                Toolbox.GameplayScript.DeductGoldCoins(int.Parse(buttonTxt.text));
    //                //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt.text);
    //                shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
    //                purchaseSomething = true;
    //                Toolbox.DB.prefs.SkinsUnlocked[0] = true;
    //                prices[0].SetActive(false);
    //                Purchased[0].SetActive(true);
    //                skinsBuyBtn[0].interactable = false;
    //            }
    //            else
    //            {
    //                Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
    //            }
    //            break;
    //        case 1:
    //            if (int.Parse(buttonTxt1.text) < Toolbox.DB.prefs.GoldCoins)
    //            {
    //                Toolbox.GameplayScript.DeductGoldCoins(int.Parse(buttonTxt1.text));
    //                //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt1.text);
    //                shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString(); 
    //                Toolbox.DB.prefs.SkinsUnlocked[1] = true;
    //                purchaseSomething = true;

    //                Purchased[1].SetActive(true);
    //                prices[1].SetActive(false);
    //                skinsBuyBtn[1].interactable = false;
    //            }
    //            else
    //            {
    //                Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
    //            }
    //            break;
    //        case 2:
    //            if (int.Parse(buttonTxt2.text) < Toolbox.DB.prefs.GoldCoins)
    //            {
    //                Toolbox.GameplayScript.DeductGoldCoins(int.Parse(buttonTxt2.text));
    //                shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
    //                //shopTxt.text -= buttonTxt.text;
    //                Toolbox.DB.prefs.SkinsUnlocked[2] = true;
    //                purchaseSomething = true;

    //                Purchased[2].SetActive(true);
    //                prices[2].SetActive(false);
    //                skinsBuyBtn[2].interactable = false;
    //            }
    //            else
    //            {
    //                Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
    //            }
    //            break;
    //    }
    //}
    public void characterHandler(int _value)
    {
       
        if (int.Parse(btnText[_value].text) <= Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[_value].text));
            purchaseSomething = true;
           // Toolbox.DB.prefs.GoldCoins =  int.Parse(btnText[_value].text) - Toolbox.DB.prefs.GoldCoins;
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            
            Toolbox.DB.prefs.CharactersUnlocked[_value] = true;
            Purchased[_value].SetActive(true);
            prices[_value].SetActive(false);
            skinsBuyBtn[_value].interactable = false;
            Toolbox.DB.prefs.LastSelectedPlayerObj = _value;
            OnPressApply(_value);
        }
        else
        {
            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        }

        //switch(_value)
        //{
        //    case 0:
        //        if (int.Parse(btnText[0].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[0].text));
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.GoldCoins -= int.Parse(btnText[0].text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            Toolbox.DB.prefs.CharactersUnlocked[0] = true;
        //            Purchased[0].SetActive(true);
        //            prices[0].SetActive(false);
        //            skinsBuyBtn[0].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 1:
        //        if (int.Parse(btnText[1].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[1].text));
        //           // Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt3.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            Toolbox.DB.prefs.CharactersUnlocked[1] = true;
        //            purchaseSomething = true;
        //            Purchased[4].SetActive(true);
        //            prices[4].SetActive(false);
        //            skinsBuyBtn[4].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 2:
        //        if (int.Parse(btnText[2].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[2].text));
        //            //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
        //            Purchased[5].SetActive(true);
        //            prices[5].SetActive(false);
        //            skinsBuyBtn[5].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 2:
        //        if (int.Parse(btnText[2].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[2].text));
        //            //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
        //            Purchased[5].SetActive(true);
        //            prices[5].SetActive(false);
        //            skinsBuyBtn[5].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 2:
        //        if (int.Parse(btnText[2].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[2].text));
        //            //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
        //            Purchased[5].SetActive(true);
        //            prices[5].SetActive(false);
        //            skinsBuyBtn[5].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 2:
        //        if (int.Parse(btnText[2].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[2].text));
        //            //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
        //            Purchased[5].SetActive(true);
        //            prices[5].SetActive(false);
        //            skinsBuyBtn[5].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //    case 2:
        //        if (int.Parse(btnText[2].text) < Toolbox.DB.prefs.GoldCoins)
        //        {
        //            Toolbox.GameplayScript.DeductGoldCoins(int.Parse(btnText[2].text));
        //            //Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
        //            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        //            //shopTxt.text -= buttonTxt.text;
        //            purchaseSomething = true;
        //            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
        //            Purchased[5].SetActive(true);
        //            prices[5].SetActive(false);
        //            skinsBuyBtn[5].interactable = false;
        //        }
        //        else
        //        {
        //            Toolbox.GameManager.InstantiatePopup_Message("You don't have enough coin");
        //        }
        //        break;
        //}
    }
    public void OnPress_Back()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.buttonPressNo);
        Toolbox.GameplayScript.player.GetComponent<PlayerController>().EnableCharacter(Toolbox.DB.prefs.LastSelectedPlayerObj);
        Destroy(this.gameObject);
    }

    public void OnPressApply(int _value)
    {
        Debug.Log(_value);
        Toolbox.DB.prefs.LastSelectedPlayerObj = _value;
        Toolbox.GameplayScript.player.GetComponent<PlayerController>().EnableCharacter(_value);
    }
}
