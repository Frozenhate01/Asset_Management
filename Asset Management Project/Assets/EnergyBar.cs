using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] Image fillBar;

    PlayerEnergy playerEnergy;

    private void Awake()
    {
        fillBar = transform.Find("Fill").GetComponent<Image>();

        playerEnergy = new PlayerEnergy();
    }

    private void Update()
    {

    }

}
