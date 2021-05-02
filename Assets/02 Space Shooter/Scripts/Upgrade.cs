using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    [SerializeField] public Sprite[] upgradeCollection;

    private string effectName;
    private static UpgradeController upgradeController;
    
    void OnEnable()
    {
        float decider = UnityEngine.Random.value;
        if (decider > 0.5f)
        {
            // Heal
            this.GetComponent<SpriteRenderer>().sprite = upgradeCollection[1];
            effectName = "HEAL";
        }
        else
        {
            // Bigger Laser
            this.GetComponent<SpriteRenderer>().sprite = upgradeCollection[0];
            effectName = "BIG";
        }
    }

    // Update is called once per frame
    public string GetEffect()
    {
        return effectName;
    }
}
