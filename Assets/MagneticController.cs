using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticController : MonoBehaviour
{
    Transform player;
    public float distance;
    Rigidbody move;
    float speed = 20f;
    bool moveto = false;
    Transform factory;
    // Use this for initialization
    void Start()
    {
        move = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Magnet").transform;
        factory = GameObject.FindGameObjectWithTag("Factory").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < 3 && player.GetComponent<MagnetObject>().magnetOn)
        {
            //transform.position = (player.transform.position - transform.position) * Time.deltaTime * speed;
            move.AddForce((player.transform.position - transform.position) * (14));
        }

        if(moveto)
        {
            move.AddForce((factory.transform.position - transform.position) * (16));
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magnet"))
        {
            transform.parent = player;
            speed = 0f;
            move.isKinematic = true;
        }
        if (other.CompareTag("FactoryRange"))
        {
            move.isKinematic = false;
            moveto = true;
        }
        if(other.CompareTag("Factory"))
        {
            move.isKinematic = true;
            transform.parent = factory;
            moveto = false;
            player.GetComponent<MagnetObject>().magnetOn = true;
        }
    }

}

