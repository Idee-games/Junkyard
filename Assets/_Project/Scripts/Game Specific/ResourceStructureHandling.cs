using UnityEngine;

public class ResourceStructureHandling : MonoBehaviour
{
    public AudioClip factory;
    public ResourceType requireType;
    public ResourceType productionType;

    public EffectHandler effectHandler;
    public GameObject effectPrefab;

    private float time = 0;
    private float convertResourceDelay = 0.3f;

    private bool startProcessing = false;
    private int requirementResourceVal = 0;
    private int productionResourceVal = 0;

    private Transform player;
    public float gatherDistance = 2;

    public GameObject effects;
    private void Start()
    {
        requirementResourceVal = (int)requireType;
        productionResourceVal = (int)productionType;

    }
    private void Update()
    {
        if (startProcessing) {

            time -= Time.deltaTime;

            if (time <= 0) {

                TransferResource();

                time = convertResourceDelay;
            }

            //effects.SetActive(true);

            //if (productionType == ResourceType.CEMENT_SACK)
            //{
            //    CementMachine();
            //}


            //effectHandler.OnEffects();
            ////effects.SetActive(false);
            //if (productionType == ResourceType.CEMENT_SACK)
            //{
            //    CementMachine();
            //}

            PlayerDistanceCheck();
        }
    }
    public void CementMachine()
    {
        transform.GetChild(0).GetComponent<Animator>().enabled = true;
        transform.GetChild(1).GetComponent<Animator>().enabled = true; 
    }
    public void CementMachineStop()
    {
        transform.GetChild(0).GetComponent<Animator>().enabled = false;
        transform.GetChild(1).GetComponent<Animator>().enabled = false; 
    }
    private void PlayerDistanceCheck()
    {
        if (!player)
            player = Toolbox.GameplayScript.player.transform;

        if (Vector3.Distance(player.position, this.transform.position) >= gatherDistance)
        {
            StopProcessing();
        }        
    }

    public void InitProcessing() {

        if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value > 0) {

            startProcessing = true;

            effects.SetActive(true);

            if (productionType == ResourceType.CEMENT_SACK)
            {
                CementMachine();
            }


            effectHandler.OnEffects();
            //effects.SetActive(false);
            if (productionType == ResourceType.CEMENT_SACK)
            {
                CementMachine();
            }
        }
    }

    public void StopProcessing() {

        startProcessing = false;
        effectHandler.OffEffects();
        //  effects.SetActive(false);
        if (productionType == ResourceType.CEMENT_SACK)
        {
            CementMachineStop();
        }
    }

    private void TransferResource() {



        int resourceAmount = 1;

        if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value > (Toolbox.DB.prefs.ResourceGatherLevel + 1))
        {
            resourceAmount = (Toolbox.DB.prefs.ResourceGatherLevel + 1);
        }
        else
        {

            resourceAmount = Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value;
        }

        Toolbox.GameplayScript.player.SendResource(requireType, this.transform);
        InitEffect();

        Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value -= resourceAmount;
        Toolbox.HUDListner.UpdateResourceTxt(requirementResourceVal);

        for (int i = 0; i < resourceAmount; i++)
        {
            Toolbox.GameplayScript.player.RemoveResourceOnBack(requireType);
        }

        Toolbox.DB.prefs.ResourceAmount[productionResourceVal].value += resourceAmount;
        Toolbox.HUDListner.UpdateResourceTxt(productionResourceVal);
        for (int i = 0; i < resourceAmount; i++)
        {
            Toolbox.GameplayScript.player.AddResourceOnBack(productionType);
        }

        if (Toolbox.DB.prefs.ResourceAmount[requirementResourceVal].value <= 0) {

            StopProcessing();
        }
    }

    public void InitEffect()
    {
        if (effectPrefab)
        {
            Toolbox.Soundmanager.PlaySound(factory);
            GameObject obj = Instantiate(effectPrefab, this.transform.position, Quaternion.identity);
        }
    }
}