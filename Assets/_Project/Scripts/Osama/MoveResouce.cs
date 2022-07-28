using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveResouce : MonoBehaviour
{
//    public ResourceAreaHandler resourceAreaHandler;
//    PileHandler pileHandler;
//    public TruckHandler truckHander;
//    public ContainerHandler containerHandler;
//    bool a = true;
//    bool b = true;
//    bool move = true;
//    bool move2 = true;
//    public float speed;
//    float distance;

    


//    // Start is called before the first frame update
//    private void OnEnable()
//    {
       



//        truckHander= transform.parent.transform.GetComponentInParent<TruckHandler>();
//        pileHandler = truckHander.pilehandler;

        
        
        
//        if (truckHander.hasSteel)
//        {
//            resourceAreaHandler = truckHander.steelContainer.gameObject.GetComponent<ResourceAreaHandler>();
//            containerHandler = truckHander.steelContainer;
//            truckHander.materialArray = truckHander.pointofPileSteel;

//        }
//        if(truckHander.hasCement)
//        {
//            resourceAreaHandler = truckHander.cementContainer.gameObject.GetComponent<ResourceAreaHandler>();
//            containerHandler = truckHander.cementContainer;
//            truckHander.materialArray = truckHander.pointofPileCement;
//        }
//        if (truckHander.hasBrick)
//        {
//            resourceAreaHandler = truckHander.brickContainer.gameObject.GetComponent<ResourceAreaHandler>();
//            containerHandler = truckHander.brickContainer;
//            truckHander.materialArray = truckHander.pointofPileBrick;
//        }
//        if (truckHander.hasStone)
//        {
//            resourceAreaHandler = truckHander.stoneContainer.gameObject.GetComponent<ResourceAreaHandler>();
//            containerHandler = truckHander.stoneContainer;
//            truckHander.materialArray = truckHander.pointofPileStone;
//        }
//        if (truckHander.hasWoodLog)
//        {
//            resourceAreaHandler = truckHander.woodContainer.gameObject.GetComponent<ResourceAreaHandler>();
//            containerHandler = truckHander.woodContainer;
//            truckHander.materialArray = truckHander.pointofPileLog;
//        }




//    }
//    void Enable()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
       
       




//        distance = Vector3.Distance(containerHandler.pointofMatrial[truckHander.counter2].position, transform.position);
//        if (distance < 0.1f)
//        {
//            distance = -1f;
//        }
//        if (move)
//        {


//            transform.position = Vector3.MoveTowards(transform.position, containerHandler.pointofMatrial[truckHander.counter2].position, speed * Time.deltaTime);
//        }
//        if (truckHander.counter2 > truckHander.materialArray.Length - 1)
//        {
            
//        }
//        else
//        {
//            //Debug.Log(distance);

//            if (distance <= 0)
//            {

//                move = false;
//                if (a)
//                {
//                    MaterialMovement();
//                    a = false;
//                }

//            }

//        }
//        if(!move2)
//        {
//            truckHander.speed = 5f;
//        }
//        if (b)
//        {
//            CheckIfFUll();
//            b = false;
//        }
//        if (pileHandler.CheckifStock())
//        {

//            move2 = false;
//        }

//    }
       

//    public void MaterialMovement()
//    {
        
//        truckHander.counter2++;
//        transform.parent = containerHandler.pointofMatrial[truckHander.counter2-1];
//        if (truckHander.counter2 > truckHander.materialArray.Length - 1)
//        {

//        }
//        else
//        {
//            if (move2)
//            {
//                Add();
//            }

//        }
      
//        transform.GetComponent<MoveResouce>().enabled = false;
        
//    }


//    public void Add()
//    {
//        if (containerHandler.pointofMatrial[truckHander.counter2].transform.childCount > 0)
//        {
//            truckHander.counter2++;
//            Add();
//        }
//        else
//        {
//            if(containerHandler.pointofMatrial[0].transform.childCount > 1)
//            {
//                containerHandler.pointofMatrial[0].transform.GetChild(1).transform.position = containerHandler.pointofMatrial[truckHander.counter2+1].position;
//                containerHandler.pointofMatrial[0].transform.GetChild(1).transform.parent = containerHandler.pointofMatrial[truckHander.counter2+1];
//            }
//            truckHander.materialArray[truckHander.counter2].GetComponent<MoveResouce>().enabled = true;
//        }
//    }
//    public void CheckIfFUll()
//    {
//        if (truckHander.hasSteel)
//        {
//            pileHandler.amountSteel++;
//            pileHandler.amountofSteelRecord++;
//            resourceAreaHandler.AddResources(pileHandler.amountSteel);
             
//        }
//        if (truckHander.hasCement)
//        {
//            pileHandler.amountCement++;
//            pileHandler.amountofCementRecord++;
//            resourceAreaHandler.AddResources(pileHandler.amountCement); 
//        }
//        if (truckHander.hasBrick)
//        {
//            pileHandler.amountBrick++;
//            pileHandler.amountofBrickRecord++;
//            resourceAreaHandler.AddResources(pileHandler.amountBrick); 
//        }
//        if (truckHander.hasStone)
//        {
//            pileHandler.amountStone++;
//            pileHandler.amountofStoneRecord++;
//            resourceAreaHandler.AddResources(pileHandler.amountStone); 
//        }
//        if (truckHander.hasWoodLog)
//        {
//            pileHandler.amountWoodLog++;
//            pileHandler.amountofLogRecord++;
//            resourceAreaHandler.AddResources(pileHandler.amountWoodLog); 
//        }
//    }
    
}
