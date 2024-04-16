using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
   public bool goalMet = false;
   public bool boxIn = false;
   void start()
   {
    goalMet = false;
    boxIn = false;
   }

   void OnTriggerEnter(Collider co)
   {
      if(co.gameObject.tag == "Box")
      {
         print("BOXED");
          boxIn = true;
          Material mat = GetComponent<Renderer>().material;
          Color c = mat.color;
          c.a = 1;
          mat.color = c;
      }

   }

   void Update()
   {
      if(boxIn == true)
      {
         goalMet = true;
      }
   }
}
