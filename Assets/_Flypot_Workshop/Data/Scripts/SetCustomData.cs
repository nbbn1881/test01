using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SetCustomData : MonoBehaviour
{
    public ParticleSystem ps;
    public ParticleSystemRenderer psr;

    public ParticleSystemVertexStream stream;
    public void SettingCustomData()
    {
        var obj = Selection.activeGameObject;
		ps = obj.GetComponent<ParticleSystem> ();  
        psr = obj.GetComponent<ParticleSystemRenderer>();   
        //stream = obj.GetComponent<ParticleSystemVertexStream>();

        if(psr.activeVertexStreamsCount != 0)return;

        var custom = ps.customData;        
        custom.enabled = true; 
        custom.SetMode(ParticleSystemCustomData.Custom1,ParticleSystemCustomDataMode.Vector);
        custom.SetMode(ParticleSystemCustomData.Custom2,ParticleSystemCustomDataMode.Vector);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom1,4);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom2,4);       

        custom.SetVector(ParticleSystemCustomData.Custom1, 0, 0.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 1, 1.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 2, 1.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 3, 1.0f);

        var serializedObject = new SerializedObject(ps);
        var customData00 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_0");
        var customData01 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_1");
        var customData02 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_2");
        var customData03 = serializedObject.FindProperty("CustomDataModule.vectorLabel0_3");
        var customData10 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_0");
        var customData11 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_1");
        var customData12 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_2");
        var customData13 = serializedObject.FindProperty("CustomDataModule.vectorLabel1_3");
        customData00.stringValue = "Alpha Threshold(0-2)";
        customData01.stringValue = "Emission";
        customData02.stringValue = "UV Animation";
        customData03.stringValue = "UV Animation Threshold";
        customData10.stringValue = "Offset U";
        customData11.stringValue = "Offest V";
        customData12.stringValue = "not set";
        customData13.stringValue = "not set";

        serializedObject.ApplyModifiedProperties();      

    }

    public void SettingCustomDataToon()
    {
        var obj = Selection.activeGameObject;
        ps = obj.GetComponent<ParticleSystem>();
        psr = obj.GetComponent<ParticleSystemRenderer>();
        //stream = obj.GetComponent<ParticleSystemVertexStream>();

        if(psr.activeVertexStreamsCount != 0)return;

        var custom = ps.customData;
        custom.enabled = true;
        custom.SetMode(ParticleSystemCustomData.Custom1, ParticleSystemCustomDataMode.Vector);
        custom.SetMode(ParticleSystemCustomData.Custom2, ParticleSystemCustomDataMode.Vector);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom1, 4);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom2, 4);

        custom.SetVector(ParticleSystemCustomData.Custom1, 0, 5.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 1, 0.3f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 2, 0.3f);
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
        customData01.stringValue = "Dissolve Strength";
        customData02.stringValue = "Ramp Color Value";
        customData03.stringValue = "Empty";
        customData10.stringValue = "Empty";
        customData11.stringValue = "Empty";
        customData12.stringValue = "Empty";
        customData13.stringValue = "Empty";

        serializedObject.ApplyModifiedProperties();

    }

    public void SettingVertexStream()
    {
        var obj = Selection.activeGameObject;
		ps = obj.GetComponent<ParticleSystem> ();  
        psr = obj.GetComponent<ParticleSystemRenderer>();   

        if(psr.activeVertexStreamsCount != 0)return;

        psr.SetActiveVertexStreams(new List<ParticleSystemVertexStream>(new ParticleSystemVertexStream[] 
        { ParticleSystemVertexStream.Position, ParticleSystemVertexStream.Normal, ParticleSystemVertexStream.Color,
         ParticleSystemVertexStream.UV, ParticleSystemVertexStream.UV2, ParticleSystemVertexStream.Custom1XYZW, 
         ParticleSystemVertexStream.Custom2XYZW, ParticleSystemVertexStream.StableRandomXY }));

    }

    public void DistortionCustomData()
    {
        var obj = Selection.activeGameObject;
		ps = obj.GetComponent<ParticleSystem> ();  
        psr = obj.GetComponent<ParticleSystemRenderer>();   
        //stream = obj.GetComponent<ParticleSystemVertexStream>();

        var custom = ps.customData;        
        custom.enabled = true; 
        custom.SetMode(ParticleSystemCustomData.Custom1,ParticleSystemCustomDataMode.Vector);
        custom.SetMode(ParticleSystemCustomData.Custom2,ParticleSystemCustomDataMode.Vector);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom1,4);
        custom.SetVectorComponentCount(ParticleSystemCustomData.Custom2,4);       

        custom.SetVector(ParticleSystemCustomData.Custom1, 0, 0.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 1, 1.0f);
        custom.SetVector(ParticleSystemCustomData.Custom1, 2, 0.01f);
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
        customData00.stringValue = "Fresnel Value";
        customData01.stringValue = "Alpha Value";
        customData02.stringValue = "Distortion Strength";
        customData03.stringValue = "not set";
        customData10.stringValue = "not set";
        customData11.stringValue = "not set";
        customData12.stringValue = "not set";
        customData13.stringValue = "not set";

        serializedObject.ApplyModifiedProperties();      

    }

}
