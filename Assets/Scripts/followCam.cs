using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
   public GameObject FL;
   public Vector3 vec;
    void Start()
    {
        vec = transform.position - FL.transform.position;
    }
    void LateUpdate()
    {
       transform.position = FL.transform.position + vec; 
    }
}
