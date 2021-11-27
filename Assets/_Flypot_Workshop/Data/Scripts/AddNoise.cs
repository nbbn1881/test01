using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AddNoise : MonoBehaviour
{
    public ParticleSystem ps;
    // Start is called before the first frame update
    public void AddNoisePs(int pointCount, float noiseScale)
    {
        var obj = Selection.activeGameObject;
		ps = obj.GetComponent<ParticleSystem> ();  

        AnimationCurve curve = new AnimationCurve();
        for(int i = 0; i <= pointCount; i++)
        {
            curve.AddKey((1.0f/pointCount)*i, Mathf.PerlinNoise((1.0f/pointCount)* i *noiseScale,(1.0f/pointCount)* i *noiseScale));
        }   

        var size = ps.sizeOverLifetime;
        size.size = new ParticleSystem.MinMaxCurve(1.0f,curve);

        
    }

}
