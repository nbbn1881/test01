using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class TextInput : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var obj =  Selection.activeGameObject;
        Text textInput = this.GetComponent<Text>();
        textInput.text = obj.name;
    }
}
