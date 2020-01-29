using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {

   
    public Sprite level1, level2, level3;
    private int missingMoney;
    private Player player;
    private PlayerUI UIManager;
    //private MerchantManager merchant;
   private  SpriteRenderer sr;
    // Use this for initialization
    void Start ()
    {
        hideHousePanel();
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = level1;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        UIManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
        // merchant = GameObject.FindGameObjectWithTag("House").GetComponent<MerchantManager>();
    }


    public void loadLevel2House()
    {
        if (player.getMoney() >= player.getLv2Money())
        {
            player.updateMoney(-player.getLv2Money());
            UIManager.LVL2_BTN.SetActive(false);
            UIManager.LVL3_BTN.SetActive(true);
            sr.sprite = level2;
            //!!!!
        }
        else
        {
            UIManager.setCurrMoneyLv2();
            //player.setLevel2Text();
            // print("You are missing : " + player.missingMoneyLevel2(missingMoney));
        }

    }

    public void loadLevel3House()
    {
        if (player.getMoney() >= player.getLv3Money())
        {
            player.updateMoney(-player.getLv3Money());
            UIManager.LVL3_BTN.SetActive(false);
            sr.sprite = level3;
        }
        else
        {
            UIManager.setCurrMoneyLv3();
            // player.setLevel3Text();
            //print("You are missing : " + player.missingMoneyLevel3(missingMoney));
        }
    }
    //Below functions to manage the house/merchant menus
    private void OnMouseDown()
    {
        //housePanel.gameObject.SetActive(true);
        UIManager.setHouseMenu(true);
    }

    public void hideHousePanel()
    {
        //housePanel.gameObject.SetActive(false);
    }

   
}
