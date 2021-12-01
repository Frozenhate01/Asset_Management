using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSN_Score : MonoBehaviour
{
    public static int scoreTotal = 100000;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "" + scoreTotal;
    }

    // Add 10 score value to score total on enemy destory
    // GSN_Score.scoreTotal += 10;
}
