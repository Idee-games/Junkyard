using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    public GameObject[] effects;
    
    public bool isCement;
    private void Start()
    {
        OffEffects();
    }
    public void OffEffects()
    {
        for(int i = 0; i < effects.Length; i++)
        {
            
          //  effects[i].gameObject.SetActive(false);
            effects[i].GetComponent<Animator>().enabled = true;
            effects[i].GetComponent<Animator>().SetBool("on", false);


            
        }


        if (isCement)
        {
            effects[1].GetComponent<Animator>().enabled = false;
            effects[2].GetComponent<Animator>().enabled = false;
        }
    }
    public void OnEffects()
    {
        for (int i = 0; i < effects.Length; i++)
        { 
            effects[i].gameObject.SetActive(true);
            effects[i].GetComponent<Animator>().enabled = true;
            effects[i].GetComponent<Animator>().SetBool("on", true);
            

        }
    }
}
