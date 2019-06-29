using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField]
    private GameObject left;
    [SerializeField]
    private GameObject right;

    [SerializeField] private float spring;
    [SerializeField] private float damper;
    [SerializeField] private float openAngle;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) openFlipper(left);
        if (Input.GetKeyUp(KeyCode.F)) closeFlipper(left);
        if (Input.GetKeyDown(KeyCode.J)) openFlipper(right);
        if (Input.GetKeyUp(KeyCode.J)) closeFlipper(right);
    }
    private void openFlipper(GameObject flipper)
    {
        JointSpring joint = flipper.GetComponent<HingeJoint>().spring;
        joint.spring = spring;
        joint.damper = damper;
        joint.targetPosition += openAngle;
        flipper.GetComponent<HingeJoint>().spring = joint;
    }

    private void closeFlipper(GameObject flipper)
    {
        JointSpring joint = flipper.GetComponent<HingeJoint>().spring;
        joint.spring = spring;
        joint.damper = damper;
        joint.targetPosition -= openAngle;
        flipper.GetComponent<HingeJoint>().spring = joint;
    }
}
