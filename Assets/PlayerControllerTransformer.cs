using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransformer : MonoBehaviour
{
    public CharacterController controller;
    private Animator anim;
    public GameObject[] models;
    private int index = 0;
    private bool run = false;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    private float gravityValue = -9.81f;
    [SerializeField] private bool isGathering = false;
    public GameObject junkPrefab;
    float time = 0;
    public float gatherDelay = 1.8f;
    GameObject obj;
    bool a;

    GameObject brokenCar;


    private void Start()
    {
        index = Toolbox.DB.prefs.LastSelectedPlayerObj;
        EnableCharacter(index);
    }

    public void EnableCharacter(int index)
    {

        foreach (var item in models)
        {
            item.gameObject.SetActive(false);
        }

        models[index].SetActive(true);
        anim = models[index].GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMovement();

        ResourceGatherHandling();
        GatherTimeHandling();
    }
    private void ResourceGatherHandling()
    {
        if (!isGathering && a)
        {

            isGathering = true;
            int i = 0;
            i = Random.Range(0, 2);
            if (i == 0)
            {
                anim.SetTrigger("Attack");
            }
            else
            {
                anim.SetTrigger("Kick");
            }
            time = gatherDelay;
          
        }
    }

    public void GatherRequestHandling()
    {


        brokenCar.GetComponent<BrokenCar>()._val--;
        isGathering = false;
        brokenCar.GetComponent<BrokenCar>().anim.SetInteger("State", brokenCar.GetComponent<BrokenCar>()._val);
        if (brokenCar.GetComponent<BrokenCar>()._val == 0)
        {
            a = false;
            Destroy(brokenCar);

        }
        obj = Instantiate(junkPrefab, brokenCar.transform.position, Quaternion.identity) as GameObject;
        obj.transform.parent = null;
        obj.GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-10.5f, 10.5f), 3, Random.Range(-10.5f, 10.5f)) * 50f);
        Debug.Log("Next Kick");
    }
    private void GatherTimeHandling()
    {
        if (time <= 0)
            return;


        time -= Time.deltaTime;

        if (time <= 0)
        {

            GatherRequestHandling();
        }
    }
    void PlayerMovement()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(CnControls.CnInputManager.GetAxis("Horizontal"), 0, CnControls.CnInputManager.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        UpdateMovement(move);
    }


    private void UpdateMovement(Vector3 _mov)
    {

        if (_mov.x != 0 || _mov.z != 0)
        {
            run = true;
            //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.running);
        }
        else
        {

            run = false;
        }

        anim.SetBool("Run", run);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Resource"))
        {
            a = true;
            brokenCar = other.gameObject;
            //int i = 0;
            //i = Random.Range(0, 2);
            //if (i == 0)
            //{
            //    anim.SetBool("AttackB",true);
            //}
            //else
            //{
            //    anim.SetBool("KickB", true);
            //}
        }

    }
    private void OnTriggerExit(Collider other)
    {
        a = false;
        //if (other.CompareTag("Resource"))
        //{
        //    anim.SetBool("AttackB", false);
        //    anim.SetBool("KickB", false);
        //}
    }
   
}
