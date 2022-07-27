using UnityEngine;
using System.Collections.Generic;

public class StructureHandler : MonoBehaviour
{
    //public Material [] usedMaterials;
    public HouseParts [] houseParts;
    [HideInInspector] public Color transparentColor;
    [HideInInspector] public Color solidColor;
    float progress = 0;
    [HideInInspector] public int totalParts = 0;
    [HideInInspector] public int partsBuild = 0;
    private int curPartArea = 0;
    private int curAreaPartsBuilt = 0;

    private float time = 0;
    private float delayAmongPartHit = 0.1f;
    private int desIndex = 0;
    private int partsToDestroy = 0;

    public int onPartLiftEnable = 0;
    public GameObject liftObj;

    private List<StructurePartHandler> builtParts;

    private bool startDestruction = false;
    

    private void Start()
    {
        builtParts = new List<StructurePartHandler>();
        totalParts = houseParts.Length;

        for (int i = 0; i < houseParts.Length; i++)
        {
            totalParts += houseParts[i].part.Length-1;
        }
        curPartArea = 0;

        //MaterialsTransparentStatus(true);

        Toolbox.GameplayScript.buildStructureHandler = this;

        EnablePartInStart();
    }

    private void Update()
    {
        if (startDestruction)
        {
            time -= Time.deltaTime;

            if (time <= 0)
            {
                time = delayAmongPartHit;

                builtParts[desIndex].OnHit();
                partsToDestroy--;

                desIndex--;

                if (desIndex < 0 || partsToDestroy <= 0)
                {
                    startDestruction = false;
                }
            }
        }
    }

    void EnablePartInStart() {

        for (int i = 0; i < houseParts.Length; i++)
        {
            for (int j = 0; j < houseParts[i].part.Length; j++)
            {
                if (i == 0)
                {
                    houseParts[i].part[j].gameObject.SetActive(true);
                }
                else
                {
                    houseParts[i].part[j].gameObject.SetActive(false);
                }
            }
        }
    }

    public void MaterialsTransparentStatus(bool _val) {

        //if (_val)
        //{
        //    for (int i = 0; i < usedMaterials.Length; i++)
        //    {
        //        ChangeRenderMode(usedMaterials[i], _val);
        //        //usedMaterials[i].SetFloat("_Mode", 3f);
        //        //usedMaterials[i].color = transparentColor;
        //    }
        //}
        //else {
        //    for (int i = 0; i < usedMaterials.Length; i++)
        //    {
        //        ChangeRenderMode(usedMaterials[i], _val);
        //        //usedMaterials[i].SetFloat("_Mode", 0);
        //        //usedMaterials[i].color = solidColor;
        //    }
        //}

        //for (int i = 0; i < usedMaterials.Length; i++)
        //{
        //    ChangeRenderMode(usedMaterials[i], _val);
        //}
    }

    public void HousePartComplete(StructurePartHandler _handler) {

        //Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.paint);
        partsBuild++;
        curAreaPartsBuilt++;
        progress = ((float)partsBuild / (float)totalParts);
        Toolbox.HUDListner.SetProgressBarFill(progress);

        builtParts.Add(_handler);


        if (curPartArea < houseParts.Length-1) {

            if (curAreaPartsBuilt >= houseParts[curPartArea].part.Length) {

                curAreaPartsBuilt = 0;
                curPartArea++;

                if (liftObj && onPartLiftEnable == curPartArea)
                {
                    liftObj.SetActive(true);
                }

                for (int i = 0; i < houseParts[curPartArea].part.Length; i++)
                {

                    houseParts[curPartArea].part[i].gameObject.SetActive(true);
                }
            }
        }

        if (partsBuild >= totalParts) {

            //MaterialsTransparentStatus(false);
            if (liftObj)
                liftObj.SetActive(false);
            Toolbox.GameplayScript.OnStormHandling();
        }
    }

    public void ChangeRenderMode(Material standardShaderMaterial, bool _transparent)
    {
        //Debug.LogError("IN VAL = " + _transparent);

        switch (_transparent)
        {
            case false:
                standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                standardShaderMaterial.SetInt("_ZWrite", 1);
                standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                standardShaderMaterial.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                standardShaderMaterial.renderQueue = -1;
                standardShaderMaterial.color = solidColor;

                break;

            case true:
                //standardShaderMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                //standardShaderMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                //standardShaderMaterial.SetInt("_ZWrite", 0);
                //standardShaderMaterial.DisableKeyword("_ALPHATEST_ON");
                //standardShaderMaterial.DisableKeyword("_ALPHABLEND_ON");
                //standardShaderMaterial.EnableKeyword("_ALPHAPREMULTIPLY_ON");
                //standardShaderMaterial.renderQueue = 3000;
                //standardShaderMaterial.color = transparentColor;

                standardShaderMaterial.SetFloat("_Mode", 3f);
                standardShaderMaterial.color = transparentColor;
                break;
        }

    }

    public void InitDistruction() {

        if (progress < 0.5f)
        {
            time = 0.1f;
            partsToDestroy = totalParts;
        }
        else {

            time = delayAmongPartHit;

            if (progress < 0.6f) { 
            
                partsToDestroy = 1;

            }else if (progress < 0.6f)
            {
                partsToDestroy = 2;
            }
            else if (progress < 0.7f)
            {
                partsToDestroy = 3;
            }
            else if (progress < 0.8f)
            {
                partsToDestroy = 4;
            }
            else if (progress < 0.9f)
            {
                partsToDestroy = 5;
            }
            else if (progress == 1)
            {
                partsToDestroy = 0;
            }
        }

        if (progress > 0 && partsToDestroy > 0) {

            desIndex = builtParts.Count - 1;
            startDestruction = true;
        }
    }

    public void DisableAllSpecs() {

        foreach (var item in this.GetComponentsInChildren<SpecHandler>())
        {
            item.gameObject.SetActive(false);
        }
    }
}
