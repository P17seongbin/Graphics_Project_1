using myglm;
using UnityEngine;

public class DoubleAxis
{
    public float xy, xz, xw, yz, yw, zw;
    public DoubleAxis(float _xy,float _xz,float _xw,float _yz,float _yw,float _zw)
    {
        xy = _xy;
        xz = _xz;
        xw = _xw;
        yz = _yz;
        yw = _yw;
        zw = _zw;
    }
}

public class Unit4DObject : MonoBehaviour
{
    MeshFilter objMesh;
    public ObjHandler objData;

    public Vector3 ASpeed;//Angular Speed.
    public DoubleAxis ASpeed_4D;//4D Angular Speed
    public int Projtype = 0;
    public Vec5 updatedSC;
    public float scale = 3;
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
        ASpeed_4D = new DoubleAxis(0, 0, 0, 0, 0, 0);
        ASpeed = new Vector3(0, 0, 0);

        objData = new ObjHandler(filepath, "Cube");
        objData.LoadData();

        objMesh = GetComponent<MeshFilter>();
             
        //카메라의 초기값을 설정합니다.
        Vec5 campos = new Vec5(0,0,0,1, 1);
        objData.Set4DcamPos(campos);
        Vec5 viewdirection = -campos.Normalize();
        objData.Set4DviewVec(viewdirection);
        Vec5 upvec1 = new Vec5(-viewdirection[2], viewdirection[3], viewdirection[0], -viewdirection[1], 1);
        Vec5 upvec2 = new Vec5(-viewdirection[3], -viewdirection[2], viewdirection[1], viewdirection[0], 1);
        objData.Set4DupVec1(upvec1);
        objData.Set4DupVec2(upvec2);

        objData.SetClippingDist(0.5f);
        updatedSC = new Vec5(0, 0, 0, 0, 1);

        //StartCoroutine(Keyhandler());
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(ASpeed);

        if (Input.GetKeyDown(KeyCode.F1))
            objData.Reload("Hypercube");
        else if (Input.GetKeyDown(KeyCode.F2))
            objData.Reload("CliffordTorus");

        objData.Rotate_XW_YZ(ASpeed_4D.xw, ASpeed_4D.yz);
        objData.Rotate_XY_ZW(ASpeed_4D.xy, ASpeed_4D.zw);
        objData.Rotate_XZ_YW(ASpeed_4D.xz, ASpeed_4D.yw);

        objData.Stereographic_Center = updatedSC;

        Project_3D();       
    }

    /// <summary>
    /// objLoader Class에서 할당된 4D vertex,normal값을 읽어와서 적절히 Project한 뒤 mesh data에 넘겨주는 역할을 합니다.
    /// </summary>
    void Project_3D()
    {
        Vec5[] rawvertex = objData.rawVertices.ToArray();
        int c = rawvertex.Length;
        Vector3[] vertices = new Vector3[c];

        Mat5 MV = objData.GetMVMatrix();
        Vec5 sc = objData.Stereographic_Center;
        float cd = objData.Clipping_dist;

        for (int i = 0; i < c; i++)
        {
            Vec5 viewvertex = MV * rawvertex[i];

            //귀찮으니까 Switch Case문으로 구현, 최적화가 필요하면 리팩토링
            switch (Projtype)
            {
                //Orthogonal
                case 0:
                    {
                        vertices[i] = scale * (new Vector3(viewvertex.x, viewvertex.y, viewvertex.z).normalized);
                        break;
                    }
                //perspective
                case 1:
                    {
                        vertices[i] = ((new Vector3(viewvertex.x, viewvertex.y, viewvertex.z) * (viewvertex.w / cd)));
                        break;
                    }
                //stereographic
                case 2:
                    {
                        Vec5 nv = ((viewvertex - sc).Normalize());
                        float sx = nv.x / (sc.w + 1.0f - nv.w);
                        float sy = nv.y / (sc.w + 1.0f - nv.w);
                        float sz = nv.z / (sc.w + 1.0f - nv.w);
                        vertices[i] = (new Vector3(sx, sy, sz).normalized)* scale;

                        break;
                    }
                case 3: //make a slice about w and map
                    {
                        vertices[i] = scale * ((new Vector3(viewvertex.x, viewvertex.y, viewvertex.z) + Vector3.one * viewvertex.w).normalized);
                        break;
                    }
                case 4: //make a slice about w and map
                    {
                        vertices[i] = scale * ((new Vector3(viewvertex.x, viewvertex.y, viewvertex.z) + (new Vector3(0.1f, 0.5f, 0.2f)) * viewvertex.w).normalized);
                        break;
                    }

                    //perspective projection
                    //vertices[i] = new Vector3(rawvertex[i].x, rawvertex[i].y, rawvertex[i].z) * rawvertex[i].w;//* Mathf.Pow(1.2f,rawvertex[i].w);
            }
        }
            float[] midvertices = new float[3];
            for (int i=0; i<c; i++)
            {
                midvertices[0] += vertices[i].x;
                midvertices[1] += vertices[i].y;
                midvertices[2] += vertices[i].z;
            }
            midvertices[0] /= c;
            midvertices[1] /= c;
            midvertices[2] /= c;
            for (int i=0; i<c; i++)
            {
                vertices[i].x -= midvertices[0];
                vertices[i].y -= midvertices[1];
                vertices[i].z -= (midvertices[2]);
            }


        Mesh t = new Mesh
        {
            vertices = vertices,
            triangles = objData.Tris.ToArray()
        };
        objMesh.mesh = t;
    }
}
