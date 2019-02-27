using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    [SerializeField]
    public GameObject stick;
    public Transform stickPos;
    public Transform stickPos2;

    public Text goldShow;
    public Text FishCountShow;
    public static bool Notpause;
    public GameObject pauseMenu;
    public static int Fisherman = 1;
    public static float FishermanGold;

    // Use this for initialization
    void Start()
    {
        Notpause = true;
    }

    // Update is called once per frame
    public void Update()
    {
        goldShow.text = "Gold: " + Merchant.gold.ToString("F0");
        FishCountShow.text = "Fish: " + FishScript.fishCount.ToString();

        if (Input.GetKeyDown("escape"))
        {
            if (Notpause == true)
            {
                Time.timeScale = 0.0f;
                pauseMenu.gameObject.SetActive(true);
                
                Notpause = false;
            }
            else
            {
                Time.timeScale = 1.0f;
                pauseMenu.gameObject.SetActive(false);
                Notpause = true;
            }
        }

        
    }

    public void FixedUpdate()
    {
        if (Fisherman > 1)
        {
            FishermanGold = +Time.deltaTime * 0.1f * Fisherman;
            Merchant.gold += FishermanGold;
        }
    }

    public void Resume()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Notpause = true;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void quit()
    {
        EditorApplication.isPlaying = false;
    }

    public void stickBuy()
    {
        stick = Instantiate(stick);
    }

}
