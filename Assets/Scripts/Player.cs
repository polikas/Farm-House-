using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public const int LEVEL2_HOUSE = 15000;
    public const int LEVEL3_HOUSE = 25000;
    public const int PLAYER_MAX_MONEY = 100000;
    public Texture2D cursorTexture;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    private int playerMoney;
    private int playerCrops;
    private PlayerUI UIManager;
   //Initialisation
    void Start ()
    {
        UIManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
        playerMoney = 5000;
        playerCrops = 0;
        print(this.getMoney());
        UIManager.updateMoneyUI(this.getMoney());
        UIManager.updateCropsUI(this.getCurrentCrops());
    }
	
	// Update is called once per frame
	void Update ()
    {
        //this.transform.position += this.transform.right * Time.deltaTime;
	}
    public int getCurrentCrops() { return this.playerCrops; }
    public void setCurrentCrops(int i) { this.playerCrops = i; }
    public int getMoney() { return playerMoney; }
    public int getLv2Money() { return LEVEL2_HOUSE; }
    public int getLv3Money() { return LEVEL3_HOUSE; }
    public void updateMoney(int amount) //amount number must include plus or minus sign
    {
        if(amount + playerMoney >= PLAYER_MAX_MONEY)
        {
            playerMoney = PLAYER_MAX_MONEY;
        }
        else if(amount + playerMoney <= 0)
        {
            playerMoney = 0;
        }
        else
        {
            playerMoney += amount;
            //UI and other stuff [!]
         
        }
        UIManager.updateMoneyUI(this.getMoney());
        print(this.getMoney());
    }

    public void updateCrops(int amount)
    {
        if(amount + playerCrops <= 0)
        {
            setCurrentCrops(0);
        }
        else
        {
            this.playerCrops += amount;
        }
        UIManager.updateCropsUI(this.getCurrentCrops());
    }

    //Mouse raycast interaction [!]
    // Calclulate missing money for level 2
    public int missingMoneyLevel2(int pMoney)
    {
        //missingAmount = LEVEL2_HOUSE - playerMoney;
        return LEVEL2_HOUSE - pMoney;
    }
    // Calclulate missing money for level 3
    public int missingMoneyLevel3(int pMoney)
    {
        
        return LEVEL3_HOUSE - pMoney;
    }
    /*
    public void setLevel2Text()
    {
        UIManager.level2.text = "Need more : " + missingMoneyLevel2(playerMoney).ToString() + " $ ";
    }

    public void setLevel3Text()
    {
        UIManager.level3.text = "Need more : " + missingMoneyLevel3(playerMoney).ToString() + " $ ";
    }
    */
    
}
