
using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ArcheryTarget : MonoBehaviour
{
    private GameManager gameManager;
    public bool hit = false;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.GetComponent<Arrow>() != null)
        {
            if (hit) return;
            hit = true;
            gameManager.DecrementTarget();
            //collision.transform.GetComponent<Arrow>().DisablePhysics();
            
        }
    }

    public void SetHit()
    {
        if (hit) return;
        hit = true;
        gameManager.DecrementTarget();
    }
}
