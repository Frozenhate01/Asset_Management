using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinPicker : MonoBehaviour
{
    [SerializeField] public static float coin = 0;

    public TextMeshProUGUI textCoins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            FindObjectOfType<GSN_AudioManager>().Play("Coin");
            coin = coin + 50;
            
            Destroy(collision.gameObject);

        }
    }

    private void Update()
    {
        textCoins.text = coin.ToString("0000");
    }
}
