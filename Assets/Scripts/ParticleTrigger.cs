using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    public ParticleSystem particles;
    public bool badCrate;
    public GameMenuManager manager;
    public int boxNumber;
    public Transform player;
    public Transform checkPoint;
    AudioSource audio;
    bool taskCompleted = false;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sphere"))
        {
            particles.Play();
            audio.Play();
            manager.taskCompleted = true;
            switch (boxNumber)
            {
                case 1:
                    manager.ShowHint(3);
                    Invoke("HideHint", 4f);
                    break;
                case 2:
                    manager.ShowHint(4);
                    Invoke("HideHint", 4f);
                    break;
                case 3:
                    manager.ShowHint(5);
                    taskCompleted = true;
                    Invoke("HideHint", 4f);
                    break;
                default:
                    break;
            }
            other.enabled = false;
        }
    }
    void HideHint()
    {
        manager.HideHint();
    }
    private void Update()
    {
        if(badCrate)
        {
            if(taskCompleted)
            player.transform.position = checkPoint.position;
            taskCompleted = false;
        }
    }
}
