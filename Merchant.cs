using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Merchant : MonoBehaviour {

    [SerializeField] private GameObject shopMenu;
    public GameObject stick;
    public Transform player;

    private Vector3 stickSpawnPos;
    public static int wepDmg;

    public GameObject woodenStone;
    public int woodenStonePrice = 250;

    public GameObject miniTree;
    public int miniTreePrice = 25;

    public GameObject harpoon;
    public Text harpoonText;
    public int harpoonPrice = 500;

    public static float gold;
    [SerializeField] private GameObject sellButtonHide;
    GameObject[] gameObjects;
    public static int FishWorth;
    public GameObject scroll;

    public int MaxFishUpgradePrice = 50;
    public Text MaxFishUpgradeCost;

    public int FishSpawnTimeUpgradePrice = 50;
    public Text FishSpawnTimeUpgradeCost;

    public int FishWorthUpgradePrice = 200;
    public Text FishWorthUpgradeCost;
    public int fishWorthM = 1;

    public int BuyWinPrice = 200;
    public Text BuyWinCost;

    public float BuyFisherManPrice = 10f;
    public Text BuyFisherManCost;

   
    


    // Use this for initialization
    void Start()
    {
        FishWorth = 0;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        harpoonText.text = "Harpoon weapon can kill all fish! " + harpoonPrice +"gold";
        BuyFisherManCost.text = "This Random Guy likes catching fish and selling them for you. " + BuyFisherManPrice;
        BuyWinCost.text = "This is you winning. Costs: " + BuyWinPrice;
        FishWorthUpgradeCost.text = "This Will Multiply the worth of all fish! " + FishWorthUpgradePrice + " current multiplier = " + fishWorthM;
        MaxFishUpgradeCost.text = " This ups the max fish in the game at once. Price: " + MaxFishUpgradePrice + " current max Fish = " + spawner.maxFish;
        FishSpawnTimeUpgradeCost.text = "This halves fish spawn time. Price:" + FishSpawnTimeUpgradePrice + " Current spawn Time " + spawner.spawnTime;
    }

    public void stickBuy()
    {
        if (gold >= 0)
        {
            DestroyAllObjects();
            wepDmg = 3;
            GameObject tmp = Instantiate(stick, player.transform.position, transform.rotation);
            tmp.transform.parent = player.transform;
        }
        
    }

    public void harpoonBuy()
    {
        if (gold >= harpoonPrice)
        {
            DestroyAllObjects();
            wepDmg = 10;
            GameObject tmp = Instantiate(harpoon, player.transform.position, transform.rotation);
            tmp.transform.parent = player.transform;
        }

    }

    public void woodenStoneBuy()
    {
        if (gold >= woodenStonePrice)
        {
            DestroyAllObjects();
            wepDmg = 5;
            GameObject tmp = Instantiate(woodenStone, player.transform.position, transform.rotation);
            tmp.transform.parent = player.transform;
            gold -= woodenStonePrice;
        }

    }

    public void miniTreeBuy()
    {
        if (gold >= miniTreePrice)
        {
            DestroyAllObjects();
            wepDmg = 3;
            GameObject tmp = Instantiate(miniTree, player.transform.position, transform.rotation);
            tmp.transform.parent = player.transform;
            gold -= miniTreePrice;
        }        
    }

    public void MaxFishUpgrade()
    {
        if (gold >= MaxFishUpgradePrice)
        {
            gold = gold - MaxFishUpgradePrice;
            spawner.maxFish = spawner.maxFish + 5;
            MaxFishUpgradePrice = MaxFishUpgradePrice * 2;
            
            print(spawner.maxFish);
            
        }

    }

    public void FishSpawnTime()
    {
        if (gold >= FishSpawnTimeUpgradePrice)
        {
            gold = gold - FishSpawnTimeUpgradePrice;
            spawner.spawnTime = spawner.spawnTime * 0.5f;
            FishSpawnTimeUpgradePrice = FishSpawnTimeUpgradePrice * 2;

            print(spawner.maxFish);

        }

    }

    public void buyFishWorthx2()
    {
        if(gold >= 200)
        {
            gold = gold - FishWorthUpgradePrice;
            fishWorthM = fishWorthM + 1;
            FishWorthUpgradePrice = FishWorthUpgradePrice * 2;
        }
    }

    public void BuyWinz()
    {
        if (gold >= 200)
        {
            gold = gold - BuyWinPrice;
            Win();
            
        }
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void BuyFisherMan()
    {
        if (gold >= BuyFisherManPrice)
        {
            gold = gold - BuyFisherManPrice;
            GameController.Fisherman += 1;
            BuyFisherManPrice = BuyFisherManPrice * 1.5f;

            

        }

    }




    void OnTriggerEnter2D(Collider2D col)
    {
        shopMenu.gameObject.SetActive(true);
        sellButtonHide.gameObject.SetActive(true);
        scroll.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        shopMenu.gameObject.SetActive(false);
        sellButtonHide.gameObject.SetActive(false);
        scroll.gameObject.SetActive(false);
    }

    public void sellButton()
    {
        if (FishWorth <= 0)
        {
            FishWorth = FishWorth * fishWorthM;
            gold = gold + FishWorth;
        }
        else
        {
            FishWorth = FishWorth * fishWorthM;
            gold = gold + FishWorth;
        }
        FishWorth = 0;
        FishScript.fishCount = 0;
        
        print(FishWorth);
        print(gold);
    }

    void DestroyAllObjects()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Weapon");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }

    }
}
