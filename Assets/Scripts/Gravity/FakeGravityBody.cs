using UnityEngine;

// Bu scriptin olduğu gameobjelerde muhakkak RigidBody olmalı
[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour
{
    FakeGravityAttractor attractor;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        attractor = Resources.Load<FakeGravityAttractor>("Planet/Planet");

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        rigidbody.useGravity = false;
    }
    private void Update()
    {
        attractor.Attract(transform);
    }
}
