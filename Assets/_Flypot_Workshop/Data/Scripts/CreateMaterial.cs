using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateMaterial : MonoBehaviour
{
    public ParticleSystem ps;
    public ParticleSystemRenderer psr;    
    Material mat;

    

    public void DuplicateObj(string creatorName)
    {
        var obj = Selection.activeGameObject;
        psr = obj.GetComponent<ParticleSystemRenderer>();
        int num;

        //マテリアルの末尾が数字か判定
        bool numStringFlag = int.TryParse(psr.sharedMaterial.name.Substring(psr.sharedMaterial.name.Length -2,2),out num);
        if(numStringFlag == false)
        {
            Debug.Log(psr.sharedMaterial.name);
            Debug.Log("マテリアルの末尾が数字ではありません");
            return;
        }

        string objName = Selection.activeGameObject.name + "_clone";
        GameObject copyObj = Instantiate(obj);
        copyObj.transform.parent = obj.transform.parent;
        copyObj.name = objName;        

        ps = copyObj.GetComponent<ParticleSystem> ();  
        psr = copyObj.GetComponent<ParticleSystemRenderer>();        

        Material mat = new Material(Shader.Find("Flypot/FP_ParticleStandard"));
        mat.CopyPropertiesFromMaterial(psr.sharedMaterial);

        string matName = psr.sharedMaterial.name;
        int i = int.Parse(matName.Substring(matName.Length -2,2)) + 1;
        string onlyName = matName.Substring(0,matName.Length -2);
        matName = onlyName + i.ToString("D2");

        //フォルダ内に同名のマテリアルがないか調べる
        bool flag = false;
        int count = 0;       
        
        while(flag == false)
        {
                
            string[] allName = AssetDatabase.FindAssets(matName, new[]{"Assets/_Member/" + creatorName + "/FP/Materials"});            
            if(allName.Length == 0 || count > 100)
            {
                flag = true;
            }
            else
            {
                i++;                
                matName = onlyName + i.ToString("D2");
                count++;
            }

        }
        Debug.Log(i.ToString());
        AssetDatabase.CreateAsset( mat, "Assets/_Member/" + creatorName + "/FP/Materials/" + matName + ".mat" );

        psr.sharedMaterial = mat;
    }
    

    public void DuplicateMaterial(string creatorName)
    {
        var obj = Selection.activeGameObject;
		ps = obj.GetComponent<ParticleSystem> ();  
        psr = obj.GetComponent<ParticleSystemRenderer>();     

        int num;

        //マテリアルの末尾が数字か判定
        bool numStringFlag = int.TryParse(obj.name.Substring(obj.name.Length -2,2),out num);
        if(numStringFlag == false)
        {
            Debug.Log("マテリアルの末尾が数字ではありません");
            return;
        }   

        Material mat = new Material(Shader.Find("Flypot/FP_ParticleStandard"));
        mat.CopyPropertiesFromMaterial(psr.sharedMaterial);

        string matName = psr.sharedMaterial.name;
        int i = int.Parse(matName.Substring(matName.Length -2,2)) + 1;
        string onlyName = matName.Substring(0,matName.Length -2);
        matName = onlyName + i.ToString("D2");
        
        //フォルダ内に同名のマテリアルがないか調べる
        bool flag = false;
        int count = 0;       
        
        while(flag == false)
        {
                
            string[] allName = AssetDatabase.FindAssets(matName, new[]{"Assets/_Member/" + creatorName + "/FP/Materials"});            
            if(allName.Length == 0 || count > 100)
            {
                flag = true;
            }
            else
            {
                i++;                
                matName = onlyName + i.ToString("D2");
                count++;
            }

        }

        Debug.Log(i.ToString());
        AssetDatabase.CreateAsset( mat, "Assets/_Member/" + creatorName + "/FP/Materials/" + matName + ".mat" );

    }
}
