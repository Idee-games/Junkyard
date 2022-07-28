using UnityEngine;

public class ResourceHandler : MonoBehaviour
{
    //public ResourceType type;
    //private BoxCollider collider;

    //[Tooltip("This many times user will get resource from this Object")]
    //public int defaultResouceQuantity = 3;
    //[SerializeField] private int curResouceQuantity = 3;
    //private int resourceVal = 0;

    //[Space(10)]
    //public Transform [] effectInitPoints;
    //private int curEffectPointIndex = 0;
    //public GameObject effectPrefab;
    //public Animator anim;

    //[SerializeField]private float time = 0;
    //public float respawnTime = 5;
    //private bool isRespawning = false;
    //public AudioClip GatherSound;
    //private Transform player;
    //private bool distanceCheck = false;
    //public float gatherDistance = 5;

    //private void Start()
    //{
    //    resourceVal = (int)type;
    //    collider = this.GetComponent<BoxCollider>();
    //}

    //private void Update()
    //{
    //    if (isRespawning) {

    //        time -= Time.deltaTime;

    //        if (time <= 0) {

    //            ResetResource();
    //            SetRespawnStatus(false);
    //        }
    //    }

    //    PlayerDistanceCheck();
    //}

    //private void PlayerDistanceCheck()
    //{
    //    if (distanceCheck) {

    //        if (!player)
    //            player = Toolbox.GameplayScript.player.transform;

    //        if (Vector3.Distance(player.position, this.transform.position) >= gatherDistance) {

    //            Toolbox.GameplayScript.player.RemoveResource(this);
    //            DistanceCheckStatus(false);
    //        }
    //    }
    //}

    //public void ResetResource()
    //{
    //    curResouceQuantity = defaultResouceQuantity;
    //    UpdateModelLevel(defaultResouceQuantity);
    //}

    //void SetRespawnStatus(bool _val) {

    //    collider.enabled = !_val;
    //    isRespawning = _val;
    //}

    //public void DistanceCheckStatus(bool _val) {

    //    distanceCheck = _val;
    //}

    //public void GetResource() {

    //    if (isRespawning)
    //        return;

    //    Toolbox.DB.prefs.ResourceAmount[resourceVal].value += (Toolbox.DB.prefs.ResourceGatherLevel + 1);

    //    for (int i = 0; i < (Toolbox.DB.prefs.ResourceGatherLevel + 1); i++)
    //    {
    //        Toolbox.GameplayScript.player.AddResourceOnBack(type);
    //    }

    //    Toolbox.HUDListner.UpdateResourceTxt(resourceVal);
    //    curResouceQuantity--;
    //    UpdateModelLevel(curResouceQuantity);
    //    //Debug.LogError(Toolbox.DB.prefs.ResourceAmount[resourceVal].name /*+ " " + Toolbox.DB.prefs.ResourceAmount[resourceVal].value*/ + "_Added");
    //    InitEffect();
    //    Toolbox.Soundmanager.PlaySound(GatherSound);

    //    if (curResouceQuantity <= 0) {

    //        //Debug.LogError(Toolbox.DB.prefs.ResourceAmount[resourceVal].name + " Respawning");
    //        Toolbox.GameplayScript.player.RemoveResource(this);
    //        time = respawnTime;
    //        DistanceCheckStatus(false);

    //        SetRespawnStatus(true);
    //    }
    //}

    //public void InitEffect() {

    //    if (effectPrefab) {

    //        GameObject obj = Instantiate(effectPrefab, this.transform.position, Quaternion.identity);
    //    }
    //}

    //void UpdateModelLevel(int _val) {

    //    anim.SetInteger("State", _val);
    //}
}