using UnityEngine;

public class Target : MonoBehaviour, IArrowHittable
{
    public float forceAmount = 1.0f;
    public Material otherMaterial = null;
    private GameManager gameManager;
    public bool hit = false;
    
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }
    
    public void Hit(Arrow arrow)
    {
        //ApplyMaterial();
        ApplyForce(arrow);
        DisableCollider(arrow);
        if (hit) return;
        hit = true;
        gameManager.DecrementTarget();
    }

    private void ApplyMaterial()
    {
        if (TryGetComponent(out MeshRenderer meshRenderer))
            meshRenderer.material = otherMaterial;
    }

    private void ApplyForce(Arrow arrow)
    {
        if (TryGetComponent(out Rigidbody rigidbody))
            rigidbody.AddForce(arrow.transform.forward * forceAmount);
    }

    private void DisableCollider(Arrow arrow)
    {
        if (arrow.TryGetComponent(out Collider collider))
            collider.enabled = false;
    }
}
