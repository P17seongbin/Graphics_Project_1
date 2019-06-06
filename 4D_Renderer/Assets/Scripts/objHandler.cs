using System;
using System.Collections.Generic;
using UnityEngine;
using myglm;
/// <summary>
/// Resources 폴더 안에 있는 obj 파일로부터 단일 오브젝트의 데이터를 읽어서 저장하는 Class입니다.
/// 외부 Object에서 원하는 데이터를 call할 수 있습니다.
/// Object Transformation 관련 method는 objTransform 파일에 작성되어 있습니다.
/// </summary>

public partial class ObjHandler
{
    //Model의 좌표와 Scale을 저장합니다.
    public Mat5 ModelMatrix { get; private set; }

    public void AddPos(float dx, float dy, float dz, float dw) => AddPos(new Vec5(dx, dy, dz, dw));
    public void MultiplyScale(float dx, float dy, float dz, float dw) => MultiplyScale(new Vec5(dx, dy, dz, dw));
    
    string objName;
    string Path;
    //Obj 파일에 있는 vertex / vertex normal data 그 자체를 저장합니다.
    public List<Vec5> rawVertices;
    public List<Vec5> rawNormals;

    //실제로 Unity 상에 넘겨줘야 할 vertex,normal,tris 데이터입니다. 
    public List<Vec5> Vertices { get; private set; }
    public List<Vec5> Normals { get; private set; }
    public List<int> Tris { get; private set; }


    //현재 Object를 투영하고 있는 Camera에 대한 정보입니다.
    //Vector관련 연산이 어떤게 필요할지 몰라 일단 private set 대신 set을 사용했습니다.
    public Vec5 _4DcamPos { get; set; }
    public Vec5 _4DviewVec { get; set; }
    public Vec5 _4DupVec1 { get; set; }
    public Vec5 _4DupVec2 { get; set; }

    ///4D Clipping surface입니다, perspecive projection에서만 유효합니다.
    public float Clipping_dist { get; private set; }
    //Stereographic Sphere의 중심점입니다. Stereographic projection에서만 유효합니다.
    public Vec5 Stereographic_Center { get; set; }

    public Mat5 GetMVMatrix()
    {
        return GetViewMatrix() * ModelMatrix;
    }
    public Mat5 GetViewMatrix()
    {
        Vec5 vec_l = Vec5.CrossProduct(_4DviewVec, _4DupVec1, _4DupVec2);

        //create left side of view matrix
        Mat5 t1 = new Mat5(0);//Zero matrix
        for (int i = 0; i < 4; i++)
        {
            t1[0, i] = vec_l[i];
        }
        for (int i = 0; i < 4; i++)
        {
            t1[1, i] = _4DupVec1[i];
        }
        for (int i = 0; i < 4; i++)
        {
            t1[2, i] = _4DupVec2[i];
        }
        for (int i = 0; i < 4; i++)
        {
            t1[3, i] = _4DviewVec[i];
        }
        t1[4, 4] = 1;

        //create right side of view matrix
        Mat5 t2 = new Mat5(0);
        for (int i = 0; i < 4; i++)
        {
            t2[i, i] = 1;
            t2[i, 4] = -1 * _4DcamPos[i];
        }
        t2[4, 4] = 1;

        //multiply t1 and t2 to get final view matrix
        Mat5 res = t1 * t2;
        return res;
    }
    int vc = 0;



    //생성할 때 입력한 Path로 Load를 시도합니다. 성공할 경우 True를 리턴합니다.
    public bool LoadData()
    {
        //Clear buffer
        rawVertices = new List<Vec5>();
        rawNormals = new List<Vec5>();
        Vertices = new List<Vec5>();
        Normals = new List<Vec5>();
        Tris = new List<int>();

        //Line by Line Parser
        var splitFile = new string[] { "\r\n", "\r", "\n" };
        var spaceParcer = new char[] { ' ' };
        //TODO: 예외처리를 해야 합니다
        TextAsset objrawText = (TextAsset)Resources.Load(Path);
        if (objrawText != null) //Load가 성공적으로 이루어 졌나요?
        {
            var objData = objrawText.text.Split(splitFile, StringSplitOptions.None);

            int l = objData.Length;
            for (int i = 0; i < l; i++)
            {
                //귀찮으니까 일단 If-else로 구현, 나중에 리팩토링 할 가능성이 크다.
                if (objData[i].Length > 2)
                {
                    if (objData[i].Substring(0, 2) == "vn")//vertex normal data
                    {
                        var d = objData[i].Split(spaceParcer);
                        Vec5 tV = new Vec5(float.Parse(d[1]), float.Parse(d[2]), float.Parse(d[3]), float.Parse(d[4]));
                        rawNormals.Add(tV);
                    }
                    else if (objData[i].Substring(0, 1) == "v")//vertex data
                    {
                        var d = objData[i].Split(spaceParcer);
                        Vec5 tV = new Vec5(float.Parse(d[1]), float.Parse(d[2]), float.Parse(d[3]), float.Parse(d[4]));
                        rawVertices.Add(tV);
                    }
                    else if (objData[i].Substring(0, 1) == "f")//face data
                    {

                        var d = objData[i].Split(spaceParcer);

                        for (int j = 1; j < d.Length; j++)
                        {
                            var d2 = d[j].Split(new char[] { '/' });
                            Tris.Add(int.Parse(d2[0]));
                        }
                    }
                }
            }
            return true;
        }
        else return false;
    }

    public void Reload(string newFilePath)
    {
        Path = newFilePath;
        LoadData();
    }
    //생성자.
    public ObjHandler(string objFilePath, string Name)
    {
        Clipping_dist = 1;


        ModelMatrix = new Mat5(1);//Identity
        Vertices = new List<Vec5>();
        Normals = new List<Vec5>();
        Tris = new List<int>();

        rawNormals = new List<Vec5>();
        rawVertices = new List<Vec5>();


        Path = objFilePath;
        objName = Name;

        Stereographic_Center = new Vec5(0, 0, 0, 0, 1);
    }

    public void SetClippingDist(float d)
    {
        Clipping_dist = d;
    }
    public void Set4DcamPos(float x, float y, float z, float w, float v = 1)
    {
        Set4DcamPos(new Vec5(x, y, z, w, v));
    }
    public void Set4DcamPos(Vec5 v)
    {
        _4DcamPos = v;
    }
    public void Set4DviewVec(float x, float y, float z, float w, float v = 1)
    {
        Set4DviewVec(new Vec5(x, y, z, w, v));
    }
    public void Set4DviewVec(Vec5 v)
    {
        _4DviewVec = v;
    }
    public void Set4DupVec1(float x, float y, float z, float w, float v = 1)
    {
        Set4DupVec1(new Vec5(x, y, z, w, v));
    }
    public void Set4DupVec1(Vec5 v)
    {
        _4DupVec1 = v;
    }
    public void Set4DupVec2(float x, float y, float z, float w, float v = 1)
    {
        Set4DupVec2(new Vec5(x, y, z, w, v));
    }
    public void Set4DupVec2(Vec5 v)
    {
        _4DupVec2 = v;
    }
}