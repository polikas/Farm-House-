using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject houseMenuPanel;
    public Button growButton, exitButton, sellButton;
    public Text screenText;
    //  public Text level2, level3;
    public GameObject LVL2_BTN, LVL3_BTN;
    public Text currMonLevel2, currMonLevel3; //error messages
    public Text moneyText, cropsText, menuCropsText;
    private FertileLand landtoPlant;
    private Player player;
    private HouseManager house;
    //private UnityAction m_FirstAction;
    void Start ()
    {
        screenText.gameObject.SetActive(false);
        houseMenuPanel.SetActive(false);
        menuCropsText.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        menuCropsText.gameObject.SetActive(false);
        growButton.gameObject.SetActive(false);
        LVL2_BTN.gameObject.SetActive(false);
        LVL3_BTN.gameObject.SetActive(false);
        // level2.gameObject.SetActive(false);
        // level3.gameObject.SetActive(false);
        currMonLevel2.gameObject.SetActive(false);
        currMonLevel3.gameObject.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        landtoPlant = GameObject.FindGameObjectWithTag("Crop").GetComponent<FertileLand>();
        house = GameObject.FindGameObjectWithTag("House").GetComponent<HouseManager>();
        menuCropsText.text = "Crops: " + player.getCurrentCrops();
        moneyText.color = Color.green;
        cropsText.color = Color.yellow;
    }
	
	
	void Update ()
    {
		
	}
    public void updateMoneyUI(int currMoney)
    {
        moneyText.text = "Money: " + currMoney + "$";
    }
    public void updateCropsUI(int currCrops)
    {
        cropsText.text = "Crops: " + currCrops;
    }
    public void setCropMenu(bool b, FertileLand tempLand)
    {
        houseMenuPanel.SetActive(b);
        // [!] other buttons disable

        // level2.gameObject.SetActive(!b);
        // level3.gameObject.SetActive(!b);
        LVL2_BTN.gameObject.SetActive(!b);
        LVL3_BTN.gameObject.SetActive(!b);
        currMonLevel2.gameObject.SetActive(!b);
        currMonLevel3.gameObject.SetActive(!b);      
        exitButton.gameObject.SetActive(!b);
        menuCropsText.gameObject.SetActive(!b);        
        sellButton.gameObject.SetActive(!b);

        exitButton.gameObject.SetActive(b);
        growButton.gameObject.SetActive(b);
        landtoPlant = tempLand;
       
       
    }
    public void setHouseMenu(bool b) //ready for transaction
    {
        houseMenuPanel.SetActive(b);
        menuCropsText.text = "Crops: " + player.getCurrentCrops();
        menuCropsText.gameObject.SetActive(b);
        LVL2_BTN.gameObject.SetActive(b);
        LVL3_BTN.gameObject.SetActive(b);
        growButton.gameObject.SetActive(!b);

        exitButton.gameObject.SetActive(b);
       
        //level2.gameObject.SetActive(b);
        //level3.gameObject.SetActive(b);
        currMonLevel2.gameObject.SetActive(!b);
        currMonLevel3.gameObject.SetActive(!b);
    }
    public void growButtonEvent()
    {
        landtoPlant.Plant();

    }

    public void setCurrMoneyLv2()
    {
        currMonLevel2.gameObject.SetActive(true);
        currMonLevel2.text = "Need " + player.missingMoneyLevel2(player.getMoney()) + "$ to upgrade!";
    }

    public void setCurrMoneyLv3()
    {
        currMonLevel3.gameObject.SetActive(true);
        currMonLevel3.text = "Need " + player.missingMoneyLevel3(player.getMoney()) + "$ to upgrade!";
    }
    public void sellButtonAction()
    {
        int earning = player.getCurrentCrops() * 100;
        player.updateCrops(-player.getCurrentCrops());
        menuCropsText.text = "Crops: " + player.getCurrentCrops();
        player.updateMoney(earning);
    }
    public void exitButtonAction()
    {
        houseMenuPanel.SetActive(false);
    }

}
