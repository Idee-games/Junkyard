using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckHandler : MonoBehaviour
{
    public PileHandler pilehandler;
    
    public ContainerHandler steelContainer;
    public ContainerHandler cementContainer;
    public ContainerHandler brickContainer;
    public ContainerHandler stoneContainer;
    public ContainerHandler woodContainer;


    public Transform[] materialArray;

    public int amountSteel;
    public int amountCement;
    public int amountBrick;
    public int amountStone;
    public int amountWoodLog;


    public int counter2 = 0;
    public GameObject steelRodOBJ;
    public GameObject cementOBJ;
    public GameObject brickOBJ;
    public GameObject stoneOBJ;
    public GameObject woodOBJ;
    
    public Transform[] pointofPileSteel;
    public Transform[] pointofPileSteelPlace;
    
    public Transform[] pointofPileCement;
    public Transform[] pointofPileCementPlace;
    
    public Transform[] pointofPileBrick;
    public Transform[] pointofPileBrickPlace;

    public Transform[] pointofPileStone;
    public Transform[] pointofPileStonePlace;

    public Transform[] pointofPileLog;
    public Transform[] pointofPileLogPlace;
    
    public GameObject steelRod;
    public GameObject cementSack;
    public GameObject brickStack;
    public GameObject stoneStack;
    public GameObject logStack;
    
    public float speed = 5f;
    public Transform[] pointsToStop;
    public bool hasWoodLog;
    public bool hasStone;
    public bool hasBrick;
    public bool hasSteel;
    public bool hasCement;
   public bool isSteel = false;
    public bool isCement = false;
    public bool isStone = false;
    public bool isBrick = false;
    public bool isLog = false;
    GameObject containerTEMP;
    // Start is called before the first frame update
    private void Start()
    {
      
    }
    void OnEnable()
    {
        pilehandler.amountofSteelRecord = pilehandler.amountSteel;
        pilehandler.amountofCementRecord = pilehandler.amountCement;
        pilehandler.amountofStoneRecord = pilehandler.amountStone;
        pilehandler.amountofBrickRecord = pilehandler.amountBrick;
        pilehandler.amountofLogRecord = pilehandler.amountWoodLog;
        TruckMovementCheck();
        StockUp();
    }
    public void StockUp()
    {
        counter2 = 0;
    }

    public void StockOnPileSteel()
    {
      //  pointofPileSteel[0].GetComponent<MoveResouce>().enabled = true;

        

        pointofPileSteel[0].GetComponent<MoveResouce>().enabled = true;

    }
    public void StoneStockup()
    {
       
        pointofPileStone[0].GetComponent<MoveResouce>().enabled = true;
    }
    public void CementStockup()
    {
        pointofPileCement[0].GetComponent<MoveResouce>().enabled = true;
    }
    
    public void BrickStockup()
    {
        pointofPileBrick[0].GetComponent<MoveResouce>().enabled = true;
    }
    public void LogStockup()
    {
        pointofPileLog[0].GetComponent<MoveResouce>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        
     
    }
    public void TruckMovementCheck()
    {
        if (hasSteel)
        {
            steelRod.gameObject.SetActive(true);
            for (int i = 0; i < amountSteel; i++)
            {
                containerTEMP = Instantiate(steelRodOBJ, pointofPileSteelPlace[i].position, pointofPileSteelPlace[i].rotation, steelRod.transform);
                pointofPileSteel[i] = containerTEMP.transform;

            }
            
           // transform.GetComponent<Animator>().SetBool("hasSteel", true);
            pointsToStop[4].gameObject.SetActive(true);
        //    Invoke("DoneResourcing1", 5f);
        }
        if (hasCement)
        {
            cementSack.gameObject.SetActive(true);


            for (int i = 0; i < amountCement; i++)
            {
                containerTEMP = Instantiate(cementOBJ, pointofPileCementPlace[i].position, pointofPileCementPlace[i].rotation, cementSack.transform);
                pointofPileCement[i] = containerTEMP.transform;

            }

            // transform.GetComponent<Animator>().SetBool("hasCement", true);
            pointsToStop[3].gameObject.SetActive(true);
            //  Invoke("DoneResourcing2", 5f);
        }
        if (hasBrick)
        {
            brickStack.gameObject.SetActive(true);

            for (int i = 0; i < amountBrick; i++)
            {
                containerTEMP = Instantiate(brickOBJ, pointofPileBrickPlace[i].position, pointofPileBrickPlace[i].rotation, brickStack.transform);
                pointofPileBrick[i] = containerTEMP.transform;

            }
            //  transform.GetComponent<Animator>().SetBool("hasBrick", true);
            pointsToStop[2].gameObject.SetActive(true);
            //    Invoke("DoneResourcing3", 5f);
        }
        if (hasStone)
        {
            stoneStack.gameObject.SetActive(true);



            for (int i = 0; i < amountStone; i++)
            {
                containerTEMP = Instantiate(stoneOBJ, pointofPileStonePlace[i].position, pointofPileStonePlace[i].rotation, stoneStack.transform);
                pointofPileStone[i] = containerTEMP.transform;

            }
            //  transform.GetComponent<Animator>().SetBool("hasStone", true);
            pointsToStop[1].gameObject.SetActive(true);
            //    Invoke("DoneResourcing4", 5f);
        }
        if (hasWoodLog)
        {
            logStack.gameObject.SetActive(true);


            for (int i = 0; i < amountWoodLog; i++)
            {
                containerTEMP = Instantiate(woodOBJ, pointofPileLogPlace[i].position, pointofPileLogPlace[i].rotation, logStack.transform);
                pointofPileLog[i] = containerTEMP.transform;

            }
            // transform.GetComponent<Animator>().SetBool("hasWood", true);
            pointsToStop[0].gameObject.SetActive(true);
            //    Invoke("DoneResourcing5", 5f);
        }


    }

    //public void DoneResourcing1()
    //{
    //    transform.GetComponent<Animator>().SetBool("hasSteel", false);
    //} 
    //public void DoneResourcing2()
    //{
    //    transform.GetComponent<Animator>().SetBool("hasCement", false);
    //} 
    //public void DoneResourcing3()
    //{
    //    transform.GetComponent<Animator>().SetBool("hasBrick", false);
    //} 
    //public void DoneResourcing4()
    //{
    //    transform.GetComponent<Animator>().SetBool("hasStone", false);
    //} 
    //public void DoneResourcing5()
    //{
    //    transform.GetComponent<Animator>().SetBool("hasWood", false);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("stop"))
        {
            isLog = false;
            isStone = false;
            isBrick = false;
            isCement = false;
            isSteel = true;
            other.gameObject.SetActive(false);
            StockOnPileSteel();
            speed = 0f;
        //    Invoke("RetuenSpeed", 6f);
        }

        if (other.CompareTag("cementStop"))
        {
            isLog = false;
            isStone = false;
            isBrick = false;
            isCement = true;
            isSteel = false;
            other.gameObject.SetActive(false);
            CementStockup();
            speed = 0f;
         //   Invoke("RetuenSpeed", 10f);
        }
        if(other.CompareTag("brickStop"))
        {

            isLog = false;
            isStone = false;
            isBrick = true;
            isCement = false;
            isSteel = false;
            other.gameObject.SetActive(false);
            BrickStockup();
            speed = 0f;
        //    Invoke("RetuenSpeed", 10f);

        }
        if (other.CompareTag("stoneStop"))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            isLog = false;
            isStone = true;
            isBrick = false;
            isCement = false;
            isSteel = false;
            other.gameObject.SetActive(false);
            StoneStockup();
            speed = 0f;
         //   Invoke("RetuenSpeed", 10f);

        }
        if (other.CompareTag("logStop"))
        {
            Debug.Log("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
            isLog = true;
            isStone = false;
            isBrick = false;
            isCement = false;
            isSteel = false;
            other.gameObject.SetActive(false);
            LogStockup();
            speed = 0f;
            //Invoke("RetuenSpeed", 10f);

        }
    }
    
    public void RetuenSpeed()
    {
        speed = 5f;
        woodContainer.resourceVal = transform.gameObject.GetComponent<ResourceAreaHandler>().resourcesValue;
    }
}
