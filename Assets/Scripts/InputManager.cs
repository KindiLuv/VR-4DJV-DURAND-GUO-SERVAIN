
using System;
using DefaultNamespace;
using UnityEngine;
[RequireComponent(typeof(Bow))]
public class InputManager : MonoBehaviour
{
    private Bow m_bow;

    private void Start()
    {
        m_bow = GetComponent<Bow>();
    }

    
    void Update()
    {
        //left Click
        if (Input.GetMouseButtonUp(0))
        {
            m_bow.Release();
        }
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Mouse 0 - Left Click");
            m_bow.Pull();
        }
        
        //Right Click
        if (Input.GetMouseButton(1))
        {
            Debug.Log("Mouse 1 - Right Click");
        }
    }
}
