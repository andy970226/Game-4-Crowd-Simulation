using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Social : MonoBehaviour
{
    public float Speed_move = 0;
    float Speed_rot = 80;
    public GameObject detect1;
    public GameObject detect2;
    public GameObject detect3;
    public GameObject detect4;
    public GameObject detect5;
    public GameObject detect6;
    public GameObject detect7;


    float acc_go = 2;//cause force is propotional to accelerate, here we use acc to name the parameter.
    float acc_back = 10;

    float rate = 3f;
    float next = 0;

 public bool notcooling;
    float cooling = 10f;
    float endcooling=0;
    float grouptime;


    public int mode;//mode=0,1,2

    // Use this for initialization
    void Awake()
    {
        Speed_move = 0;
        socials = GameObject.FindGameObjectsWithTag("Social");
        thistime = false;
        leftorright = Random();
notcooling=true;
        mode = 0;

    }
    bool leftorright; //steer when collide
    bool straight;// while wander steer or not
    bool leftorright2;// steer when wander
    bool thistime;// one time collide

    public GameObject social;
    GameObject[] socials;
    Vector3 aim;
    // Update is called once per frame
    void Update()
    {
        if (mode == 0)
        {   
            Speed_move += acc_go * Time.deltaTime;
            if (Speed_move > 5) Speed_move -=acc_back*Time.deltaTime;

            if (detect1.GetComponent<Boundsin>().rendererIsInsideTheBox || detect2.GetComponent<Boundsin>().rendererIsInsideTheBox || detect3.GetComponent<Boundsin>().rendererIsInsideTheBox || detect4.GetComponent<Boundsin>().rendererIsInsideTheBox || detect5.GetComponent<Boundsin>().rendererIsInsideTheBox || detect6.GetComponent<Boundsin>().rendererIsInsideTheBox || detect7.GetComponent<Boundsin>().rendererIsInsideTheBox)
            {
                if (thistime)
                {
                    if (leftorright)
                        this.transform.Rotate(Vector3.up * Time.deltaTime * 2*-Speed_rot);
                    else
                        transform.Rotate(Vector3.up * Time.deltaTime *2* Speed_rot);
                    if (Time.time > next) leftorright = !leftorright;
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
            
            
            if (Mathf.Abs( Time.time - endcooling) <0.1)notcooling = true;

            if (notcooling)
            {
                foreach (GameObject sc in socials)
                {
                    if ((sc.transform.position - transform.position).magnitude < 10 && sc != this.gameObject && sc.GetComponent<Social>().notcooling)
                    {

                        social = sc;
                        sc.GetComponent<Social>().social = this.gameObject;
                        sc.GetComponent<Social>().mode = 1;
                        aim = social.transform.position;
                        mode = 1;
                        break;

                    }
                }
            }
            this.transform.Translate(0, 0, Vector3.forward.z * Time.deltaTime * Speed_move);
            //   }
        }
        else if (mode == 1)
        {
            Speed_move += acc_go * Time.deltaTime;
            if (Speed_move > 10) Speed_move = 10;
            aim = social.transform.position;
            Vector3 dir = (aim - transform.position);
            if (dir.magnitude < 3)
            {

                social.GetComponent<Social>().Speed_move = 0;
                mode = 2;
                grouptime = Time.time + Randomtime();
                endcooling = grouptime + cooling;
                Speed_move = 0;

            }
            else
            {
                Quaternion newRotation = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Speed_rot * 3 * Time.deltaTime);
               
            }
            if (dir.magnitude >13)
            {
                mode = 0;
            }

                this.transform.Translate(0, 0, Vector3.forward.z * Time.deltaTime * Speed_move);
        }
        else if (mode == 2)
        {
            
            if (Time.time > grouptime)
            {

                mode = 0;
                notcooling = false;
            }
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

    float Randomtime()
    {
        do
        {
            rangeRadomNum = UnityEngine.Random.Range(1, 60);
        }
        while (getRangeNum == rangeRadomNum);
        getRangeNum = rangeRadomNum;

        return (0.5f+(float)getRangeNum/40f);
    }
}
