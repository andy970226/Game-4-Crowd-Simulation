using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wandermove : MonoBehaviour
{
    float Speed_move = 0;
    float Speed_rot = 80;
    public GameObject detect1;
    public GameObject detect2;
    public GameObject detect3;
    public GameObject detect4;
    public GameObject detect5;
    public GameObject detect6;
    public GameObject detect7;

    bool arrive;
    float acc_go = 4;//cause force is propotional to accelerate, here we use acc to name the parameter.
    float acc_back = 10;

    float rate = 3f;
    float next = 0;
    // Use this for initialization
    void Awake()
    {
        Speed_move = 0;
        travellers = GameObject.FindGameObjectsWithTag("traveller");
        thistime = false;
        interpolate = false;
        arrive = false;
    }
    bool leftorright; //steer when collide
    bool straight;// while wander steer or not
    bool leftorright2;// steer when wander
    bool thistime;// one time collide
    bool interpolate;//one time imterpolatetraveller
    GameObject traveller;
    GameObject[] travellers;
    Vector3 aim;
    // Update is called once per frame
    void Update()
    {

        Speed_move += acc_go * Time.deltaTime;
        if (Speed_move > 12) Speed_move = 12;

        if (detect1.GetComponent<Boundsin>().rendererIsInsideTheBox || detect2.GetComponent<Boundsin>().rendererIsInsideTheBox || detect3.GetComponent<Boundsin>().rendererIsInsideTheBox || detect4.GetComponent<Boundsin>().rendererIsInsideTheBox || detect5.GetComponent<Boundsin>().rendererIsInsideTheBox || detect6.GetComponent<Boundsin>().rendererIsInsideTheBox || detect7.GetComponent<Boundsin>().rendererIsInsideTheBox)
        {
            if (thistime)
            {
                if (leftorright)
                    this.transform.Rotate(Vector3.up * Time.deltaTime * -Speed_rot);
                else
                    transform.Rotate(Vector3.up * Time.deltaTime * Speed_rot);
            }
            else
            {
                thistime = true;
                leftorright = Random();
            }
            Speed_move -= acc_back * Time.deltaTime;
                  if (Speed_move < -2) Speed_move = -2;
            //Speed_move += acc_back * Time.deltaTime;
           // if (Speed_move > 8) Speed_move = 8;
        }
        else
        {
            thistime = false;
            if (!interpolate)
                foreach (GameObject tr in travellers) {
                    if ((tr.transform.position - transform.position).magnitude < 8)
                    {
                        traveller = tr;
                        interpolate = true;
                        aim = tr.transform.position+traveller.transform.forward * 8;
                        arrive = false;
                        break;
                    }
                }
            else
            { if ((traveller.transform.position - transform.position).magnitude >10)
                {
                    interpolate = false;
                }
            
            }




            if (!interpolate)
            {
                if (Time.time > next)
                {
                    leftorright2 = Random();
                    straight = Random();
                    next = Time.time + rate;
                }
                if (!straight)
                {
                    if (leftorright2)
                        this.transform.Rotate(Vector3.up * Time.deltaTime * -Speed_rot / 2);
                    else
                        transform.Rotate(Vector3.up * Time.deltaTime * Speed_rot / 2);
                }
            }
            else {
                aim = traveller.transform.position + traveller.transform.forward * 6;
                Vector3 dir = (aim - transform.position);
                if (dir.magnitude > 0.5&&arrive==false)
                {
                Quaternion newRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Speed_rot * Time.deltaTime);
                
                
                }
                else {
                    arrive = true;
                        if (Mathf.Abs(Speed_move)<1||Speed_move<0)
                        Speed_move = 0;
                        else
                    Speed_move -= acc_back * Time.deltaTime*6;
                    
                }


            }
        }
        



        this.transform.Translate(0, 0, Vector3.forward.z * Time.deltaTime * Speed_move);
        
    }


    void OnTriggerEnter(Collider other)
    {
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

        return getRangeNum>30.5;
    }
}
