using UnityEngine;

public class MoveTO : MonoBehaviour
{
    public Transform target;
    public bool start = false;
    float distance;
    public float speed = 20;
    public bool targetAlwaysPlayer = false;

    void Update()
    {
        if(start)
        {
            Move();
        }
    }

    public void EnableMovement() {

        start = true;

        if (targetAlwaysPlayer)
            target = Toolbox.GameplayScript.player.transform;
    }

    public void EnableMovement(Transform _point)
    {
        start = true;

        if (targetAlwaysPlayer)
            target = Toolbox.GameplayScript.player.transform;
        else
            target = _point;

    }

    public void Move()
    {
        distance = Vector3.Distance(transform.position, target.position);
        transform.position = Vector3.MoveTowards(transform.transform.position, target.position, speed * Time.deltaTime);
        //transform.position = Vector3.Lerp(transform.transform.position, target.position, speed * Time.deltaTime);

        if (distance < 0.2f)
        {
            start = false;
            Destroy(gameObject);
        }
    }
}
