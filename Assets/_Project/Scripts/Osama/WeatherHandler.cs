using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DigitalRuby.LightningBolt
{
    public class WeatherHandler : MonoBehaviour
    {

        public Light lit;
        public GameObject stormObj;
        public GameObject volcanoObj;
        public GameObject lightningOBJ;
        public GameObject tsunamiObj;
        public GameObject tornadoObj;

        
        public GameObject stormBtn;
        public GameObject volcanoBtn;
        public GameObject tsunamiBtn;
        public GameObject tornadoBtn;

        public void EarthQuakes()
        {
            Toolbox.GameplayScript.camShake.ShakeCamera(5, 4);
        }
        public void StormLightSettings()
        {
            lit.intensity = 0f;
        }

        public void TsunamiBtn()
        {
            Instantiate(tsunamiObj, transform);
            btnDes();
            Invoke("btnShow", 6f);
        }
        public void VolcanoBtn()
        {
            Instantiate(volcanoObj, transform);
            btnDes();
            Invoke("btnShow", 6f);
        }
        public void TornadoBtn()
        {
            Instantiate(tornadoObj, transform);
            btnDes();
            Invoke("btnShow", 6f);
        }
        public void StormBtn()
        {

            Instantiate(stormObj, transform);
            btnDes();
            Invoke("btnShow", 6f);
            Invoke("Lightninggg", 3f);
        }

        public void btnShow()
        {
            stormBtn.SetActive(true);
            volcanoBtn.SetActive(true);
            tsunamiBtn.SetActive(true);
            tornadoBtn.SetActive(true);
            
        }
        public void btnDes()
        {
            stormBtn.SetActive(false);
            volcanoBtn.SetActive(false);
            tsunamiBtn.SetActive(false);
            tornadoBtn.SetActive(false);
            
        }
        public void Lightninggg()
        {
            lightningOBJ.GetComponent<LightningScriptHandler>().LighningFire();
            lightningOBJ.transform.GetChild(0).GetComponent<LightningBoltScript>().Trigger();
            lightningOBJ.transform.GetChild(1).GetComponent<LightningBoltScript>().Trigger();
            lightningOBJ.transform.GetChild(2).GetComponent<LightningBoltScript>().Trigger();
        }
    }
}
