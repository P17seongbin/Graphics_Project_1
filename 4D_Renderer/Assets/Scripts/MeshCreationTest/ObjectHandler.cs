using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach된 Object에 미리 입력된 이름에 맞는 4D Object를 불러와서 Load한 뒤,
/// 각 4D Vertex를 3D로 Projection해서 Object Mesh에 넘겨줍니다.
/// </summary>

public class ObjectHandler : MonoBehaviour
{
    ObjLoader LoadedObject; //Load된 4D .obj 파일입니다.

    public string objPath;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
