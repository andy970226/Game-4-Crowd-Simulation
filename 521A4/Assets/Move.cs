using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    float Speed_move = 0;
    float Speed_rot = 80;
    public GameObject detect1;
    public GameObject detect2;
    public GameObject detect3;
    public GameObject detect4;
    public GameObject detect5;
    public GameObject detect6;
    public GameObject detect7;

    float changerate = 30;
    float change = 0;
    float acc_go = 2;//cause force is propotional to accelerate, here we use acc to name the parameter.
    float acc_back = 10;

    Vector3 aim;
    Vector3 aim1 = new Vector3(-50, 1, 12);
    Vector3 aim2 = new Vector3(-50, 1, -12);
    bool leftorright; //steer when collide
    // Use this for initialization
    void Awake () {
        Speed_move = 0;
        leftorright = Random();
        if (Random())
            aim = aim1;
        else
            aim = aim2;
        change = changerate;
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time > change) {
            Debug.Log("Long time");
            if (aim == aim1)
            { aim = aim2; }
            else
                aim = aim1;
            change = change + changerate;
            leftorright = !leftorright;
        }
        Speed_move += acc_go * Time.deltaTime;
        if (Speed_move > 5) Speed_move -= acc_back * Time.deltaTime; ;

        if (detect1.GetComponent<Boundsin>().rendererIsInsideTheBox || detect2.GetComponent<Boundsin>().rendererIsInsideTheBox || detect3.GetComponent<Boundsin>().rendererIsInsideTheBox || detect4.GetComponent<Boundsin>().rendererIsInsideTheBox || detect5.GetComponent<Boundsin>().rendererIsInsideTheBox || detect6.GetComponent<Boundsin>().rendererIsInsideTheBox || detect7.GetComponent<Boundsin>().rendererIsInsideTheBox)
        {
            if(leftorright)
            this.transform.Rotate(Vector3.up * Time.deltaTime * -Speed_rot);
            else
                transform.Rotate(Vector3.up * Time.deltaTime * Speed_rot);
            //Speed_move -= acc_back * Time.deltaTime;
            //      if (Speed_move < 2) Speed_move = 2;
            Speed_move += acc_go * Time.deltaTime;
            if (Speed_move > 8) Speed_move = 8;
        }
        else
        {
            Vector3 dir = (aim - transform.position);
            Quaternion newRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Speed_rot * Time.deltaTime);
            

        }
        
                this.transform.Translate(0,0,Vector3.forward.z * Time.deltaTime * Speed_move);

        
 

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door"))
        {
            transform.position=new Vector3(49,1,0);
            transform.forward = new Vector3(-1, 0, 0);
            if (Random())
                aim = aim1;
            else
                aim = aim2;

            leftorright = Random();
            change = Time.time + changerate;
            Debug.Log("Enter");
        }
    }


    int getRangeNum = 0;
    int rangeRadomNum = 0;

    bool Random()
    {
        do
        {
            rangeRadomNum = UnityEngine.Random.Range(1, 60);
        }
        while (getRangeNum == rangeRadomNum);
        getRangeNum = rangeRadomNum;

        return getRangeNum > 30.5;
    }
}
