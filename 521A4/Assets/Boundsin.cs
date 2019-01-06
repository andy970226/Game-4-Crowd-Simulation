using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boundsin : MonoBehaviour {
    GameObject[] obstacles;
    public bool rendererIsInsideTheBox;
    //public Collider mycollider;
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        Vector3 pos = transform.position;
        rendererIsInsideTheBox = false;
        foreach (GameObject obstacle in obstacles)
        {
            Bounds bounds = obstacle.GetComponent<Collider>().bounds;
            if( bounds.Contains(pos))
                rendererIsInsideTheBox=true;
        }
        
        
    }
}
