using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traffic : MonoBehaviour {

    public int Travellernumber;
    public int Wandernumber;
    public int Socialnumber;
    GameObject[] obstacles;

    public bool rendererIsInsideTheBox;
    public GameObject tra;
    public GameObject wan;
    public GameObject soc;
    // Use this for initialization
    void Start () {
        Generate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Generate() {
        Travellernumber -= 1;
        Wandernumber -= 1;
        Socialnumber -= 2;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < Travellernumber; i++)
        {


            Vector3 position;
          do
            {
                 position= new Vector3((float)Random(-480, 480) / 10f, 1, (float)Random(-230, 230) / 10f);
    
                rendererIsInsideTheBox = false;
                foreach (GameObject obstacle in obstacles)
                {
                    Bounds bounds = obstacle.GetComponent<Collider>().bounds;
                    if (bounds.Contains(position))
                        rendererIsInsideTheBox = true;
                }
            } while (rendererIsInsideTheBox == true);
            GameObject tra1 = Instantiate(tra, position, Quaternion.identity) as GameObject;
        }

        for (int i = 0; i < Wandernumber; i++)
        {


            Vector3 position;
            do
            { position = new Vector3((float)Random(-480, 480) / 10f, 1, (float)Random(-230, 230) / 10f);
                rendererIsInsideTheBox = false;
                foreach (GameObject obstacle in obstacles)
                {
                    Bounds bounds = obstacle.GetComponent<Collider>().bounds;
                    if (bounds.Contains(position))
                        rendererIsInsideTheBox = true;
                }
               
            } while (rendererIsInsideTheBox == true);
            GameObject wan1 = Instantiate(wan, position, Quaternion.identity) as GameObject;
        }


        for (int i = 0; i < Socialnumber; i++)
        {

            Vector3 position;
            do
            { position = new Vector3((float)Random(-480, 480)/10f, 1, (float)Random(-230, 230)/10f);
                rendererIsInsideTheBox = false;
                foreach (GameObject obstacle in obstacles)
                {
                    Bounds bounds = obstacle.GetComponent<Collider>().bounds;
                    if (bounds.Contains(position))
                        rendererIsInsideTheBox = true;
                }
                
            } while (rendererIsInsideTheBox == true);
            GameObject soc1 = Instantiate(soc, position, Quaternion.identity) as GameObject;
        }



    }





    int getRangeNum = 0;
    int rangeRadomNum = 0;

    int Random(int min, int max)
    {
        do
        {
            rangeRadomNum = UnityEngine.Random.Range(min, max);
        }
        while (getRangeNum == rangeRadomNum);
        getRangeNum = rangeRadomNum;

        return getRangeNum;
    }
}
