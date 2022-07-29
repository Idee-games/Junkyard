using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticController : MonoBehaviour
{
    Transform player;
    public float distance;
    //Rigidbody move;
    float speed = 20f;
    bool movetotrunk = false;
    bool movetoFactory = false;
    Transform factory;
    // Use this for initialization
    void Start()
    {
        //move = GetComponent<Rigidbody>();
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

        if(movetotrunk && player.GetComponent<MagnetObject>().magnetOn)
        {
            transform.position = Vector3.MoveTowards(transform.position , player.transform.position,0.1f);
            //move.AddForce((factory.transform.position - transform.position) * (16));
        }
        if (movetoFactory)
        {
            transform.position = Vector3.MoveTowards(transform.position, factory.transform.position, 0.1f);
            //move.AddForce((factory.transform.position - transform.position) * (16));
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("MagnetRange"))
        {
            Destroy(GetComponent<Rigidbody>());
            movetotrunk = true;
        }
        if (other.CompareTag("Magnet"))
        {
            
            transform.parent = player;
            movetotrunk = false;
            //speed = 0f;
            // move.isKinematic = true;
        }
        if (other.CompareTag("FactoryRange"))
        {
           Destroy(transform.GetComponent<BoxCollider>());
            //move.isKinematic = false;
            movetoFactory = true;
        }
        if (other.CompareTag("Factory"))
        {
           // move.isKinematic = true;
            transform.parent = factory;
            movetoFactory = false;
            player.GetComponent<MagnetObject>().magnetOn = true;
            player.GetComponent<MagnetObject>().trigger.SetActive(true);
        }
    }

}

