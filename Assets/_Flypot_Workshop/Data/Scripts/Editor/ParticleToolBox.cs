using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ParticleToolBox : EditorWindow {

	public ParticleSystem ps;
    public ParticleSystemRenderer psr;


	

	[MenuItem("Window/FT/ParticleToolBox")]
	static void Open (){
		GetWindow<ParticleToolBox> ();
	}

	void OnGUI(){	
		
		if (GUILayout.Button("Set CustomData")){
            var obj = Selection.activeGameObject;
		    ps = obj.GetComponent<ParticleSystem> ();  
            psr = obj.GetComponent<ParticleSystemRenderer>();   

            //4は初期設定のVertexStreamの数
            if(psr.activeVertexStreamsCount > 4)return;               

            //VertexStreamを設定
            psr.SetActiveVertexStreams(new List<ParticleSystemVertexStream>(new ParticleSystemVertexStream[] 
            { ParticleSystemVertexStream.Position, ParticleSystemVertexStream.Normal, ParticleSystemVertexStream.Color,
             ParticleSystemVertexStream.UV, ParticleSystemVertexStream.UV2, ParticleSystemVertexStream.Custom1XYZW, 
             ParticleSystemVertexStream.Custom2XYZW, ParticleSystemVertexStream.StableRandomXY }));

            //CustomDataを設定
            var custom = ps.customData;        
            custom.enabled = true; 
            custom.SetMode(ParticleSystemCustomData.Custom1,ParticleSystemCustomDataMode.Vector);
            custom.SetMode(ParticleSystemCustomData.Custom2,ParticleSystemCustomDataMode.Vector);
            custom.SetVectorComponentCount(ParticleSystemCustomData.Custom1,4);
            custom.SetVectorComponentCount(ParticleSystemCustomData.Custom2,4);       

            custom.SetVector(ParticleSystemCustomData.Custom1, 0, 1.0f);
            custom.SetVector(ParticleSystemCustomData.Custom1, 1, 1.0f);
            custom.SetVector(ParticleSystemCustomData.Custom1, 2, 0.0f);
            custom.SetVector(ParticleSystemCustomData.Custom1, 3, 0.0f);

            var serializedObject = new SerializedObject(ps);
            var customData00 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_0");
            var customData01 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_1");
            var customData02 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_2");
            var customData03 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_3");
            var customData10 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_0");
            var customData11 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_1");
            var customData12 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_2");
            var customData13 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_3");
            customData00.stringValue = "Emission";
            customData01.stringValue = "Dist Strength Multiply";
            customData02.stringValue = "No Use";
            customData03.stringValue = "Vertex Anim Strength";
            customData10.stringValue = "Main UV Offset U";
            customData11.stringValue = "Main UV Offest V";
            customData12.stringValue = "Mask UV Offset U";
            customData13.stringValue = "Mask UV Offset V";

            serializedObject.ApplyModifiedProperties();
        }  



	}



	

}
