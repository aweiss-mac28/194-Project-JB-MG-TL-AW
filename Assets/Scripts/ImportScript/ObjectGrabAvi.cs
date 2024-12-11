using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

       public void OnTriggerEnter(Collider other){

       if(other.gameObject.GetComponent<Rigidbody>()) {
           collidingObject = other.gameObject;
       }
   }


   public void OnTriggerExit(Collider other)
   {
       collidingObject = null;
   }

    public void GrabObject(InputAction.CallbackContext context)
   {
       if (collidingObject != null) {
            objectInHand = collidingObject;
            objectInHand.transform.SetParent (this.transform);
            objectInHand.GetComponent<Rigidbody>().isKinematic = true;
        }
   }


   public void ReleaseObject(InputAction.CallbackContext context)
   {
       if (objectInHand != null) {
           objectInHand.GetComponent<Rigidbody>().isKinematic = false;
           objectInHand.transform.SetParent (null);
           objectInHand = null;
       }
   }

   public InputActionAsset actions;
   private InputAction grabAction;


   void Awake(){
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



}
