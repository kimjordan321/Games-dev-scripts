using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHighScore : MonoBehaviour
{

    public Text scoreText;

    void Update()
    {
        print(Merchant.gold);
        scoreText.text = "Your Final Gold Amount: " + Merchant.gold.ToString();

    }
}

