using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningScriptHandler : MonoBehaviour
{
    public GameObject firePartical;
    public GameObject lightningEndPoint1;
    public GameObject lightningEndPoint2;
    public GameObject lightningEndPoint3;
    public float offMin = 10f;
    public float offMax = 60f;
    public float onMin =0.25f;
    public float onMax = 0.8f;
    public Light l;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LighningFire()
    {
        StartCoroutine(light());
        Instantiate(firePartical, lightningEndPoint1.transform.position,Quaternion.identity, lightningEndPoint1.transform);
        Instantiate(firePartical, lightningEndPoint2.transform.position,Quaternion.identity, lightningEndPoint2.transform);
        Instantiate(firePartical, lightningEndPoint3.transform.position,Quaternion.identity, lightningEndPoint3.transform);
       
    }


    public IEnumerator light()
    {
       
            
            l.enabled = true;
            
            yield return new WaitForSeconds(0.1f);
            l.enabled = false;
        
    }
    
}
