using UnityEngine;
using System.Collections;

public class HairTailPhysicsSetup : MonoBehaviour
{
    public Transform snapTo;
    public float lowPassFactor = 0.1f;
    public float dragFactor = 1.5f;
    public float distanceToRadius = 0.4f;
    public float jointLimit = 10.0f;
    public float jointSpring = 1500.0f;

    void Start ()
    {
        foreach (var child in transform) {
            SetupNode (child as Transform);
            break;
        }
    }

    void FixedUpdate ()
    {
        rigidbody.MovePosition (snapTo.position);
        rigidbody.MoveRotation (snapTo.rotation);
    }

    void Update ()
    {
        foreach (var child in transform) {
            UpdatePosition (child as Transform);
            break;
        }
    }

    Transform FindOriginal (Transform node, string name)
    {
        if (node.name == name)
            return node;
        foreach (var childNode in node) {
            var found = FindOriginal (childNode as Transform, name);
            if (found)
                return found;
        }
        return null;
    }

    void UpdatePosition (Transform node)
    {
        var target = FindOriginal (snapTo, node.name).transform;
//      target.position = Vector3.Lerp (target.position, node.position, lowPassFactor);
        target.rotation = Quaternion.Slerp (target.rotation, node.rotation, lowPassFactor);
        foreach (var childNode in node) {
            UpdatePosition (childNode as Transform);
        }
    }

    void SetupNode (Transform node)
    {
        node.transform.localPosition *= 1.0f;

        var distance = (node.parent.transform.position - node.transform.position).magnitude;

        var col = node.gameObject.AddComponent<SphereCollider> ();
        col.radius = distance * distanceToRadius;

        var rb = node.gameObject.AddComponent<Rigidbody> ();
        rb.drag = dragFactor;
        rb.angularDrag = dragFactor;

        var joint = node.gameObject.AddComponent<ConfigurableJoint> ();
        joint.connectedBody = node.parent.rigidbody;
        joint.axis = Vector3.right;
        joint.secondaryAxis = Vector3.up;

        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;
        joint.angularXMotion = ConfigurableJointMotion.Locked;

		joint.angularYMotion = ConfigurableJointMotion.Locked;
        joint.angularZMotion = ConfigurableJointMotion.Locked;

        var limit = new SoftJointLimit ();
        limit.limit = jointLimit;
        limit.spring = jointSpring;

        joint.angularYLimit = limit;
        joint.angularZLimit = limit;

        joint.projectionDistance = distance;
        joint.projectionMode = JointProjectionMode.PositionOnly;

        foreach (var childNode in node) {
            SetupNode (childNode as Transform);
        }
    }
}