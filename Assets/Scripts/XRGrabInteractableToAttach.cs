using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRGrabInteractableToAttach : XRGrabInteractable
{
    public Transform leftAttachTransform;
    public Transform rightAttachTransform;
    public GameMenuManager manager;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.CompareTag("LefHand"))
        {
            attachTransform = leftAttachTransform;
        }else if(args.interactableObject.transform.CompareTag("RightHand"))
        {
            attachTransform = rightAttachTransform;
        }

        base.OnSelectEntered(args);
    }
    private void Update()
    {
        
    }
    
}
