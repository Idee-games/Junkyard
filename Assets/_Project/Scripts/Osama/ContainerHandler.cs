using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerHandler : MonoBehaviour
{
    //public ResourceType type;
    //public bool giveResourcee = false;
    //public GameObject effectResource;
    //private Transform player;
    //private float distance;
    //public float resourceDistance = 4;
    //public Transform[] pointofMatrial;
    //public int resourceVal;
    //public int resourceVal2;
    //public int resourceNumber;
    //public PileHandler pileHandler;
    
    //// Start is called before the first frame update
    //void Start()
    //{
    //    resourceVal2 = (int)type;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    resourceVal = transform.gameObject.GetComponent<ResourceAreaHandler>().resourcesValue;
    //    if (!giveResourcee)
    //    {
    //        PlayerDistanceCheck();
    //    }
    //    distance = Vector3.Distance(player.position, this.transform.position);
    //    if (distance > resourceDistance)
    //    {
    //        giveResourcee = false;
            
    //    }
    //}

    //private void PlayerDistanceCheck()
    //{
       
        
    //    if (!player)
    //        player = Toolbox.GameplayScript.player.transform;

    //    distance = Vector3.Distance(player.position, this.transform.position);
       
    //        if (distance <= resourceDistance && pileHandler.toGive)
    //        {
    //            if (resourceVal > 0)
    //            {
    //                DestroyResourceFromPile();
    //                transform.gameObject.GetComponent<ResourceAreaHandler>().amountTxt.ToString();
    //                giveResourcee = true;
    //                GiveResource();
    //                ResourceToDB();

    //                Toolbox.HUDListner.UpdateResourceTxt(resourceNumber);
    //            }
    //        }
    //        else
    //        {
    //            giveResourcee = false;

    //        }
        
    //}
    //public void GiveResource()
    //{
    //    for (int i = 0; i < (Toolbox.DB.prefs.ResourceGatherLevel + resourceVal); i++)
    //    {
    //        Toolbox.GameplayScript.player.AddResourceOnBack(type);
    //    }
    //    Instantiate(effectResource, transform.position, Quaternion.identity);

    //}


    //public void ResourceToDB()
    //{
    //    Toolbox.DB.prefs.ResourceAmount[resourceNumber].value += resourceVal;
    //    transform.gameObject.GetComponent<ResourceAreaHandler>().resourcesValue = 0;
    
        
    //}


    //public void DestroyResourceFromPile()
    //{
    //    for(int i = 0; i < resourceVal; i++)
    //    {
    //        if(pointofMatrial[i].childCount > 0)
    //        {
    //            Destroy(pointofMatrial[i].GetChild(0).gameObject);
    //            pileHandler.ResourceZero(resourceNumber);
    //        }

    //    }
    //   // pileHandler.StockUpLoop();
    //}
    
    
}
