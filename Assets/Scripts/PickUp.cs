using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class NewBehaviourScript : MonoBehaviour
{
    public XRController controller; // Reference to the controller
    public UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button grabButton = UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button.Grip; // Button used for grabbing
    public float activationThreshold = 0.1f; // Sensitivity for grab detection

    private GameObject heldObject; // Currently held object
    private Transform originalParent; // Original parent of the object

    void Update()
    {
        // if (controller)
        // {
        //     bool isPressed = CheckIfButtonPressed(controller, grabButton);

        //     if (isPressed && heldObject == null) // Try to grab
        //     {
        //         TryGrab();
        //     }
        //     else if (!isPressed && heldObject != null) // Release
        //     {
        //         ReleaseObject();
        //     }
        // }
    }

    void TryGrab()
    {
        // Cast a sphere from the controller to detect nearby objects
        Collider[] hits = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var hit in hits)
        {
            if (hit.CompareTag("PickUp"))
            {
                heldObject = hit.gameObject;
                originalParent = heldObject.transform.parent;

                Rigidbody rb = heldObject.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.isKinematic = true; // Disable physics
                }

                heldObject.transform.SetParent(transform); // Attach to controller
                break;
            }
        }
    }

    void ReleaseObject()
    {
        // if (heldObject != null)
        // {
        //     Rigidbody rb = heldObject.GetComponent<Rigidbody>();
        //     if (rb)
        //     {
        //         rb.isKinematic = false; // Re-enable physics
        //         rb.velocity = controller.inputDevice.velocity; // Apply velocity for throwing
        //         rb.angularVelocity = controller.inputDevice.angularVelocity; // Apply spin
        //     }

        //     heldObject.transform.SetParent(originalParent); // Detach from controller
        //     heldObject = null;
        // }
    }

    // private bool CheckIfButtonPressed(XRController controller, UnityEngine.XR.Interaction.Toolkit.InputHelpers.Button button)
    // {
    //     // controller.inputDevice.IsPressed(button, out bool isPressed, activationThreshold);
    //     // return isPressed;
    // }
}