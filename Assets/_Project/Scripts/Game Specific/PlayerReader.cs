using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReader : MonoBehaviour
{ 
    public void playerReader()
    {
        Toolbox.Soundmanager.PlaySound(Toolbox.Soundmanager.running);
    }
}
