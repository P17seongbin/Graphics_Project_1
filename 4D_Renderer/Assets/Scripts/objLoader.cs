using System;
using System.Collections.Generic;
using UnityEngine;
using myglm;
/// <summary>
/// Resources 폴더 안에 있는 obj 파일로부터 단일 오브젝트의 데이터를 읽어서 저장하는 Class입니다.
/// 외부 Object에서 원하는 데이터를 call할 수 있습니다.
/// </summary>
public class ObjLoader
{
    //Model의 좌표와 Scale을 저장합니다.
    public Vec5 Pos { get; private set; }
    public Vec5 Scale { get; private set; }

    //Model의 좌표와 Scale을 편집합니다.
    public void SetScale(Vec5 scale) => Scale = scale;
    public void SetPos(Vec5 pos) => Pos = pos;
    public void AddPos(Vec5 dpos) => Pos = Pos + dpos;
    public void AddScale(Vec5 dscale) => Scale = Scale + dscale;

    public void SetScale(float x, float y, float z, float w) => SetScale(new Vec5(x, y, z, w));
    public void SetPos(float x, float y, float z, float w) => SetPos(new Vec5(x, y, z, w));
    public void AddPos(float dx, float dy, float dz, float dw) => AddPos(new Vec5(dx, dy, dz, dw));
    public void AddScale(float dx, float dy, float dz, float dw) => AddScale(new Vec5(dx, dy, dz, dw));


    string objName;
    string Path;
    //Obj 파일에 있는 vertex / vertex normal data 그 자체를 저장합니다.
    List<Vec5> rawVertices;
    List<Vec5> rawNormals;

    //실제로 Unity 상에 넘겨줘야 할 vertex,normal,tris 데이터입니다. 
    public List<Vec5> vertices { get; private set; }
    public List<Vec5> normals { get; private set; }
    public List<int> tris { get; private set; }


    //현재 Object를 투영하고 있는 Camera에 대한 정보입니다.
    public Vec5 _4DcamPos { get; private set; }
    public Vec5 _4DviewVec { get; private set; }
    public Vec5 _4DupVec1 { get; private set; }
    public Vec5 _4DupVec2 { get; private set; }


    public Mat5 GetMVMatrix()
    {
        return GetViewMatrix() * GetModelMatrix();
    }

    public Mat5 GetModelMatrix()
    {
        Mat5 dmatrix = new Mat5(0);//
        for(int i=0;i<4;i++)
        {
            dmatrix[i, i] = Scale[i];
            dmatrix[i, 4] = Pos[i];
        }
        dmatrix[4, 4] = 1;
        return dmatrix;
    }
    
    public Mat5 GetViewMatrix()
    {
        Vec5 vec_l = Vec5.CrossProduct(_4DviewVec, _4DupVec1, _4DupVec2);

        //create left side of view matrix
        Mat5 t1 = new Mat5(0);//Zero matrix
        for(int i=0;i<4;i++)
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
        for(int i=0;i<4;i++)
        {
            t1[i, i] = 1;
            t1[i, 4] = -1 * _4DcamPos[i];
        }
        t1[4, 4] = 1;

        //multiply t1 and t2 to get final view matrix
        Mat5 res = t1 * t2;
        return res;
    }
    int vc = 0;

    //생성자.
    public ObjLoader(string objFilePath, string Name)
    {
        vertices = new List<Vec5>();
        normals = new List<Vec5>();
        tris = new List<int>();

        rawNormals = new List<Vec5>();
        rawVertices = new List<Vec5>();


        Path = objFilePath;
        objName = Name;
    }

    //생성할 때 입력한 Path로 Load를 시도합니다. 성공할 경우 True를 리턴합니다.
    public bool LoadData()
    {
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
                if (objData[i].Length> 2)
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
                            vertices.Add(rawVertices[int.Parse(d2[0])]);
                            normals.Add(rawVertices[int.Parse(d2[1])]);
                            tris.Add(vc);
                            vc++;
                        }
                    }
                }
            }
            return true;
        }
        else return false;
    }

    public void Set4DcamPos(Vec5 v)
    {
        _4DcamPos = v;
    }
    public void Set4DviewVec(Vec5 v)
    {
        _4DviewVec = v;
    }
    public void Set4DupVec1(Vec5 v)
    {
        _4DupVec1 = v;
    }
    public void Set4DupVec2(Vec5 v)
    {
        _4DupVec2 = v;
    }
}
/*
v  0.000000 19.737080 -0.000000 19.737080
v  -0.000000 19.357838 -3.850513 19.737080
# 482 vertices

vn  0.000000 1.000000 -0.000000 19.737080
vn  -0.005744 0.976740 -0.214348 19.737080
# 482 vertex normals

g default
f 0/0 1/33 2/34
f 0/1 2/34 3/35
# 960 faces
*/