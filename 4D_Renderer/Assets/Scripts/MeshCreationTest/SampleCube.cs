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
        objMesh = GetComponent<MeshFilter>();

        project_3D();

        int[] tri = HypercubeData.tris.ToArray();
       
        //지정한 face-vector 연동값을 mesh에 등록합니다.
        objMesh.mesh.triangles = tri;
    }

    // Update is called once per frame
    void Update()
    {
        project_3D();       
    }

    /// <summary>
    /// objLoader Class에서 할당된 4D vertex,normal값을 읽어와서 적절히 Project한 뒤 mesh data에 넘겨주는 역할을 합니다.
    /// </summary>
    void project_3D()
    {
 
        Vector4[] rawvertex = HypercubeData.vertices.ToArray();
        int c = rawvertex.Length;
        Vector3[] vertices = new Vector3[c];
        
        for (int i = 0; i < c; i++)
        {
            //Orthogonal projection
            //vertices[i] = new Vector3(rawvertex[i].x, rawvertex[i].y, rawvertex[i].z) + Vector3.one * rawvertex[i].w;
            //perspective projection
            vertices[i] = new Vector3(rawvertex[i].x, rawvertex[i].y, rawvertex[i].z) * rawvertex[i].w;//* Mathf.Pow(1.2f,rawvertex[i].w);
        }
        objMesh.mesh.vertices = vertices;
        objMesh.mesh.normals = vertices;

    }

}
