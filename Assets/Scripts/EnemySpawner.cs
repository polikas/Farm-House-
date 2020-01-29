using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    
    float randX;
    Vector2 whereToSpawn;
    public float spawnRate = 10f;
    float nextSpawn = 0.0f;
    
    //public Vector2 target = new Vector2(3, 3);
   
    

    // Use this for initialization
    void Start () {
       //target = crop.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-14.10f, -4.10f);
            whereToSpawn = new Vector2(randX, transform.position.y);
            Instantiate(enemy, whereToSpawn, Quaternion.identity);
        }
        
    }
}
