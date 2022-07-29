using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : MonoBehaviour
{
    public GameObject trigger;
    public bool magnetOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 2)
        {
            magnetOn = false;
            trigger.SetActive(false);
        }
    }
}
