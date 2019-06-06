using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate3D : MonoBehaviour
{
    static float speed;
    public Unit4DObject Obj;

    public float x=0, y=0, z=0;

    public void togglePositive(int axis)
    {
        float v = speed;
        switch (axis)
        {
            case 1:
                x = v;
                break;
            case 2:
                y = v;
                break;
            case 3:
                z = v;
                break;
        }
        Obj.ASpeed = new Vector3(x, y, z);
    }

    public void toggleNegative(int axis)
    {
        float v = speed * -1;
        switch (axis)
        {
            case 1:
                x = v;
                break;
            case 2:
                y = v;
                break;
            case 3:
                z = v;
                break;
        }
        Obj.ASpeed = new Vector3(x, y, z);
    }
    public void toggleZero()
    {
        x = 0;
        y = 0;
        z = 0;
        Obj.ASpeed = new Vector3(x, y, z);
    }

    private void Start()
    {
        speed = 0;
    }

    public void SetSpeed(string s)
    {

        if (float.TryParse(s, out float res)) speed = res;

    }

}
