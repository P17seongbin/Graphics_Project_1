using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate4D : MonoBehaviour
{
    static float speed;
    public Unit4DObject Obj;

    public void RefreshXY() { Obj.ASpeed_4D.xy = speed; }
    public void RefreshXZ() { Obj.ASpeed_4D.xz = speed; }
    public void RefreshXW() { Obj.ASpeed_4D.xw = speed; }
    public void RefreshYZ() { Obj.ASpeed_4D.yz = speed; }
    public void RefreshYW() { Obj.ASpeed_4D.yw = speed; }
    public void RefreshZW() { Obj.ASpeed_4D.zw = speed; }
    public void Stop() { Obj.ASpeed_4D = new DoubleAxis(0, 0, 0, 0, 0, 0); }

    private void Start()
    {
        speed = 0;
    }
    public void SetSpeed(string s)
    {

        if (float.TryParse(s, out float res)) speed = res;
    }

}
