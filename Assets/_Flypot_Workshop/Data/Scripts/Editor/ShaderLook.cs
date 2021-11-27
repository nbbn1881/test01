using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ShaderLook : ShaderGUI
{    
    override public void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        //base.OnGUI(materialEditor, properties);
        var mainTex = FindProperty("_main_tex", properties);
        var brightColor = FindProperty("_bright_color", properties);
        var midColor = FindProperty("_mid_color", properties);
        var darkColor = FindProperty("_dark_color", properties);
        var useLifetime = FindProperty("_use_p_lifetime", properties);
        var usePolar01 = FindProperty("_use_polar01", properties);
        var mainTiling = FindProperty("_mein_tiling", properties);

        
        //materialEditor.TexturePropertyMiniThumbnail(mainTex,"Main Texture","");
        //materialEditor.TexturePropertySingleLine();

        EditorGUILayout.BeginHorizontal();
        materialEditor.FloatProperty(useLifetime,"use Test");
        materialEditor.FloatProperty(usePolar01,"");
        EditorGUILayout.EndHorizontal();

        
        using (new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Label("Main Texture", EditorStyles.boldLabel);
            EditorGUILayout.BeginHorizontal();           
            materialEditor.TextureProperty(mainTex,"");
            materialEditor.VectorProperty(mainTiling,"Tiling");            
            EditorGUILayout.EndHorizontal();
            
        }

        
        using (new EditorGUILayout.VerticalScope("box"))
        {
            GUILayout.Label("Color (MainTexの輝度に着色)", EditorStyles.boldLabel);            
            materialEditor.ColorProperty(brightColor,"Bright Color");
            materialEditor.ColorProperty(midColor,"Mid Color");
            materialEditor.ColorProperty(darkColor,"Dark Color");
            
        }
        
        
    } 
}
