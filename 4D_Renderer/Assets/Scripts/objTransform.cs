using myglm;
using UnityEngine;
/// <summary>
/// Resources 폴더 안에 있는 obj 파일로부터 단일 오브젝트의 데이터를 읽어서 저장하는 Class입니다.
/// 외부 Object에서 원하는 데이터를 call할 수 있습니다.
/// </summary>
/// 
public partial class ObjHandler
{
  


    //Model의 좌표와 Scale을 편집합니다.
    public void AddPos(Vec5 dpos)
    {
        Mat5 dmatrix = new Mat5(1);
        for (int i = 0; i < 4; i++)
        {
            dmatrix[i, 4] = dpos[i];
        }
        dmatrix[4, 4] = 1;
        ModelMatrix = dmatrix * ModelMatrix;
    }
    public void MultiplyScale(Vec5 dscale)
    {
        Mat5 dmatrix = new Mat5(1);
        for (int i = 0; i < 4; i++)
        {
            dmatrix[i, i] = dscale[i];
        }
        ModelMatrix = dmatrix * ModelMatrix;
    }

    public void Rotate_XY_ZW(float a, float b)
    {
        float ca = Mathf.Cos(a);
        float sa = Mathf.Sin(a);
        float cb = Mathf.Cos(b);
        float sb = Mathf.Sin(b);
        Mat5 t = new Mat5(1);
        t[0, 0] = t[1, 1] = ca;
        t[1, 0] = -1 * sa;
        t[0, 1] = sa;

        t[2, 2] = t[3, 3] = cb;
        t[3, 2] = sb;
        t[2, 3] = -1 * sb;

        ModelMatrix = t * ModelMatrix;
    }
    public void Rotate_XZ_YW(float a, float b)
    {
        float ca = Mathf.Cos(a);
        float sa = Mathf.Sin(a);
        float cb = Mathf.Cos(b);
        float sb = Mathf.Sin(b);
        Mat5 t = new Mat5(1);
        t[0, 0] = t[2, 2] = ca;
        t[2, 0] = sa;
        t[0, 2] = -1 * sa;

        t[1, 1] = t[3, 3] = cb;
        t[3, 1] = sb;
        t[1, 3] = -1 * sb;

        ModelMatrix = t * ModelMatrix;
    }
    public void Rotate_XW_YZ(float a, float b)
    {
        float ca = Mathf.Cos(a);
        float sa = Mathf.Sin(a);
        float cb = Mathf.Cos(b);
        float sb = Mathf.Sin(b);
        Mat5 t = new Mat5(1);
        t[0, 0] = t[3, 3] = ca;
        t[3, 0] = -1 * sa;
        t[0, 3] = sa;

        t[1, 1] = t[2, 2] = cb;
        t[1, 2] = sb;
        t[2, 1] = -1 * sb;

        ModelMatrix = t * ModelMatrix;
    }
}