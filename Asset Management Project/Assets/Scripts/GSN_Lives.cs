using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GSN_Lives : MonoBehaviour
{
    public static int lives = 3;
    public Text numberOfLives;

    // Start is called before the first frame update
    void Start()
    {
        numberOfLives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        numberOfLives.text = "" + lives;
    }

    // Add 10 score value to score total on enemy destory
    // GSN_Score.scoreTotal += 10;
}
