using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float m_Speed = 2000.0f;
    public Transform m_Tip;
    
    private Rigidbody m_rigidbody;
    private bool m_isStopped;
    private Vector3 m_lastPosition;

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_isStopped) return;

        m_rigidbody.MoveRotation(Quaternion.LookRotation(m_rigidbody.velocity, transform.up));

        if (Physics.Linecast(m_lastPosition, m_Tip.position))
        {
            Stop();
        }

        m_lastPosition = m_Tip.position;
    }

    private void Stop()
    {
        m_isStopped = true;

        m_rigidbody.isKinematic = true;
        m_rigidbody.useGravity = false;
        
        Debug.Log("");
    }

    public void Fire(float pullValue)
    {
        m_isStopped = false;
        transform.parent = null;

        m_rigidbody.isKinematic = false;
        m_rigidbody.useGravity = true;
        m_rigidbody.AddForce(transform.forward * (pullValue * m_Speed));
        
        Destroy(gameObject, 5.0f);
    }
}
