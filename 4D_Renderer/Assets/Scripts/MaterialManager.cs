using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public Material Wire;
    public Material Color;

    // Start is called before the first frame update
    void Start()
    {
        Wire = Resources.Load("Temp") as Material;
        Color = Resources.Load("showSelectedRange") as Material;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = Wire;
        else if (Input.GetKeyDown(KeyCode.F4))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = Color;
    }
}
