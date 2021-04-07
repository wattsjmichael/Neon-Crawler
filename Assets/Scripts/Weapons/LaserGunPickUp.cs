using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGunPickUp : MonoBehaviour
{
    public GameObject realRayGun;
    public GameObject fakeRayGun;
    public AudioSource rayGunPickupSound;

    void OnTriggerEnter(Collider other)
    {
        realRayGun.SetActive(true);
        fakeRayGun.SetActive(false);
        rayGunPickupSound.Play();
        GetComponent<BoxCollider>().enabled = false;
    }

}
