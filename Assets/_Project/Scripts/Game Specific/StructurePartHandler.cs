using UnityEngine;

public class StructurePartHandler : MonoBehaviour
{
    public ResourceType requireType;
    public int resourceRequired = 5;
    private int totalResource = 5;
    private Animator anim;
    public bool disableMeshInStart = false;

    private float time = 0;
    private float convertResourceDelay = 0.1f;

    private bool startProcessing = false;
    private int requirementResourceVal = 0;

    private Transform player;
    public float buildDistance = 4;
    private float distance = 0;

    //public int minForceLimit = 0;
    //public int maxForceLimit = 0;

    [HideInInspector]public bool built = false;

    private SpecHandler specs;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
        requirementResourceVal = (int)requireType;
        totalResource = resourceRequired;

        if (disableMeshInStart)
            MeshStatus(false);

        //this.GetComponent<MeshRenderer>().enabled = false;



        //typeTxt.text = requireType.ToString();
        specs = this.GetComponentInChildren<SpecHandler>();
        if (specs) {

            specs.SetIcon(requirementResourceVal);
            specs.SetVal((totalResource - resourceRequired).ToString() + "/" + totalResource.ToString());
        }
    }

    private void Update()
    {
        if (built)
            return;

        PlayerDistanceCheck();
        ProcessHandling();
    }

    private void ProcessHandling()
    {
        if (startProcessing)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                TransferResource();
                time = convertResourceDelay;
            }
        }
    }

    private void PlayerDistanceCheck()
    {
        if (!player)
            player = Toolbox.GameplayScript.player.transform;

        distance = Vector3.Distance(player.position, this.transform.position);
        if (distance <= buildDistance)
        {
            startProcessing = true;
        }
        else {

            startProcessing = false;
        }
    }

    public void InitProcessing()
    {
        if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value > 0)
        {
            startProcessing = true;
        }
    }

    private void TransferResource()
    {
        //Debug.LogError("Transfer");
        int resourceAmount = 1;

        if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value <= 0)
            return;

        //if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value > (Toolbox.DB.prefs.ResourceGatherLevel + 1))
        //{
        //    resourceAmount = (Toolbox.DB.prefs.ResourceGatherLevel + 1);
        //}
        //else
        //{
        //    resourceAmount = Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value;
        //}

        //if (resourceAmount > resourceRequired)
        //    resourceAmount = resourceRequired;
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.gatherCement);
        Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value -= resourceAmount;

        for (int i = 0; i < resourceAmount; i++)
        {
            Toolbox.GameplayScript.player.RemoveResourceOnBack(requireType);
        }

        Toolbox.HUDListner.UpdateResourceTxt(requirementResourceVal);

        resourceRequired -= resourceAmount;
        Toolbox.GameplayScript.player.SendResource(requireType, this.transform);

        specs.SetVal((totalResource - resourceRequired).ToString() + "/" + totalResource.ToString());

        if (resourceRequired <= 0) {

            Build();
        }
    }

    void Build() {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.paint);
        if (built)
            return;

        specs.gameObject.SetActive(false);
        built = true;

        anim.SetTrigger("Build");

        //this.GetComponent<MeshRenderer>().enabled = true;

        if (disableMeshInStart)
            MeshStatus(true);

        this.GetComponentInParent<StructureHandler>().HousePartComplete(this);
        this.enabled = false;
    }

    public void OnHit() {

        //this.transform.rotation = Quaternion.Euler(new Vector3(this.transform.rotation.x + 10, this.transform.rotation.y + 10, this.transform.rotation.z + 10));
        
        if(GetComponent<MeshCollider>())
            GetComponent<MeshCollider>().isTrigger = false;
        else
            GetComponentInChildren<MeshCollider>().isTrigger = false;


        Rigidbody rbody = this.gameObject.AddComponent<Rigidbody>();
        int rand = Random.Range(7, 12);

        if (Toolbox.HUDListner.progress < 0.5f)
            rand += 5;

        rbody.AddForce(Vector3.up * rand, ForceMode.Impulse);
    }
    void MeshStatus(bool _val) {

        if(this.GetComponent<MeshRenderer>())
            this.GetComponent<MeshRenderer>().enabled = _val;

        if (this.GetComponentInChildren<MeshRenderer>()) {

            foreach (var item in this.GetComponentsInChildren<MeshRenderer>())
            {
                if(!item.GetComponent<TextMesh>())
                    item.enabled = _val;
            }
        }
    }
}