using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
public class Polygon : MonoBehaviour
{
    public GameObject Ctrller;
    public float Length;              //长方体的长
    public float Width;               //长方体的宽
    public float Heigth = 4;              //长方体的高
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;



    void Awake()
    {
        Ctrller = GameObject.FindGameObjectWithTag("GameController");
        Length = Ctrller.GetComponent<ObstacleContral>().length;
        Width = Ctrller.GetComponent<ObstacleContral>().width;
        meshFilter = GetComponent<MeshFilter>();
        meshFilter.mesh = CreateMesh(Length, Width, Heigth);
        meshCollider = GetComponent<MeshCollider>();
        meshCollider.sharedMesh = meshFilter.mesh;

    }




    Mesh CreateMesh(float length, float width, float heigth)
    {
        float r1 = (float)Random(27, 38) / 30.0f;
         float r2 = (float)Random(27, 38) / 30.0f;
         float r3 = (float)Random(27, 38) / 30.0f;
         float r4 = (float)Random(27, 38) / 30.0f;
        
        

        //vertices
        int vertices_count = 4 * 6;                                 //顶点数（每个面4个点，六个面）
        Vector3[] vertices = new Vector3[vertices_count];
        vertices[0] = new Vector3(0, 0, 0);                     //前面的左下角的点
        vertices[1] = new Vector3(0, heigth, 0);                //前面的左上角的点
        vertices[2] = new Vector3(length*r1, 0, 0);                //前面的右下角的点
        vertices[3] = new Vector3(length*r1, heigth, 0);           //前面的右上角的点

        vertices[4] = new Vector3(length * r3, 0, width * r4);           //后面的右下角的点
        vertices[5] = new Vector3(length * r3, heigth, width * r4);      //后面的右上角的点
        vertices[6] = new Vector3(0, 0, width*r2);                //后面的左下角的点
        vertices[7] = new Vector3(0, heigth, width*r2);           //后面的左上角的点

        vertices[8] = vertices[6];                              //左
        vertices[9] = vertices[7];
        vertices[10] = vertices[0];
        vertices[11] = vertices[1];

        vertices[12] = vertices[2];                              //右
        vertices[13] = vertices[3];
        vertices[14] = vertices[4];
        vertices[15] = vertices[5];

        vertices[16] = vertices[1];                              //上
        vertices[17] = vertices[7];
        vertices[18] = vertices[3];
        vertices[19] = vertices[5];

        vertices[20] = vertices[2];                              //下
        vertices[21] = vertices[4];
        vertices[22] = vertices[0];
        vertices[23] = vertices[6];


        //triangles(索引三角形、必须):
        int 分割三角形数 = 6 * 2;
        int triangles_cout = 分割三角形数 * 3;                  //索引三角形的索引点个数
        int[] triangles = new int[triangles_cout];            //索引三角形数组
        for (int i = 0, vi = 0; i < triangles_cout; i += 6, vi += 4)
        {
            triangles[i] = vi;
            triangles[i + 1] = vi + 1;
            triangles[i + 2] = vi + 2;

            triangles[i + 3] = vi + 3;
            triangles[i + 4] = vi + 2;
            triangles[i + 5] = vi + 1;

        }


        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        return mesh;
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



