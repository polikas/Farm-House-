using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowMovement : MonoBehaviour {

   // public GameObject crop;
    private Transform target;
    private GameObject[] potentialTargets;
    private Transform flyAway;
    private FertileLand targetedLand;
    
    private int selectedIndex = 0;
    //public Sprite sp1, sp2;
    public crowSprites crowSprites;
    //SpriteRenderer sr;
    public float speed = 1f;
    bool cropDestroyed;
    bool killBird;
    bool landed;
    float delay;
    Vector2 birdPos;
    private Sprite sprFlying, sprLanded;
    SpriteRenderer crowRenderer;

    // Use this for initialization
    void Start ()
    {
        delay = 7f;
        cropDestroyed = false;
        landed = false;
        sprFlying = crowSprites.crowArray[0];
        sprLanded = crowSprites.crowArray[1];
        crowRenderer = this.GetComponent<SpriteRenderer>();
        crowRenderer.sprite = sprFlying;
        potentialTargets = GameObject.FindGameObjectsWithTag("Crop");
       
            selectedIndex = Random.Range(0, potentialTargets.Length);
            target = potentialTargets[selectedIndex].transform;
            targetedLand = target.gameObject.GetComponent<FertileLand>();

        flyAway = GameObject.FindGameObjectWithTag("DestroyPoint").transform;
                 
        killBird = false;       
    }
	
	// Update is called once per frame
	void Update ()
    {

     

        birdPos.x = this.transform.position.x;
        birdPos.y = this.transform.position.y;
        if(killBird)
        {
            flyAwayBird();
        }
        if(cropDestroyed)
        {
            
            crowRenderer.sprite = sprFlying;
            flyAwayBird();
           

        }
        else
        {
            if(!killBird && !targetedLand.getLandStatus())
            {
              
              selectedIndex = Random.Range(0, potentialTargets.Length);
              target = potentialTargets[selectedIndex].transform;
              targetedLand = target.gameObject.GetComponent<FertileLand>();
                flyAwayBird();
            }

            if (!killBird && targetedLand.getLandStatus())
              transform.position = Vector2.MoveTowards(birdPos, target.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Crop") && other.gameObject.name == target.gameObject.name  && !killBird)
        {
            landed = true;
            crowRenderer.sprite = sprLanded;
            StartCoroutine(harmCrop());
        }
    }

    IEnumerator harmCrop()
    {
        targetedLand.setContestedStatus(true);
        yield return new WaitForSeconds(delay);
        if (!killBird)
        {
            targetedLand.harvestDestroy();
        }
        cropDestroyed = true;
        targetedLand.setContestedStatus(false);
    }

    void OnMouseDown()
    {
        

        if (!killBird)
        {
            targetedLand.setContestedStatus(false);
            killBird = true;
            StopCoroutine(harmCrop());
         
        }
    }

    void flyAwayBird()
    {
        crowRenderer.sprite = sprFlying;
        transform.position = Vector2.MoveTowards(birdPos, flyAway.transform.position, speed * Time.deltaTime);
        if (flyAway.transform.position == transform.position)
        {
            Destroy(gameObject);
        }
    }
}
