﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalAmmo : MonoBehaviour
{
   public static int laserGunAmmo;
   public GameObject ammoDisplay;



    // Update is called once per frame
    void Update()
    {
        ammoDisplay.GetComponent<Text>().text = "" + laserGunAmmo;
    }
}
