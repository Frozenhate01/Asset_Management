using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    private float coin = 0;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            coin = coin + 50;
            textCoins.text = coin.ToString("0000");

            Destroy(collision.gameObject);
        }
    }
}
