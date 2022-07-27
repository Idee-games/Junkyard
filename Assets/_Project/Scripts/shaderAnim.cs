using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaderAnim : MonoBehaviour
    
{
    public float speedX = -0.5f;
   // public float speedY = 0.1f;
    private float curx;
    //private float cury;

    // Start is called before the first frame update
    void Start()
    {
        curx = GetComponent<Renderer>().material.mainTextureOffset.x;
        //cury = GetComponent<Renderer>().material.mainTextureOffset.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        curx += Time.deltaTime * speedX;
        //cury += Time.deltaTime * speedY;
        GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(curx, 0));
    }
}
