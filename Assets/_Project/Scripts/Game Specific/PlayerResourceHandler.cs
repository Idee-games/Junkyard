using UnityEngine;

public class PlayerResourceHandler : MonoBehaviour
{
    public ResourceType type;
    public GameObject resourceObj;
    public float yOffset = 1;
    public int index = -1;
    public GameObject lastObj;

    public void SetResource(ResourceType _type, GameObject _obj) {

        type = _type;
        resourceObj = _obj;
    }

    public void Add() {

        index++;

        lastObj = Instantiate(resourceObj, this.transform.position + new Vector3(0, (index * yOffset), 0), this.transform.rotation);
        lastObj.transform.parent = this.transform;
        lastObj.SetActive(true);
    }

    public void Remove()
    {
        if (index < 0)
            return;

        Destroy(lastObj);

        index--;

        if(index > -1)
            lastObj = this.transform.GetChild(index).gameObject;

    }
}