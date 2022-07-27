using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWeather : MonoBehaviour
{
    public float time;
    //public GameObject lightiningBtn;
    //public GameObject stormBtn;
    //public GameObject volcanoBtn;
    //public GameObject tsunamiBtn;
    //public GameObject tornadoBtn;
    // Start is called before the first frame update
    void Start()
    {
        DestroyWeatherOne();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DestroyWeatherOne()
    {
        Destroy(gameObject,time);
        
    }
}
