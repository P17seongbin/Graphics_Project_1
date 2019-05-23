using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Resources 폴더 안에 있는 obj 파일로부터 단일 오브젝트의 데이터를 읽어서 저장하는 Class입니다.
/// 외부 Object에서 원하는 데이터를 call할 수 있습니다.
/// </summary>
public class ObjLoader
{
    string objName;
    string Path;
    //Obj 파일에 있는 vertex / vertex normal data 그 자체를 저장합니다.
    List<Vector4> rawVertices;
    List<Vector4> rawNormals;

    public List<Vector4> vertices { get; private set; }
    public List<Vector4> normals { get; private set; }
    public List<int> tris { get; private set; }

    int vc = 0;

    //생성자.
    public ObjLoader(string objFilePath, string Name)
    {
        Path = objFilePath;
        objName = Name;
    }

    //생성할 때 입력한 Path로 Load를 시도합니다. 성공할 경우 True를 리턴합니다.
    public bool LoadData()
    {
        //Line by Line Parser
        var splitFile = new string[] { "\r\n", "\r", "\n" };
        var spaceParcer = new char[] { ' ' };
        UnityEngine.Object t = Resources.Load(Path);
        if (t != null) //Load가 성공적으로 이루어 졌나요?
        {
            //TODO: 예외처리를 해야 합니다
            TextAsset objrawText = (TextAsset)t;
            var objData = objrawText.text.Split(splitFile, StringSplitOptions.None);

            int l = objData.Length;
            for (int i = 0; i < l; i++)
            {
                //귀찮으니까 일단 If-else로 구현, 나중에 리팩토링 할 가능성이 크다.

                if (objData[i].Substring(0, 2) == "vn")//vertex normal data
                {
                    var d = objData[i].Split(spaceParcer);
                    Vector4 tV = new Vector4(float.Parse(d[1]), float.Parse(d[2]), float.Parse(d[3]), float.Parse(d[4]));
                    rawNormals.Add(tV);
                }
                else if (objData[i].Substring(0, 1) == "v")//vertex data
                {
                    var d = objData[i].Split(spaceParcer);
                    Vector4 tV = new Vector4(float.Parse(d[1]), float.Parse(d[2]), float.Parse(d[3]), float.Parse(d[4]));
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
            return true;
        }
        else return false;
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