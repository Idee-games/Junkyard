using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileHandler : MonoBehaviour
{
    public bool truckFinished = false;
    public bool toGive = false;
    public GameObject truck;
    public Transform truckSpot;
    public int count = 0;
    int count2 = 0;
    bool checkIfEmpty = false;
    public int amountSteel;
    public int amountCement;
    public int amountBrick;
    public int amountStone;
    public int amountWoodLog;

    public bool steelResource;
    public bool cementResource;
    public bool brickResource;
    public bool stoneResource;
    public bool logResource;

    public GameObject woodPile;
    public GameObject stonePile;
    public GameObject brickPile;
    public GameObject steelPile;
    public GameObject cementPile;


    public bool truckON = false;

    public int amountofSteelRecord;
    public int amountofCementRecord;
    public int amountofStoneRecord;
    public int amountofBrickRecord;
    public int amountofLogRecord;

    private void Start()
    {
        count =0;
       
    }
    // Start is called before the first frame update
    void Awake()
    {

       
       
    }
   
    // Update is called once per frame
    void FixedUpdate()
    {
        if(truck.activeSelf)
        {
            toGive = false;
        }
        else
        {
            toGive = true;
        }
       
        if(amountSteel < truck.GetComponent<TruckHandler>().amountSteel || amountCement < truck.GetComponent<TruckHandler>().amountCement || amountBrick < truck.GetComponent<TruckHandler>().amountBrick || amountStone < truck.GetComponent<TruckHandler>().amountStone || amountWoodLog < truck.GetComponent<TruckHandler>().amountWoodLog )
        {
            
            if (checkIfEmpty)
            ReActiveTruck();
           
        }






    }

    public void ReActiveTruck()
    {
       
        checkIfEmpty = false;
        

    }
    IEnumerator Timerr()
    {
        yield return new WaitForSeconds(0.1f);
        truck.SetActive(true);
        StockUpLoop();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Truck"))
        {
           truckFinished = true;
            truck.GetComponent<TruckHandler>().steelRod.SetActive(false);
            truck.GetComponent<TruckHandler>().cementSack.SetActive(false);
            truck.GetComponent<TruckHandler>().brickStack.SetActive(false);
            truck.GetComponent<TruckHandler>().stoneStack.SetActive(false);
            truck.GetComponent<TruckHandler>().logStack.SetActive(false);
            if (amountSteel >= truck.GetComponent<TruckHandler>().amountSteel && amountCement >= truck.GetComponent<TruckHandler>().amountCement && amountBrick >= truck.GetComponent<TruckHandler>().amountBrick && amountStone >= truck.GetComponent<TruckHandler>().amountStone && amountWoodLog >= truck.GetComponent<TruckHandler>().amountWoodLog)
            {
                truck.transform.position = truckSpot.transform.position;
                truck.SetActive(false);
                checkIfEmpty = true;
            }
            else
            {
               
                truck.SetActive(false);
                truck.transform.position = truckSpot.transform.position;
                StockUpLoop();
               
            }
        }
    }
    //public void Stockup2()
    //{
    //    if(amountSteel >= truck.GetComponent<TruckHandler>().amountSteel)
    //    {
    //        truck.GetComponent<TruckHandler>().hasSteel = false;
    //    }
    //    else
    //    {
    //        truck.GetComponent<TruckHandler>().hasSteel = true;
    //    }
    //    if (amountCement >= truck.GetComponent<TruckHandler>().amountCement)
    //    {
    //        truck.GetComponent<TruckHandler>().hasCement = false;
    //    }
    //    else
    //    {
    //        truck.GetComponent<TruckHandler>().hasCement = true;
    //    }
    //    if (amountBrick >= truck.GetComponent<TruckHandler>().amountBrick)
    //    {
    //        truck.GetComponent<TruckHandler>().hasBrick = false;
    //    }
    //    else
    //    {
    //        truck.GetComponent<TruckHandler>().hasBrick = true;
    //    }
    //    if (amountStone >= truck.GetComponent<TruckHandler>().amountStone)
    //    {
    //        truck.GetComponent<TruckHandler>().hasStone = false;
    //    }
    //    else
    //    {
    //        truck.GetComponent<TruckHandler>().hasStone = true;
    //    }
    //    if (amountWoodLog >= truck.GetComponent<TruckHandler>().amountWoodLog)
    //    {
    //        truck.GetComponent<TruckHandler>().hasWoodLog = false;
    //    }
    //    else
    //    {
    //        truck.GetComponent<TruckHandler>().hasWoodLog = true;
    //    }
    //    truck.SetActive(true);
    //}
    public void StockUpLoop()
    {
       
        // CheckIfResourceIsRequired();
        truck.GetComponent<TruckHandler>().hasSteel = false;
        truck.GetComponent<TruckHandler>().hasCement = false;
        truck.GetComponent<TruckHandler>().hasBrick = false;
        truck.GetComponent<TruckHandler>().hasStone = false;
        truck.GetComponent<TruckHandler>().hasWoodLog = false;
        if (amountSteel < truck.GetComponent<TruckHandler>().amountSteel && steelResource )
        {
           
                truck.GetComponent<TruckHandler>().hasSteel = true;
            StartCoroutine(Timerr());
            // truck.SetActive(true);
        }
        
        else if(amountCement < truck.GetComponent<TruckHandler>().amountCement && cementResource)
        {
            
                truck.GetComponent<TruckHandler>().hasCement = true;
            StartCoroutine(Timerr());
            // truck.SetActive(true);
        }
        
       else if ( amountBrick < truck.GetComponent<TruckHandler>().amountBrick && brickResource)
        {
            
                truck.GetComponent<TruckHandler>().hasBrick = true;
            StartCoroutine(Timerr());
            //  truck.SetActive(true);
        }
        
      else  if ( amountStone < truck.GetComponent<TruckHandler>().amountStone && stoneResource)
        {
            
               truck.GetComponent<TruckHandler>().hasStone = true;
            StartCoroutine(Timerr());
            // truck.SetActive(true);
        }
       
       else if ( amountWoodLog < truck.GetComponent<TruckHandler>().amountWoodLog && logResource)
        {
           
                truck.GetComponent<TruckHandler>().hasWoodLog = true;
            StartCoroutine(Timerr());
            //   truck.SetActive(true);
        }
        //else
        //{
            
        //}

        //if (count == 4)
        //{
        //    count = 0;
        //}
        //else
        //{
        //    count++;
        //}





    }

    public bool CheckifStock()
    {
        if (truck.GetComponent<TruckHandler>().hasSteel)
        {
            if (amountofSteelRecord >= truck.GetComponent<TruckHandler>().amountSteel && steelResource)
            {
            //    truck.GetComponent<TruckHandler>().steelRod.SetActive(false);
                return true;
            }
        }
        if (truck.GetComponent<TruckHandler>().hasCement)
        {
            if (amountofCementRecord >= truck.GetComponent<TruckHandler>().amountCement && cementResource)
            {
            //    truck.GetComponent<TruckHandler>().cementSack.SetActive(false);
                return true;
            }
        }
        if (truck.GetComponent<TruckHandler>().hasBrick)
        {
            if (amountofBrickRecord >= truck.GetComponent<TruckHandler>().amountBrick && brickResource)
            {
             //   truck.GetComponent<TruckHandler>().brickStack.SetActive(false);
                return true;
            }
        }
        if (truck.GetComponent<TruckHandler>().hasStone)
        {
            if (amountofStoneRecord >= truck.GetComponent<TruckHandler>().amountStone && stoneResource)
            {
            //    truck.GetComponent<TruckHandler>().stoneStack.SetActive(false);
                return true;
            }
        }
        if (truck.GetComponent<TruckHandler>().hasWoodLog)
        {
            if (amountofLogRecord >= truck.GetComponent<TruckHandler>().amountWoodLog && logResource)
            {
            //    truck.GetComponent<TruckHandler>().logStack.SetActive(false);
                return true;
            }
        }

        return false;
    }


    public void CheckIfResourceIsRequired()
    {
        
        for (int i = 0; i < Toolbox.GameplayScript.levelsManager.CurLevelData.hasResources.Length; i++)
        {
            EnablePileResource((int)Toolbox.GameplayScript.levelsManager.CurLevelData.hasResources[i]);

        }

    }


    public void EnablePileResource(int val)
    {
        if(val == 0)
        {
            logResource = true;
            woodPile.SetActive(true);
        }
        if(val == 1)
        {
            stoneResource = true;
            stonePile.SetActive(true);
        }
        if(val == 3)
        {
            brickResource = true;
            brickPile.SetActive(true);
        }
        if(val == 5)
        {
            cementResource = true;
            cementPile.SetActive(true);
        }    
        if(val == 7)
        {
            steelResource = true;
            steelPile.SetActive(true);
        }
    }

    public void ResourceZero(int val)
    {
        if(val == 0)
        { 
            amountWoodLog--; 
        }
        if (val == 1)
        { 
            amountStone--; 
        }
        if (val == 3)
        {
            amountBrick--;
        }
        if (val == 5)
        {
            amountCement--;
        }
        if (val == 7)
        {
            amountSteel--;
        }
    }

}
