using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cropland : MonoBehaviour
{
    [SerializeField]
    private bool isLocked;
    private Collider2D croplandCollider;
    //private SpriteRenderer[] land;
    //private int landSeriesNumber;
    void Start ()
    {
        //isLocked = true; [!]
        croplandCollider = GetComponent<Collider2D>();
        unlockCropland(!isLocked); // [!]
        //landSeries = GetComponentsInChildren<SpriteRenderer>();
       // print(landSeries.Length);
       // print(landSeries[0].gameObject.name);
        //print(landSeries[landSeries.Length - 1].gameObject.name);
    }
    
	
	
	void Update ()
    {
		
	}
    private void OnMouseOver()
    {
        print(isLocked);
    }
    public void setLock(bool b) { this.isLocked = b; }
    public void unlockCropland(bool b)
    {
        croplandCollider.enabled = b;
    }
}
