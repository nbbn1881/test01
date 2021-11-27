using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Presets;
using System.IO;


public class FP_ShurikenTemplate : EditorWindow {

	

	[MenuItem("Window/FP TOOL/Shuriken Template")]
	static void ShowWindow()
	{
		EditorWindow.GetWindow<FP_ShurikenTemplate>();
	}

	void OnGUI()
	{
		if(GUILayout.Button("Create Root Object"))
		{
			GameObject emptyGameObject = new GameObject("FX_Template");
			GameObject rootObject = new GameObject("root");
			rootObject.transform.parent = emptyGameObject.transform;
			emptyGameObject.AddComponent<ParticleSystem>();
			rootObject.AddComponent<ParticleSystem>();

		}

		if(GUILayout.Button("View Dust Preset"))
		{
			string dustPath = "Assets/Preset/dust_up";
			string renderPresetPath = "Assets/Preset/_RenderModule";
			List<Preset> assetList = new List<Preset>();

			//フォルダ内の全てのファイルパスを取得（.metaも含まれる）
			string[] dustPathArray = Directory.GetFiles(dustPath,"*", SearchOption.AllDirectories);

			//AssetDatabaseを使ってリストに追加すると.metaが除外されて
			//Presetファイルだけがリストに入る
			foreach (string filePath in dustPathArray) 
			{
				Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(filePath);
				if(preset != null)
				{
					assetList.Add(preset);					
				}				
			}

			//リストのルートオブジェクトをPrefabから作成
			GameObject viewRootObj = new GameObject("View_Root");
			viewRootObj.AddComponent<ParticleSystem>();
			ParticleSystem rootPs = viewRootObj.GetComponent<ParticleSystem>();
			
			ParticleSystem.EmissionModule psEmission = rootPs.emission;
			psEmission.enabled = false;
			
			
			//View_Rootの子としてプリセットを適用したパーティクルを作成			
			for(int i = 0; i <= 6; i++)
			{
				GameObject sampleObject = new GameObject(assetList[i].name);
				sampleObject.transform.Rotate(-90.0f,0,0);//RotのXを-90度に設定
				sampleObject.transform.position = new Vector3(-i*5.0f , 0, 0);
				sampleObject.transform.parent = viewRootObj.transform;//親を"View_Root"に設定
				sampleObject.AddComponent<ParticleSystem>();
				ParticleSystem ps = sampleObject.GetComponent<ParticleSystem>();
				ParticleSystemRenderer psr = sampleObject.GetComponent<ParticleSystemRenderer>();
				assetList[i].ApplyTo(ps);//プリセット適用

				Preset preset = AssetDatabase.LoadAssetAtPath<Preset>(renderPresetPath + "/stretched.preset");
				preset.ApplyTo(psr);

				ParticleSystem.MainModule psMain = ps.main;
				psMain.loop = true;				
				psMain.duration = 1.0f;		

				
			}

			Selection.activeGameObject = viewRootObj;		
			
			

			
		}

	}
}
