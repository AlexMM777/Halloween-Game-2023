using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisableAndEnableUI : MonoBehaviour
{
    private Animator originalAn;

    public void EnableGameObject(GameObject item)
    {
        item.SetActive(true);
    }

    public void DisableGameObject(GameObject item)
    {
        item.SetActive(false);
    }

    public void EnableMeshRenderer(SkinnedMeshRenderer item)
    {
        item.enabled = true;
    }

    public void DisableMeshRenderer(SkinnedMeshRenderer item)
    {
        item.enabled = false;
    }

    public void EnablePlayerController(PlayerMovement item)
    {
        item.enabled = true;
    }

    public void DestroyCapsuleCollider(CapsuleCollider item)
    {
        Destroy(item);
    }
    public void EnableCapsuleCollider(CapsuleCollider item)
    {
        item.enabled = true;
    }

    public void DestroyObjectRotator(ObjectRotator item)
    {
        Destroy(item);
    }
    public void DestroyColorScript(FCP_ExampleScript item)
    {
        Destroy(item);
    }

    public void GetAnimator(Animator item)
    {
        originalAn = item;
    }

    public void AssignNewAnContr(RuntimeAnimatorController item)
    {
        originalAn.runtimeAnimatorController = item;
    }

    public void SetRigBodKinematicFalse(Rigidbody item)
    {
        item.isKinematic = false;
    }

    public void DestroyGameObject(GameObject item) 
    {
        Destroy(item);
    }

}
