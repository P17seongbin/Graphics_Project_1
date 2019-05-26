using UnityEngine;
using myglm;
public class SampleCube : MonoBehaviour
{
    MeshFilter objMesh;

    ObjLoader HypercubeData;

    Vector3[] vertices = new Vector3[8];
    public float size = 1;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        HypercubeData = new ObjLoader("Hypercube", "Hypercube");
        HypercubeData.LoadData();

        HypercubeData.SetPos(new Vec5());
        HypercubeData.SetScale(new Vec5(1,1,1,1));

        objMesh = GetComponent<MeshFilter>();

        project_3D();

        int[] tri = HypercubeData.tris.ToArray();
       
        //지정한 face-vector 연동값을 mesh에 등록합니다.
        objMesh.mesh.triangles = tri;
    }

    // Update is called once per frame
    void Update()
    {
        //HypercubeData.AddPos(new Vec5(0, 0, 0, 0.01f));
        project_3D();       
    }

    /// <summary>
    /// objLoader Class에서 할당된 4D vertex,normal값을 읽어와서 적절히 Project한 뒤 mesh data에 넘겨주는 역할을 합니다.
    /// </summary>
    void project_3D()
    {
 
        Vec5[] rawvertex = HypercubeData.vertices.ToArray();
        int c = rawvertex.Length;
        Vector3[] vertices = new Vector3[c];

        Mat5 MV = HypercubeData.GetModelMatrix();

        for (int i = 0; i < c; i++)
        {
            Vec5 viewvertex = MV * rawvertex[i];
            //Orthogonal projection
            vertices[i] = new Vector3(viewvertex.x, viewvertex.y, viewvertex.z) + Vector3.one * viewvertex.w;
            //perspective projection
            //vertices[i] = new Vector3(rawvertex[i].x, rawvertex[i].y, rawvertex[i].z) * rawvertex[i].w;//* Mathf.Pow(1.2f,rawvertex[i].w);
        }
        objMesh.mesh.vertices = vertices;
        objMesh.mesh.normals = vertices;

    }

}
