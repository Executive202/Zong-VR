using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public GameMenuManager manager;
    public int indexHint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ShowHint(indexHint);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.HideHint();
        }
    }
}
