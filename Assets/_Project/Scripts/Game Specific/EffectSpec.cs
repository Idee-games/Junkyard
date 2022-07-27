using UnityEngine;

public class EffectSpec : MonoBehaviour
{
    public TextMesh value;

    private void Start()
    {
        SetVal("+" + (Toolbox.DB.prefs.ResourceGatherLevel + 1).ToString());
    }
    public void SetVal(string _str)
    {
        value.text = _str;
    }
}
