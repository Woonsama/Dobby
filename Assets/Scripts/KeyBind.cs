using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBind : MonoBehaviour
{
    public TouchCheck touch;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            touch.TouchUp_PointerDown();
        if(Input.GetKeyUp(KeyCode.Z))
            touch.TouchUp_PointerUp();
        
        if(Input.GetKeyDown(KeyCode.X))
            touch.TochDown_PointerDown();
        if(Input.GetKeyUp(KeyCode.X))
            touch.TochDown_PointerUp();
    }
}
