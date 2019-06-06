using UnityEngine;
using myglm;
public class Unit4DObject : MonoBehaviour
{
    MeshFilter objMesh;
    ObjHandler objData;

    static int Projtype;

    public void IsetProjection(int type)
    {
        Projtype = type;
    }

    //파일명입니다, 기본값은 Hypercube입니다.
    public string filepath = "Hypercube";

    Vector3[] vertices = new Vector3[8];
    public float size = 1;
    int k = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Default : Orthogonal Projection
        Projtype = 2;

        objData = new ObjHandler(filepath, "Hypercube");
        objData.LoadData();

        objMesh = GetComponent<MeshFilter>();
             
        //카메라의 초기값을 설정합니다.
        Vec5 campos = new Vec5(0.7f, 0.1f, 0.1f, 20, 1);
        objData.Set4DcamPos(campos);
        Vec5 viewdirection = -campos.Normalize();
        objData.Set4DviewVec(viewdirection);
        Vec5 upvec1 = new Vec5(-viewdirection[2], viewdirection[3], viewdirection[0], -viewdirection[1], 1);
        Vec5 upvec2 = new Vec5(-viewdirection[3], -viewdirection[2], viewdirection[1], viewdirection[0], 1);
        objData.Set4DupVec1(upvec1);
        objData.Set4DupVec2(upvec2);

        objData.SetClippingDist(10f);


        project_3D();

        int[] tri = objData.Tris.ToArray();        //지정한 face-vector 연동값을 mesh에 등록합니다.
        objMesh.mesh.triangles = tri;
    }

    // Update is called once per frame
    void Update()
    {
        //objData.MultiplyScale(new Vec5(1,1,1,1.01f));
        objData.Rotate_XW_YZ(0.01f, 0);
        //objData.Rotate_XW_YZ(0.01f, 0.01f);
       // HypercubeData.AddScale(new Vec5(0, 0, 0, 0.01f));
        project_3D();       
    }

    /// <summary>
    /// objLoader Class에서 할당된 4D vertex,normal값을 읽어와서 적절히 Project한 뒤 mesh data에 넘겨주는 역할을 합니다.
    /// </summary>
    void project_3D()
    {

        Vec5[] rawvertex = objData.rawVertices.ToArray();
        int c = rawvertex.Length;
        Vector3[] vertices = new Vector3[c];

        Mat5 MV = objData.GetMVMatrix();
        Vec5 sc = objData.Stereographic_Center;

        for (int i = 0; i < c; i++)
        {
            Vec5 viewvertex = MV * rawvertex[i];

            //귀찮으니까 Switch Case문으로 구현, 최적화가 필요하면 리팩토링
            switch (Projtype)
            {
                //Orthogonal
                case 0:
                    {
                        vertices[i] = new Vector3(viewvertex.x, viewvertex.y, viewvertex.z);
                        break;
                    }
                //perspective
                case 1:
                    {
                        vertices[i] = new Vector3(viewvertex.x, viewvertex.y, viewvertex.z) * (viewvertex.w / objData.Clipping_dist);
                        break;
                    }
                //stereographic
                case 2:
                    {
                        Vec5 nv = (viewvertex-sc).Normalize();
                        float sx = nv.x / (0.5f - nv.w);
                        float sy = nv.y / (0.5f - nv.w);
                        float sz = nv.z / (0.5f - nv.w);
                        vertices[i] = new Vector3(sx, sy, sz);

                        break;
                    }
                    //perspective projection
                    //vertices[i] = new Vector3(rawvertex[i].x, rawvertex[i].y, rawvertex[i].z) * rawvertex[i].w;//* Mathf.Pow(1.2f,rawvertex[i].w);
            }
        }
        objMesh.mesh.vertices = vertices;
        objMesh.mesh.normals = vertices;
        objMesh.mesh.triangles = objData.Tris.ToArray();

    }

    void SetProjection(int type)
    {
        //Valid type
        if (0 <= type && type <= 2)
            Projtype = type; 
    }



}
