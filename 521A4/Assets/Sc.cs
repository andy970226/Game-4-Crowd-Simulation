using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sc : MonoBehaviour {
    private Rigidbody rb;
    public float speed=5;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, 0.0f, moveV);

        rb.AddForce(movement * speed);
    }
}
