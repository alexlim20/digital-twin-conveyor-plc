using UnityEngine;
using S7.Net;

public class ConveyorBelt : MonoBehaviour
{
    [Header("Conveyor Settings")]
    public bool isRunning = false;
    public float beltspeed = 2.0f;
    public Vector3 pushDirection = Vector3.right;

    void Update()
    {
        if (isRunning)
        {
            float offset = Time.time * beltspeed * 0.2f;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offset, 0);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (isRunning && collision.rigidbody != null)
        {
            Vector3 newVelocity = pushDirection * beltspeed;
            newVelocity.y = collision.rigidbody.linearVelocity.y; // Preserve vertical velocity
            collision.rigidbody.linearVelocity = newVelocity;
        }
    }
}