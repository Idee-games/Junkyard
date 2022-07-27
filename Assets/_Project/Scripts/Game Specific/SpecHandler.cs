using UnityEngine;

public class SpecHandler : MonoBehaviour
{
    public Sprite[] resourcesImg;
    public SpriteRenderer icon;
    public TextMesh value;

    public void SetIcon(int _val) {

        icon.sprite = resourcesImg[_val];
    }

    public void SetVal(string _str)
    {
        value.text = _str;
    }
}
