using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CropSprites", menuName = "CropSprites")]
public class CropSprites : ScriptableObject
{

    public Sprite[] cropArray = new Sprite[3];
}
