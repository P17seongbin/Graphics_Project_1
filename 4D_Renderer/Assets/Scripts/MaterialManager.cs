using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialManager : MonoBehaviour
{
    public Material Wire;
    public Material Color;
    public Material TransWire;
    public Material Dissolve_Cos;
    public Slider minBar;
    public Slider maxBar;
    public Vector4 range;

    // Start is called before the first frame update
    void Start()
    {
        Wire = Resources.Load("Temp") as Material;
        Color = Resources.Load("showSelectedRange") as Material;
        TransWire = Resources.Load("TransWire") as Material;
        Dissolve_Cos = Resources.Load("dissolve_cosine") as Material;
        minBar = GameObject.Find("MinBar").GetComponent<Slider>();
        maxBar = GameObject.Find("MaxBar").GetComponent<Slider>();

        minBar.onValueChanged.AddListener(minValChange);
        maxBar.onValueChanged.AddListener(maxValChange);
        range.x = -0.5f;
        range.y = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = Wire;
        else if (Input.GetKeyDown(KeyCode.F4))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = Color;
        else if (Input.GetKeyDown(KeyCode.F5))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = TransWire;
        else if (Input.GetKeyDown(KeyCode.F6))
            GameObject.Find("Object").GetComponent<MeshRenderer>().material = Dissolve_Cos;
    }

    private void minValChange(float val)
    {
        range.x = val;
        GameObject.Find("Object").GetComponent<MeshRenderer>().material.SetVector("Vector2_E2EEE810", range);
    }

    private void maxValChange(float val)
    {
        range.y = val;
        GameObject.Find("Object").GetComponent<MeshRenderer>().material.SetVector("Vector2_E2EEE810", range);
    }

}
