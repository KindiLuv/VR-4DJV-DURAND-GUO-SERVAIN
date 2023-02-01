
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ArcheryTarget : MonoBehaviour
{
    [SerializeField] private int targetScore;
    [SerializeField] private bool isResetTarget;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Arrow>() != null)
        {
            if(isResetTarget) gameManager.resetScore();
            else gameManager.addScore(targetScore);
        }
    }
}
