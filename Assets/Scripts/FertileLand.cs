using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FertileLand : MonoBehaviour
{
    public const int GROWTH_COOLDOWN = 5; // ! ! !
    public CropSprites CROP_SPRITES;
    private SpriteRenderer[] currentSprites;
    private PlayerUI UIcontrol;
    private Player playerInstance;
    private bool isGrowing;
    private bool isReady;
    private bool isFull;
    private bool isContested;
	void Start ()
    {
        isFull = false;
        isGrowing = false;
        isReady = false;
        isContested = false;
        playerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        currentSprites = this.GetComponentsInChildren<SpriteRenderer>();
        for(int i = 0; i < currentSprites.Length; i++)
        {
            currentSprites[i].sprite = CROP_SPRITES.cropArray[0]; //empty fertile land
        }
    
    }
	

	void Update ()
    {
		
	}
    public bool getLandStatus() { return this.isFull; }
    public void setLandStatus(bool b) { this.isFull = b; }
    public bool getContestedStatus() { return this.isContested; }
    public void setContestedStatus(bool b) { this.isContested = b; }
    private void OnMouseUp()
    {
        /*
        for (int i = 0; i < currentSprites.Length; i++)
        {
            currentSprites[i].sprite = CROP_SPRITES.cropArray[1]; //empty fertile land
        }
        */
        if (!isGrowing)
        {
            UIcontrol = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PlayerUI>();
            UIcontrol.setCropMenu(true, this);          
        }
        if(isReady && !isContested)
        {
            this.Harvest();
        }
    }
    public void Plant()
    {
        setLandStatus(true);
        isGrowing = true;
     for (int i = 0; i < currentSprites.Length; i++)
     {
         currentSprites[i].sprite = CROP_SPRITES.cropArray[1]; //empty fertile land
            UIcontrol.setCropMenu(false, this);
     }
        StartCoroutine(initiateGrowth());
    }
    private void onGrowth()
    {
        isReady = true; //grown and ready
        for (int i = 0; i < currentSprites.Length; i++)
        {
            currentSprites[i].sprite = CROP_SPRITES.cropArray[2]; //empty fertile land
            
        }
    }
    private IEnumerator initiateGrowth()
    {
        yield return new WaitForSeconds(GROWTH_COOLDOWN);
        this.onGrowth();
    }
    private void Harvest()
    {
         
        setLandStatus(false);
        isReady = false; 
        isGrowing = false; //reset so the player can plant again
       //Player player =  GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerInstance.updateCrops(+4); //add 4 crops to player inventory
        for (int i = 0; i < currentSprites.Length; i++)
        {
            currentSprites[i].sprite = CROP_SPRITES.cropArray[0]; //empty fertile land
        }
    }
    public void harvestDestroy()
    {
        //[!] numbers
        isReady = false;
        isGrowing = false;
        isFull = false;
        for (int i = 0; i < currentSprites.Length; i++)
        {
            currentSprites[i].sprite = CROP_SPRITES.cropArray[0]; //empty fertile land
        }
    }
}
