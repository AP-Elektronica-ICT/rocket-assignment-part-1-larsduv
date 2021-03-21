using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
   [SerializeField] float powerForce = 10f;
   [SerializeField] float tiltForce = 10f;

   bool power = false;

    Rigidbody rb;

    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }

   private void Update(){
       float tilt = Input.GetAxis("Horizontal");
       power = Input.GetKey(KeyCode.Space);

       if (!Mathf.Approximately(tilt, 0f))
       {
            rb.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, ( tilt * tiltForce * Time.deltaTime)))); 
       }

       rb.freezeRotation = false;
   } 

   private void FixedUpdate(){
       if (power)
       {
            rb.AddRelativeForce(Vector3.up * powerForce * Time.deltaTime);   
       }
   }
}
