using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGunFire : MonoBehaviour
{
  public GameObject theGun;
  public GameObject laserFlash;
  public AudioSource laserFire;
  public bool isFiring = false;
  public AudioSource emptySound;
  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      if (GlobalAmmo.laserGunAmmo < 1)
      {
        emptySound.Play();
      }
      else
      {
       if (isFiring == false)
      { 
          StartCoroutine(FiringGun());
        }
      }

    }
  }
  IEnumerator FiringGun()
  {
    isFiring = true;
    GlobalAmmo.laserGunAmmo -= 1;
    theGun.GetComponent<Animator>().Play("RayGun");
    laserFlash.SetActive(true);
    laserFire.Play();
    yield return new WaitForSeconds(.05f);
    laserFlash.SetActive(false);
    yield return new WaitForSeconds(.04f);
    theGun.GetComponent<Animator>().Play("New State");
    isFiring = false;

  }
}
