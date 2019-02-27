using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{

    public float TopGold;
    public Text goldShow;

    // Use this for initialization
    void Start()
    {

        goldShow.text = "Highest Gold Ever: " + PlayerPrefs.GetFloat("Highest Gold Ever: ", 0).ToString();

    }

    // Update is called once per frame
    void Update()
    {

        TopGold = Merchant.gold;

        if (PlayerPrefs.GetFloat("Highest Gold Ever: ") < TopGold)
        {
            PlayerPrefs.SetFloat("Highest Gold Ever: ", TopGold);
            goldShow.text = "Highest Gold Ever: " + TopGold.ToString();
        }

    }


    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        goldShow.text = "0";
    }
}
