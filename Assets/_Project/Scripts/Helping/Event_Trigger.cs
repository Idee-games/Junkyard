using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Event_Trigger : MonoBehaviour
{
    public int triggerDelay = 1;
    //public bool disableTriggerObj = true;
    public string triggerByTag = "Player";

    public UnityEvent onStart;
    public UnityEvent onCollision;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    private void Start()
    {
        StartCoroutine(CR_Start());
    }
    IEnumerator CR_Start()
    {
        yield return new WaitForSeconds(triggerDelay);
        onStart.Invoke();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag(triggerByTag)) {

            StartCoroutine(CR_Collision());
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerByTag)) {

            StartCoroutine(CR_Trigger());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(triggerByTag))
        {
            StartCoroutine(CR_TriggerExit());
        }
    }

    IEnumerator CR_Collision()
    {
        yield return new WaitForSeconds(triggerDelay);
        onCollision.Invoke();
    }

    IEnumerator CR_Trigger()
    {
        yield return new WaitForSeconds(triggerDelay);
        
        onTriggerEnter.Invoke();
    }

    IEnumerator CR_TriggerExit()
    {
        yield return new WaitForSeconds(triggerDelay);
        onTriggerExit.Invoke();
    }
}
