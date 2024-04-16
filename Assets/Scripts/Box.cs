using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
  
  

  [Header("Set in Inspector")]
  public string color;
  private Rigidbody rb;
  private Transform ogParent;
  private GameObject forkL;
   bool boxFroze  = false;
   bool inContact = false;
  public float throwMult = 10.0f;
  void start()
  {
    rb = GetComponent<Rigidbody>();
    ogParent = transform.parent;
  }
  void Update()
  {
    rb = GetComponent<Rigidbody>();
    if (Input.GetKeyDown(KeyCode.Q))
    {
     if(inContact == true)
     {

      if(boxFroze == false)
      {
       forkL = GameObject.Find("Forklift");
       transform.parent = forkL.transform;
       boxFroze = true;
      }
      else if (boxFroze == true)
      {
        transform.parent = ogParent;
        boxFroze = false;
      }
     }
    }

    if (Input.GetKeyDown(KeyCode.E))
    {
      //throw box
      if(inContact == true)
      {
        if(boxFroze == true)
        {
          transform.parent = ogParent;
          boxFroze = false;
        }

       if( forklift.goLeft == true)
       {
        rb.AddForce(-throwMult,throwMult,0,ForceMode.Impulse);
       }
       else
       {
        rb.AddForce(throwMult,throwMult,0,ForceMode.Impulse);
       }
        
        
      }

    }

  }

  void OnCollisionEnter(Collision coll)
  {
   
    if(coll.gameObject.tag == "Forklift")
    {
        inContact = true;
    }
  }

  void OnCollisionExit(Collision coll)
  {
    
    if(coll.gameObject.tag == "Forklift")
    {
        inContact = false;
    }
  }

}
