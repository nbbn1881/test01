using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ModuleCopyPaste : MonoBehaviour
{
    public ParticleSystem copyPs;
    public ParticleSystem pastePs;   

    public void ModuleCopy()
    {
        var obj = Selection.activeGameObject;
		copyPs = obj.GetComponent<ParticleSystem> ();       

        Debug.Log(copyPs.name.ToString());
    }

    public void ModulePaste(int i)
    {
        switch(i)
        {
            case 0:
                VelocityModulePaste();
                break;
            case 1:
                LimitModulePaste();
                break;
            case 2:
                ForceModulePaste();
                break;
            case 3:
                SizeModulePaste();
                break;
            case 4:
                RotationModulePaste();
                break;
            case 5:
                TextureModulePaste();
                break;
            default:
                break;
        }
    }

    public void ForceModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteForce = pastePs.forceOverLifetime;
        var copyForce = copyPs.forceOverLifetime;        
        
        pasteForce.enabled = true;        
        pasteForce.randomized = copyForce.randomized;
        pasteForce.space = copyForce.space;
        pasteForce.x = copyForce.x;
        pasteForce.y = copyForce.y;
        pasteForce.z = copyForce.z;
        pasteForce.xMultiplier = copyForce.xMultiplier;
        pasteForce.yMultiplier = copyForce.yMultiplier;
        pasteForce.zMultiplier = copyForce.zMultiplier;       

        Debug.Log("ペーストしました");
    }

    public void VelocityModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteVelocity = pastePs.velocityOverLifetime;
        var copyVelocity = copyPs.velocityOverLifetime;        
        
        pasteVelocity.enabled = true;        
        pasteVelocity.orbitalOffsetX = copyVelocity.orbitalOffsetX;
        pasteVelocity.orbitalOffsetY = copyVelocity.orbitalOffsetY;
        pasteVelocity.orbitalOffsetZ = copyVelocity.orbitalOffsetZ;
        pasteVelocity.orbitalOffsetXMultiplier = copyVelocity.orbitalOffsetXMultiplier;
        pasteVelocity.orbitalOffsetYMultiplier = copyVelocity.orbitalOffsetYMultiplier;
        pasteVelocity.orbitalOffsetZMultiplier = copyVelocity.orbitalOffsetZMultiplier;

        pasteVelocity.orbitalX = copyVelocity.orbitalX;
        pasteVelocity.orbitalY = copyVelocity.orbitalY;
        pasteVelocity.orbitalZ = copyVelocity.orbitalZ;
        pasteVelocity.orbitalXMultiplier = copyVelocity.orbitalXMultiplier;
        pasteVelocity.orbitalYMultiplier = copyVelocity.orbitalYMultiplier;
        pasteVelocity.orbitalZMultiplier = copyVelocity.orbitalZMultiplier;

        pasteVelocity.radial = copyVelocity.radial;
        pasteVelocity.radialMultiplier = copyVelocity.radialMultiplier;
        
        pasteVelocity.space = copyVelocity.space;
        pasteVelocity.speedModifier = copyVelocity.speedModifier;
        pasteVelocity.speedModifierMultiplier = copyVelocity.speedModifierMultiplier;
        
        pasteVelocity.x = copyVelocity.x;
        pasteVelocity.y = copyVelocity.y;
        pasteVelocity.z = copyVelocity.z;
        pasteVelocity.xMultiplier = copyVelocity.xMultiplier;
        pasteVelocity.yMultiplier = copyVelocity.yMultiplier;
        pasteVelocity.zMultiplier = copyVelocity.zMultiplier;
       

        Debug.Log("ペーストしました");
    }

    public void SizeModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteSize = pastePs.sizeOverLifetime;
        var copySize = copyPs.sizeOverLifetime;        
        
        pasteSize.enabled = true;   
        pasteSize.separateAxes = copySize.separateAxes;
        pasteSize.size = copySize.size;
        pasteSize.sizeMultiplier = copySize.sizeMultiplier;          
        
        pasteSize.x = copySize.x;
        pasteSize.y = copySize.y;
        pasteSize.z = copySize.z;
        pasteSize.xMultiplier = copySize.xMultiplier;
        pasteSize.yMultiplier = copySize.yMultiplier;
        pasteSize.zMultiplier = copySize.zMultiplier;      

        Debug.Log("ペーストしました");
    }

    public void RotationModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteRotation = pastePs.rotationOverLifetime;
        var copyRotation = copyPs.rotationOverLifetime;        
        
        pasteRotation.enabled = true;   
        pasteRotation.separateAxes = copyRotation.separateAxes;        
        
        pasteRotation.x = copyRotation.x;
        pasteRotation.y = copyRotation.y;
        pasteRotation.z = copyRotation.z;
        pasteRotation.xMultiplier = copyRotation.xMultiplier;
        pasteRotation.yMultiplier = copyRotation.yMultiplier;
        pasteRotation.zMultiplier = copyRotation.zMultiplier;      

        Debug.Log("ペーストしました");
    }

    public void TextureModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteTexture = pastePs.textureSheetAnimation;
        var copyTexture = copyPs.textureSheetAnimation;        
        
        pasteTexture.enabled = true;   
        pasteTexture.animation = copyTexture.animation;
        pasteTexture.cycleCount = copyTexture.cycleCount;
        pasteTexture.fps = copyTexture.fps;
        pasteTexture.frameOverTime = copyTexture.frameOverTime;
        pasteTexture.frameOverTimeMultiplier = copyTexture.frameOverTimeMultiplier;
        pasteTexture.mode = copyTexture.mode;
        pasteTexture.numTilesX = copyTexture.numTilesX;
        pasteTexture.numTilesY = copyTexture.numTilesY;
        pasteTexture.rowIndex = copyTexture.rowIndex;
        pasteTexture.speedRange = copyTexture.speedRange;        
        pasteTexture.startFrame = copyTexture.startFrame;
        pasteTexture.startFrameMultiplier = copyTexture.startFrameMultiplier;
        pasteTexture.timeMode = copyTexture.timeMode;
        pasteTexture.useRandomRow = copyTexture.useRandomRow;
        pasteTexture.uvChannelMask = copyTexture.uvChannelMask;

        Debug.Log("ペーストしました");
    }

    public void LimitModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();
        var pasteLimit = pastePs.limitVelocityOverLifetime;
        var copyLimit = copyPs.limitVelocityOverLifetime;        
        
        pasteLimit.enabled = true;        
        pasteLimit.dampen = copyLimit.dampen;
        pasteLimit.drag = copyLimit.drag;
        pasteLimit.dragMultiplier = copyLimit.dragMultiplier;
        pasteLimit.limit = copyLimit.limit;
        pasteLimit.limitMultiplier = copyLimit.limitMultiplier;
        pasteLimit.limitX = copyLimit.limitX;
        pasteLimit.limitY = copyLimit.limitY;
        pasteLimit.limitZ = copyLimit.limitZ;
        pasteLimit.limitXMultiplier = copyLimit.limitXMultiplier;
        pasteLimit.limitYMultiplier = copyLimit.limitYMultiplier;
        pasteLimit.limitZMultiplier = copyLimit.limitZMultiplier;
        pasteLimit.multiplyDragByParticleSize = copyLimit.multiplyDragByParticleSize;
        pasteLimit.multiplyDragByParticleVelocity = copyLimit.multiplyDragByParticleVelocity;
        pasteLimit.separateAxes = copyLimit.separateAxes;
        pasteLimit.space = copyLimit.space;       

        Debug.Log("ペーストしました");
    }

   /*
   public void EmissionModulePaste()
    {
        var obj = Selection.activeGameObject;
		pastePs = obj.GetComponent<ParticleSystem> ();        
        var pasteEmission = pastePs.emission;
        var copyEmission = copyPs.emission;        
        
        pasteEmission.enabled = true;   
        pasteEmission.burstCount = copyEmission.burstCount;        
        pasteEmission.rateOverDistance = copyEmission.rateOverDistance;
        pasteEmission.rateOverDistanceMultiplier = copyEmission.rateOverDistanceMultiplier;
        pasteEmission.rateOverTime = copyEmission.rateOverTime;
        pasteEmission.rateOverTimeMultiplier = copyEmission.rateOverTimeMultiplier;
        

        Debug.Log("ペーストしました");
    }*/

    
}
