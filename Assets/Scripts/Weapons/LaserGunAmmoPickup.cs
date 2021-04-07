using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunAmmoPickup : MonoBehaviour
{
    
    public GameObject fakeAmmoClip;
    public AudioSource ammoPickupSound;

    void OnTriggerEnter(Collider other)
    {
        
        fakeAmmoClip.SetActive(false);
        ammoPickupSound.Play();
        GlobalAmmo.laserGunAmmo += 5;
    }
}
