using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class VelocityModuleCopyPaste : MonoBehaviour
{
    
    bool random = false;

    ParticleSystemSimulationSpace space;
    ParticleSystem.MinMaxCurve curveX;
    ParticleSystem.MinMaxCurve curveY;
    ParticleSystem.MinMaxCurve curveZ;
    ParticleSystem.MinMaxCurve orbitalX;
    ParticleSystem.MinMaxCurve orbitalY;
    ParticleSystem.MinMaxCurve orbitalZ;

    float multiX;
    float multiY;
    float multiZ;

    public void ForceModuleCopy()
    {
        var obj = Selection.activeGameObject;
		ParticleSystem ps = obj.GetComponent<ParticleSystem> ();
        var velocity = ps.velocityOverLifetime;
        orbitalX = velocity.orbitalOffsetX;
        orbitalY = velocity.orbitalOffsetY;
        orbitalZ = velocity.orbitalOffsetZ;
        orbitalZ = velocity.orbitalOffsetXMultiplier;
        orbitalZ = velocity.orbitalOffsetYMultiplier;
        orbitalZ = velocity.orbitalOffsetZMultiplier;
        orbitalZ = velocity.orbitalX;
        orbitalZ = velocity.orbitalX;
        orbitalZ = velocity.orbitalX;
        orbitalZ = velocity.orbitalXMultiplier;
        orbitalZ = velocity.orbitalXMultiplier;
        orbitalZ = velocity.orbitalXMultiplier;

        space = velocity.space;
        curveX = velocity.x;
        curveY = velocity.y;
        curveZ = velocity.z;
        multiX = velocity.xMultiplier;
        multiY = velocity.yMultiplier;
        multiZ = velocity.zMultiplier;

        Debug.Log("コピーしました");
    }

    public void ForceModulePaste()
    {
        var obj = Selection.activeGameObject;
		ParticleSystem ps = obj.GetComponent<ParticleSystem> ();
        var velocity = ps.forceOverLifetime;
        velocity.enabled = true;        
        velocity.randomized = random;
        velocity.space = space;
        velocity.x = curveX;
        velocity.y = curveY;
        velocity.z = curveZ;
        velocity.xMultiplier = multiX;
        velocity.yMultiplier = multiY;
        velocity.zMultiplier = multiZ;

        Debug.Log("ペーストしました");
    }

    
}
