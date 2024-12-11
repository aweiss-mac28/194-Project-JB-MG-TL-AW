using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectGrab : MonoBehaviour
{
    public GameObject collidingObject;
    public GameObject objectInHand;

    public float multiplier; 

    private UnityEngine.Vector3 prevPosition;

    private UnityEngine.Vector3 movement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = transform.position - prevPosition;
        prevPosition = transform.position;
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
           objectInHand.GetComponent<Rigidbody>().AddForce(movement*multiplier, ForceMode.Impulse); 
           objectInHand.transform.SetParent (null);
           objectInHand = null;
       }
   }

//try over the last 3 movement vectors 
//combine all 3 on a scale that decreases over time ie 90% times the first one plus .5 of the second to last one plus .15 of the last one

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
