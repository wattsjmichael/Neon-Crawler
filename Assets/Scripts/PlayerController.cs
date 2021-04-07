using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{

  Vector3 pos;                                // For movement
  public float speed = 7.0f;                         // Speed of movement
  public float movementRange = 2.0f;
  public Transform relativeTransform;
  private Vector3 lastPos;
  public Rigidbody rb;
  IEnumerator RotateMe(Vector3 byAngles, float inTime)
  {
    var fromAngle = transform.rotation;
    var toAngle = Quaternion.Euler(transform.eulerAngles + byAngles);
    for (var t = 0f; t < 1; t += Time.deltaTime / inTime)
    {
      // rb.MoveRotation(Quaternion.Slerp(fromAngle, toAngle, t));
      transform.rotation = Quaternion.Slerp(fromAngle, toAngle, t);
      // yield return null;
      yield return new WaitForFixedUpdate();
    }
  }


// void OnTriggerEnter(Collider other)
// {
//     if(other.gameObject.tag == "Wall")
//     rb.isKinematic = true;
// }

  void OnCollisionEnter(Collision collision)

  {
    if (collision.gameObject.CompareTag("Wall"))
    {
      StopAllCoroutines();
      // rb.isKinematic = true;
      rb.position = lastPos;
      // this.transform.position = lastPos;
      // rb.isKinematic = true;
      // rb.detectCollisions = true;
      rb.velocity = Vector3.zero;
      pos = lastPos;
      Debug.Log("You hit a wall!");

    }
  }


   void Awake()
  {
    Application.targetFrameRate = 30;


  }
  void Start()
  {
    pos = transform.position; 
    rb = GetComponent<Rigidbody>();         // Take the initial position
  }



  void FixedUpdate()
  {
    if (Input.GetKeyDown(KeyCode.A) && transform.position == pos)
    {        // Left

      pos += -relativeTransform.right * (movementRange);


    }
    else if (Input.GetKeyDown(KeyCode.D) && transform.position == pos)
    {        // Right
      pos += relativeTransform.right * (movementRange);
    }
    else if (Input.GetKeyDown(KeyCode.W) && transform.position == pos)
    {        // Up
      pos += relativeTransform.forward * (movementRange);
    }
    else if (Input.GetKeyDown(KeyCode.S) && transform.position == pos)
    {        // Down
      pos += -relativeTransform.forward * (movementRange);

    }
    else if (Input.GetKeyDown(KeyCode.Q) && transform.position == pos)
    {
      StopAllCoroutines ();
      StartCoroutine(RotateMe(Vector3.up * -90, 0.8f));
    } //Rotate Left

    else if (Input.GetKeyDown(KeyCode.E) && transform.position == pos)
    {
      StopAllCoroutines ();
      StartCoroutine(RotateMe(Vector3.up * 90, 0.8f));
    } //Rotate Right
    
    else if (Input.GetKeyDown(KeyCode.Escape) == true)
    {        
      Application.Quit();

    }

    transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);    // Move there
    // rb.MovePosition(Vector3.MoveTowards(rb.position, pos, Time.deltaTime * speed));
  }

}