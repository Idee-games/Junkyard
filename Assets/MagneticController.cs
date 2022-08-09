using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticController : MonoBehaviour
{ 
    bool counted = false;
    bool onFactory = false;
    Transform player;
    public float distance;
   // Rigidbody move;
    float speed = 20f;
    bool movetotrunk = false;
    bool movetoFactory = false;
    Transform factory;
    GameObject obj;
    float progress;
    // Use this for initialization
    void Start()
    {
        Toolbox.GameplayScript.levelsManager.CurLevelHandler.levelCompleteInt = Toolbox.GameplayScript.levelsManager.CurLevelHandler.junkPrefab.transform.childCount - 5;
        // move = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Magnet").transform;
        factory = GameObject.FindGameObjectWithTag("Factory").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector3.Distance(transform.position, player.transform.position);
        //if (distance < 3 && player.GetComponent<MagnetObject>().magnetOn)
        //{
        //    //transform.position = (player.transform.position - transform.position) * Time.deltaTime * speed;
        //    move.AddForce((player.transform.position - transform.position) * (14));
        //}

        if(movetotrunk)
        {
            transform.position = Vector3.MoveTowards(transform.position , player.transform.position, 28f * Time.deltaTime);
            //move.AddForce((factory.transform.position - transform.position) * (16));
        }
        if (movetoFactory)
        {
            transform.position = Vector3.MoveTowards(transform.position, factory.transform.position, 28f * Time.deltaTime);
            //move.AddForce((factory.transform.position - transform.position) * (16));
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("MagnetRange"))
        {
            if (!onFactory)
            {
                // Destroy(GetComponent<Rigidbody>());
                movetotrunk = true;
            }
        }
        if (other.CompareTag("Magnet"))
        {
            if (!onFactory)
            {
                Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.gatherIronPick);
                transform.parent = player;
                movetotrunk = false;
                //speed = 0f;
                //  move.isKinematic = true;
            }
        }
        if (other.CompareTag("FactoryRange"))
        {

            onFactory = true;
           Destroy(transform.GetComponent<MeshCollider>());
            //move.isKinematic = false;
            movetoFactory = true;
            Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.BrickFactory);
            transform.parent = factory;
            Debug.Log(transform.parent);
            player.GetComponent<MagnetObject>().trigger.SetActive(true);
            player.GetComponent<MagnetObject>().anim.SetBool("isEmpty", true);
            Des();
          //  Invoke("RewardBox", 1f);
            
        }
        if (other.CompareTag("Factory"))
        {
       //     Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.BrickFactory);
            // move.isKinematic = true;


            //movetoFactory = false;
            //  player.GetComponent<MagnetObject>().magnetOn = true;


        }
    }
    public void RewardBox()
    {
        obj = Instantiate(FindObjectOfType<PlayerController>().rewardBox, factory.transform.parent.transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
        obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-20f, 20f), 1, Random.Range(-20f, 20f)) * 15f);
    }
    public void Des()
    {
        if (!counted)
        {
            Toolbox.GameplayScript.counterJunk++;
            progress = ((float)Toolbox.GameplayScript.counterJunk / (float)Toolbox.GameplayScript.levelsManager.CurLevelHandler.levelCompleteInt);
            Toolbox.HUDListner.SetProgressBarFill(progress);
            counted = true;
            
        }
        if (Toolbox.GameplayScript.levelsManager.CurLevelHandler.levelCompleteInt <= Toolbox.GameplayScript.counterJunk)
        {
            Toolbox.GameplayScript.LevelCompleteHandling();
        }
        Debug.Log("Destroyeddd");
        Destroy(gameObject, 2f);
    }
}

