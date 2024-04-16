using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forklift : MonoBehaviour
{
    Vector3 forkL;
    static public bool goRight = true;
    static public bool goLeft  = false;
    private Rigidbody rb;
    bool grounded = true;
    [Header("Set in Inspector")]
    public float speedMult = 5f;
    public float forkSpeed = 3f;

     void start()
     {
       rb = GetComponent<Rigidbody>();
     }

    void FixedUpdate()
    {
        forkL = transform.localPosition;
        forkL.x += Input.GetAxis("Horizontal") * Time.deltaTime * speedMult;

         if(Input.GetAxis("Horizontal") > 0 && goRight == false)
        {
            transform.Rotate(0,-180,0);
            goRight = true;
            goLeft  = false;
        }

        if(Input.GetAxis("Horizontal") < 0  && goLeft == false)
        {
            transform.Rotate(0,180,0);
            goLeft = true;
            goRight= false;
        
        }

        GameObject forks = GameObject.Find("Forks");
        Vector3 fl = forks.transform.localPosition;
        if(Input.GetAxis("Vertical") > 0 && fl.y < 3f)
        {
            //move forks up
            fl.y += Input.GetAxis("Vertical") * Time.deltaTime * (forkSpeed);
        }

        if(Input.GetAxis("Vertical") < 0 && fl.y > -2.6f)
        {
            fl.y += Input.GetAxis("Vertical") * Time.deltaTime * (forkSpeed);
        }

        transform.localPosition = forkL;
        forks.transform.localPosition = fl;
    }

    void Update()
    {
        rb = GetComponent<Rigidbody>();

      if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            grounded = false;
            rb.AddForce(0,50f,0,ForceMode.Impulse);
        }  

    }
    void OnCollisionStay(Collision col)
    {
        if(col.gameObject.tag == "jumpable")
        {
            grounded = true;
        }
    }


}
 