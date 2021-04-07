using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAi : MonoBehaviour
{

    public string hitTag;
    public bool lookingAtPlayer = false;
    public  GameObject star; 
    public AudioSource laserSound;
    public bool isFiring = false;
    public float fireRate = 1.5f;
    public Transform m_muzzle;
	public GameObject m_shotPrefab;

    // Update is called once per frame
    void Update() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit)) {
            hitTag = hit.transform.tag;
        }
        
        if (hitTag == "MainCamera" && isFiring == false){
            StartCoroutine(EnemyFire());
        } 
        if (hitTag != "MainCamera") {
            // star.GetComponent<Animator>()Play("Idle");
            lookingAtPlayer =false;
        }
    }
    
    IEnumerator EnemyFire() {
        isFiring = true;
        // star.GetComponent<Animator>()Play("FireLaser");
        GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
			GameObject.Destroy(go, 3f);
        laserSound.Play();
        lookingAtPlayer = true;
        GlobalHealth.healthValue -= 5;
        yield return new WaitForSeconds(fireRate);
        isFiring = false;
    }
}
