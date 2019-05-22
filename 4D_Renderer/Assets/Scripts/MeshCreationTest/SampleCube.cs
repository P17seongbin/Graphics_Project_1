using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCube : MonoBehaviour
{
    MeshFilter objMesh;
    
    Vector3[] vertices = new Vector3[8];
    public float size = 1;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<Renderer>().material.color = Color.cyan;
        objMesh = GetComponent<MeshFilter>();
        
        int[] tri = new int[36];
        //맨 처음 Mesh의 각 triangular face를 구성하는 3개의 vertex(일련번호)를 지정해줍니다.
        tri[0] = 0;
        tri[1] = 1;
        tri[2] = 2;

        tri[3] = 0;
        tri[4] = 2;
        tri[5] = 3;


        tri[6] = 0;
        tri[7] = 3;
        tri[8] = 4;

        tri[9] = 4;
        tri[10] = 3;
        tri[11] = 7;


        tri[12] = 5;
        tri[13] = 1;
        tri[14] = 0;

        tri[15] = 5;
        tri[16] = 0;
        tri[17] = 4;


        tri[18] = 6;
        tri[19] = 2;
        tri[20] = 1;

        tri[21] = 6;
        tri[22] = 1;
        tri[23] = 5;


        tri[24] = 7;
        tri[25] = 3;
        tri[26] = 2;

        tri[27] = 7;
        tri[28] = 2;
        tri[29] = 6;


        tri[30] = 4;
        tri[31] = 5;
        tri[32] = 6;

        tri[33] = 4;
        tri[34] = 7;
        tri[35] = 6;

        //지정한 face-vector 연동값을 mesh에 등록합니다.
        objMesh.mesh.triangles = tri;
        
    }


    // Update is called once per frame
    void Update()
    {
        int i = k;
        float c = Mathf.Cos(Mathf.PI * i / 15);
        float s = Mathf.Sin(Mathf.PI * i / 15);
        //8개의 vertex의 좌표를 지정하고, 갱신합니다. 안에 있는 내용은 그냥 각 vertex를 적절히 회전시키는 거니 너무 신경쓰지 마세요 :P
        vertices[0] = new Vector3((size + s / 1.41f), size * c, -1 * (size + s / 1.41f));
        vertices[1] = new Vector3(-1 * (size + s / 1.41f), size * c, -1 * (size + s / 1.41f));
        vertices[2] = new Vector3(-1 * (size + s / 1.41f), size * c, (size + s / 1.41f));
        vertices[3] = new Vector3((size + s / 1.41f), size * c, (size + s / 1.41f));

        vertices[4] = new Vector3((size - s / 1.41f), -1 * size * c, -1 * (size - s / 1.41f));
        vertices[5] = new Vector3(-1 * (size - s / 1.41f), -1 * size * c, -1 * (size - s / 1.41f));
        vertices[6] = new Vector3(-1 * (size - s / 1.41f), -1 * size * c, (size - s / 1.41f));
        vertices[7] = new Vector3((size - s / 1.41f), -1 * size * c, (size - s / 1.41f));

        //생성한 Vertex값을 전달합니다.
        objMesh.mesh.vertices = vertices;

        //각 vertex의 normal vector를 지정합니다. 여기서는 귀찮아서 Vertex와 같은 값을 때려박음
        Vector3[] normal = new Vector3[8];
        for (int j = 0; j < 8; j++)
        {
            normal[j] = vertices[j];
        }
        //생성한 normal 값을 전달합니다.
        objMesh.mesh.normals = normal;

        //각 vertex별로 UV Coord 지정하는 기능도 있지만 여기에는 구현하지 않았습니다

        k = (k + 1) % 30;
    }

    
}
