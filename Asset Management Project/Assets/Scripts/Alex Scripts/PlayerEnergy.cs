using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEnergy : MonoBehaviour
{
    public int maxEnergy;
    public int currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnergyRegen", 1f, 1f);
        currentEnergy = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void EnergyRegen()
    {
        if(currentEnergy < maxEnergy)
        {
            currentEnergy++;
        }
    }

}
