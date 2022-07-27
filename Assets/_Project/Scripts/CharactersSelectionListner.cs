using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharactersSelectionListner : MonoBehaviour
{
    public GameObject[] Purchased;
    public Text shopTxt;
    public Text buttonTxt;
    public Text buttonTxt1;
    public Text buttonTxt2;
    public Text buttonTxt3;
    public Text buttonTxt4;
    public Text buttonTxt5;
    public Text buttonTxt6;
    public Text buttonTxt7;
    public Button[] skinsBuyBtn;
    // Start is called before the first frame update
    void Start()
    {
        shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
        Debug.Log(Toolbox.DB.prefs.SkinsUnlocked[1]);
        onstart();
    }
    public void onstart()
    {
        if (Toolbox.DB.prefs.CharactersUnlocked[0] == true)
        {
            Purchased[0].SetActive(true);
            skinsBuyBtn[0].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[1] == true)
        {
            Purchased[1].SetActive(true);
            skinsBuyBtn[1].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[2] == true)
        {
            Purchased[2].SetActive(true);
            skinsBuyBtn[2].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[3] == true)
        {
            Purchased[3].SetActive(true);
            skinsBuyBtn[3].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[4] == true)
        {
            Purchased[4].SetActive(true);
            skinsBuyBtn[4].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[5] == true)
        {
            Purchased[5].SetActive(true);
            skinsBuyBtn[5].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[6] == true)
        {
            Purchased[6].SetActive(true);
            skinsBuyBtn[6].interactable = false;
        }

        if (Toolbox.DB.prefs.CharactersUnlocked[7] == true)
        {
            Purchased[7].SetActive(true);
            skinsBuyBtn[7].interactable = false;
        } 
        
        if (Toolbox.DB.prefs.CharactersUnlocked[8] == true)
        {
            Purchased[8].SetActive(true);
            skinsBuyBtn[8].interactable = false;
        } 
        
        if (Toolbox.DB.prefs.CharactersUnlocked[9] == true)
        {
            Purchased[9].SetActive(true);
            skinsBuyBtn[9].interactable = false;
        } 
        
        if (Toolbox.DB.prefs.CharactersUnlocked[10] == true)
        {
            Purchased[10].SetActive(true);
            skinsBuyBtn[10].interactable = false;
        }
        if (Toolbox.DB.prefs.CharactersUnlocked[11] == true)
        {
            Purchased[11].SetActive(true);
            skinsBuyBtn[11].interactable = false;
        }
        if (Toolbox.DB.prefs.CharactersUnlocked[12] == true)
        {
            Purchased[12].SetActive(true);
            skinsBuyBtn[12].interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPressBuy()
    {
        if (int.Parse(buttonTxt.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[0] = true;
            Purchased[0].SetActive(true);
            skinsBuyBtn[0].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy1()
    {
        if (int.Parse(buttonTxt1.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt1.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[1] = true;
            Purchased[1].SetActive(true);
            skinsBuyBtn[1].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //eckBoughtSkins();
    }
    public void OnPressBuy2()
    {
        if (int.Parse(buttonTxt2.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt2.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[2] = true;
            Purchased[2].SetActive(true);
            skinsBuyBtn[2].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy3()
    {
        if (int.Parse(buttonTxt3.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt3.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[3] = true;
            Purchased[3].SetActive(true);
            skinsBuyBtn[3].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy4()
    {
        if (int.Parse(buttonTxt4.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt4.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[4] = true;
            Purchased[4].SetActive(true);
            skinsBuyBtn[4].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy5()
    {
        if (int.Parse(buttonTxt5.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[5] = true;
            Purchased[5].SetActive(true);
            skinsBuyBtn[5].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy6()
    {
        if (int.Parse(buttonTxt6.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt6.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[6] = true;
            Purchased[6].SetActive(true);
            skinsBuyBtn[6].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    public void OnPressBuy7()
    {
        if (int.Parse(buttonTxt7.text) < Toolbox.DB.prefs.GoldCoins)
        {
            Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt7.text);
            shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
            //shopTxt.text -= buttonTxt.text;
            Toolbox.DB.prefs.CharactersUnlocked[7] = true;
            Purchased[7].SetActive(true);
            skinsBuyBtn[7].interactable = false;
        }
        //Toolbox.DB.prefs.SkinsUnlocked[i] = true;
        //CheckBoughtSkins();
    }
    /*public void CheckBoughtSkins()
    {
        for (int j = 0; j < skinsBuyBtn.Length; j++)
        {
            if(j==0)
            {
                if (int.Parse(buttonTxt.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    //shopTxt.text -= buttonTxt.text;
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);

                }
            }
            else if(j==1)
            {
                if (int.Parse(buttonTxt1.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt1.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 2)
            {
                if (int.Parse(buttonTxt2.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt2.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 3)
            {
                if (int.Parse(buttonTxt3.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt3.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 4)
            {
                if (int.Parse(buttonTxt4.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt4.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 5)
            {
                if (int.Parse(buttonTxt5.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt5.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 6)
            {
                if (int.Parse(buttonTxt6.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt6.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            }
            else if (j == 7)
            {
                if (int.Parse(buttonTxt7.text) < Toolbox.DB.prefs.GoldCoins)
                {
                    Toolbox.DB.prefs.GoldCoins -= int.Parse(buttonTxt7.text);
                    shopTxt.text = Toolbox.DB.prefs.GoldCoins.ToString();
                    Toolbox.DB.prefs.SkinsUnlocked[j] = true;
                    Purchased.SetActive(true);
                }
            } 
            else
            {
                //skinsBuyBtn[j].SetActive(true);
            } 
        }
    }*/
}
