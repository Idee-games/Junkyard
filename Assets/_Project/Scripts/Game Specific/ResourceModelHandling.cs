using UnityEngine;

public class ResourceModelHandling : MonoBehaviour
{
    public GameObject[] models;

    private void Start()
    {
        int num = Toolbox.GameplayScript.levelsManager.CurLevelData.environmentNumber;
        for (int i = 0; i < models.Length; i++)
        {
            if (i == num) {

                models[i].gameObject.SetActive(true);
            }
            else { 
                models[i].gameObject.SetActive(false);
            }
        }
    }
}
