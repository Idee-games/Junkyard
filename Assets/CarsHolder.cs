using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsHolder : MonoBehaviour
{
    bool a = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            if(!a)
            {
                a = true;
                AA();
                
            }
        }
    }
    public void AA()
    {
        Toolbox.GameplayScript.LevelCompleteHandling();
    }
}
