using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class GameMenuManager : XRGrabInteractable
{
    public GameObject menu, sphereUI;
    public GameObject mainMenu,otherMenu;
    public Transform head;
    public float spawnDistance = 2;
    public bool gameStarted = true;
    public TextMeshProUGUI hintText;
    public string []hinted;
    public GameObject[] TriggerPoints;
    public bool taskCompleted = false;
    bool showMenu = false;
    private Vector3 relativePosition;
    // Start is called before the first frame update
    void Start()
    {
        ShowHint(1);
        showMenu = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (showMenu ==true)
        {
            menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
            relativePosition = new Vector3(menu.transform.position.x - head.position.x, 0, menu.transform.position.z - head.position.z);
        }
        menu.transform.position = head.position + relativePosition;
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
        sphereUI.transform.forward *= 1;

        if (taskCompleted == false)
        {
            return;
        }
        else
        {
            for (int i = 0; i < TriggerPoints.Length; i++)
            {
                TriggerPoints[i].SetActive(false);
            }
        }
    }
    public void ShowMenu()
    {
        showMenu = true;
        menu.SetActive(true);
        mainMenu.SetActive(true);
        menuDisplayHintHide();
    }
    public void  menuDisplayHintHide()
    {
        hintText.text = "";
        otherMenu.SetActive(false);
    }
    public void HideMenu()
    {
        showMenu = false;
        mainMenu.SetActive(false);
        menu.SetActive(false);
    }
    public void ShowHint(int index)
    {
        showMenu = true;
        menu.SetActive(true);
        mainMenu.SetActive(false);
        otherMenu.SetActive(true);
        hintText.text = hinted[index];
    }
    public void HideHint()
    {
        showMenu = false;
        hintText.text = "";
        menu.SetActive(false);
        otherMenu.SetActive(false);
    }
}
