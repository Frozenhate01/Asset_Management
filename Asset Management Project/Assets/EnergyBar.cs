using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] Image fillBar;

    public PlayerEnergy playerEnergy;

    private void Awake()
    {
        playerEnergy = GameObject.Find("Player").GetComponent<PlayerEnergy>();
    }

    private void Update()
    {
        fillBar.fillAmount = playerEnergy.currentEnergy / 10;
        Debug.Log(playerEnergy.currentEnergy / 10);
    }

}
