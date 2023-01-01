using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateGrabRay : MonoBehaviour
{
    public GameObject leftGrabRay;
    public GameObject rightGrabRay;

    public XRDirectInteractor leftDirectGrab;
    public XRDirectInteractor rightDirectGrab;
    bool withBall = false;
    public GameMenuManager manager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        leftGrabRay.SetActive(leftDirectGrab.interactablesSelected.Count == 0);
        rightGrabRay.SetActive(rightDirectGrab.interactablesSelected.Count == 0);

        if (withBall) return;
        if(rightDirectGrab.interactablesSelected.Count >0 || leftDirectGrab.interactablesSelected.Count > 0)
        {
            withBall = true;

            if (manager.gameStarted == false)
                return;

                manager.ShowMenu();
                manager.sphereUI.SetActive(false);
                manager.gameStarted = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("HintTrigger"))
        {
            if (withBall)
            {
                manager.HideMenu();
                manager.ShowHint(2);
            }
            else if (!withBall)
            {
                manager.HideMenu();
                manager.ShowHint(1);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("HintTrigger"))
        {
            manager.HideHint();
        }
    }
}
