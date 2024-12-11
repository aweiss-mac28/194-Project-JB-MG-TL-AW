using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RayCastGrab : MonoBehaviour
{
    public LineRenderer line;
    public GameObject collidingObject;
    public GameObject objectInHand;


    public InputActionAsset actions;
    private InputAction grabAction;

    void Awake()
    {
        grabAction = actions.FindActionMap("XRI RightHand Interaction").FindAction("Select");
        grabAction.performed += GrabObject;
        grabAction.canceled += ReleaseObject;
    }

    public void OnEnable()
    {
        grabAction.Enable();
    }

    public void OnDisable()
    {
        grabAction.Disable();
    }


    public void GrabObject(InputAction.CallbackContext context)
    {
        if (collidingObject != null)
        {
            objectInHand = collidingObject;
            objectInHand.transform.SetParent(this.transform);
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        }
    }


    public void ReleaseObject(InputAction.CallbackContext context)
    {
        if (objectInHand != null)
        {
            objectInHand.GetComponent<Rigidbody>().isKinematic = false;
            objectInHand.transform.SetParent(null);
            objectInHand = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        line.SetPosition(0, transform.position);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            line.SetPosition(1, hit.point);
            collidingObject = hit.collider.gameObject;
        }
        else
        {
            line.SetPosition(1, transform.position + 10f * transform.forward);
            collidingObject = null;
        }
    }
}
