using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireController : MonoBehaviour
{
    public bool checkTire = false;
    public GameObject[] tires;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void startRotate()
    {
        tires[0].GetComponent<RotateAlways>().enabled = true;
        tires[1].GetComponent<RotateAlways>().enabled = true;
        tires[2].GetComponent<RotateAlways>().enabled = true;
        tires[3].GetComponent<RotateAlways>().enabled = true;
    }
    public void stopRotate()
    {
        tires[0].GetComponent<RotateAlways>().enabled = false;
        tires[1].GetComponent<RotateAlways>().enabled = false;
        tires[2].GetComponent<RotateAlways>().enabled = false;
        tires[3].GetComponent<RotateAlways>().enabled = false;
    }
    public void left()
    {
        
    }
}
