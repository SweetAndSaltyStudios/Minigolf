using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallEngine : MonoBehaviour
{
    [SerializeField] private Color32 ballColor = default;

    private Rigidbody rb = default;

    private MeshRenderer meshRenderer = default;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void Start()
    {
        if(meshRenderer == null) return;

        meshRenderer.material.color = ballColor;
    }

    public void Shoot(float dragDistance)
    {
        if(rb == null) return;

        rb.AddForce(Vector3.forward * dragDistance, ForceMode.Impulse);
    }
}
