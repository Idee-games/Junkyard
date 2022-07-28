using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

   
    public Transform playerParent;
    //public PlayerResources[] resources;

   

    [Space(10)]
   
    

    float time = 0;
    float gatherDelay = 0.8f;
    int resourceAvailableInLevel = 0;


    private void Start()
    {
        index = Toolbox.DB.prefs.LastSelectedPlayerObj;
        EnableCharacter(index);
    }

   public void EnableCharacter(int index) {

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
       

        GatherTimeHandling();
    }

    private void GatherTimeHandling()
    {
        if (time <= 0)
            return;
        

        time -= Time.deltaTime;

        if (time <= 0){

          
        }
    }

    void PlayerMovement() {

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


    private void UpdateMovement(Vector3 _mov) {

        if (_mov.x != 0 || _mov.z != 0)
        {
            run = true;
            //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.running);
        }
        else {

            run = false;
        }

        anim.SetBool("Run", run);

    }

  

  

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        // no rigidbody
        if (body == null || body.isKinematic)
        {
            return;
        }

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3)
        {
            return;
        }

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * 10;

    }

   

    private void OnTriggerEnter(Collider other)
    {
        //Debug.LogError("Trigger = " + other.gameObject.tag.ToString());
        switch (other.tag)
        {
          
            case "Coin":
                Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.coinsSound);
                Toolbox.DB.prefs.GoldCoins = Toolbox.DB.prefs.GoldCoins + 1;
                other.gameObject.SetActive(false);
                break;
            case "Chest":
                Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.chestSound);
                Toolbox.DB.prefs.GoldCoins = Toolbox.DB.prefs.GoldCoins + 5;
                Toolbox.GameManager.Instantiate_RewardAnim();
                other.gameObject.SetActive(false);
                break;

            default:
                break;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.LogError("Trigger = " + other.gameObject.tag.ToString());
        switch (other.tag)
        {
            case "Resource":

              

                break;

            case "Lift":

                this.transform.parent = playerParent;

                break;

            

            default:
                break;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.LogError("Trigger = " + other.gameObject.tag.ToString());

        //switch (other.tag)
        //{
        //    case "Resource":

        //        Debug.LogError("Trigger = " + other.gameObject.tag.ToString());

        //        break;

        //    default:
        //        break;
        //}

    }

    //public void UpdateResourcesOnBack() {

    //    for (int i = 0; i < Toolbox.DB.prefs.ResourceAmount.Length; i++)
    //    {
    //        if (Toolbox.DB.prefs.ResourceAmount[i].value >= 3) {

    //            for (int j = 0; j < 3; j++)
    //            {
    //                resources[i].part[j].gameObject.SetActive(true);
    //            }
    //        }
    //    }
    //}



    

   
}