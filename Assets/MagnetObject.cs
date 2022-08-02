using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetObject : MonoBehaviour
{
    public GameObject trigger;
    public Animator anim;
    public bool magnetOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount > 7)
        {
            anim.transform.parent.gameObject.SetActive(true);
            anim.SetBool("isEmpty", false);
            trigger.SetActive(false);
        }
    }
}
