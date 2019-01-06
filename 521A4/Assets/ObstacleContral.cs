using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ObstacleContral : MonoBehaviour {
    public GameObject cube;
    public int numberofobstacles;

    public float width;
    public float length;
    // Use this for initialization
    void Start () {
       // numberofobstacles = Random(2, 6);  //obstacle number

  
        obstacle(numberofobstacles);
    }


    void obstacle(int numberofobstacles)
    {

        int[] numberofcube = new int[numberofobstacles];  //every obstacle's cube number
        Vector3[] preposition = new Vector3[numberofobstacles ];

        for (int i = 0; i < numberofobstacles ; i++)
            preposition[i] = new Vector3(100, 1, 100);
        bool judge = true;
        for (int i = 0; i < numberofobstacles; i++)
        {
            judge = true;
            Vector3 position = new Vector3();
            do
            {
                judge = true;
                position = new Vector3(Random(-45, 40), 0, Random(-21, 20));
                foreach (Vector3 x in preposition)
                {
                    if ((x - position).magnitude < 20)
                        judge = false;
                }
            }
            while
            (judge==false);
            numberofcube[i] = Random(1, 4);   //qualitron number
            preposition[i].x = position.x;
            preposition[i].z = position.z;
            for (int k = 0; k < numberofcube[i]; k++)


            {
                length = Random(3, 11);         //each part size
                width = Random(3, 11);
                if (position.x + length > 45)
                    length = Mathf.Max(45-position.x,0.2f);
                if (position.z + width >22)
                    width = Mathf.Max(22-position.z, 0.2f);
                GameObject bullet1 = Instantiate(cube, position, Quaternion.identity) as GameObject;
                position.x = position.x + length/Random(1,10);
                position.z = position.z + width/Random(1,10);

            }
            
       

        }

    }



    // Update is called once per frame
    void Update () {
		
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
