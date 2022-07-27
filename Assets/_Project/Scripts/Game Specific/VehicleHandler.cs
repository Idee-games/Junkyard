using UnityEngine;

public class VehicleHandler : MonoBehaviour
{
    private float speed = 1;
    public bool hasFixedSpeed = false;

    public float minSpeedRange = 1;
    public float maxSpeedRange = 1;
    bool start = false;

    public Transform initPoint;
    public Transform endPoint;

    private void Start()
    {
        if(Toolbox.DB.prefs.GameAudio == true)
        {
            Toolbox.Soundmanager.vehicleRadio.Play();
        }
        else if (Toolbox.DB.prefs.GameAudio == false)
        {
            Toolbox.Soundmanager.vehicleRadio.Stop();
        }
        start = true;

        if (hasFixedSpeed)
        {
            speed = maxSpeedRange;
        }
        else { 
        
            speed = Random.Range(minSpeedRange, maxSpeedRange);
        }
    }

    public void Stop() {

        start = false;
    }
    private void FixedUpdate()
    {
        if (start) {

            this.transform.position += (this.transform.forward) * Time.deltaTime * speed;

            if (Vector3.Distance(this.transform.position, endPoint.transform.position) < 2)
            {
                this.transform.position = initPoint.position;
            }
        }
    }
}
