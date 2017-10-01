using UnityEngine;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour {
	
	public float speed = 6f;
	public Transform pickPivot;
	
	Rigidbody rb;
	Vector3 movement;
	
	Animator anim;                      // Reference to the animator component.
	int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
    float camRayLength = 100f;          // The length of the ray from the camera into the scene.
    bool isHolding = false;
        
    List<GameObject> closeObj;
	
	void Awake(){
		rb = GetComponent<Rigidbody>();
		anim = GetComponent<Animator>();
		// Create a layer mask for the floor layer.
        floorMask = LayerMask.GetMask ("Floor");
        
        closeObj = new List<GameObject>();
	}
	
	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Dice")){
			closeObj.Add(other.gameObject);
		}
	}
	
	void OnTriggerExit(Collider other){
		if(closeObj.Contains(other.gameObject)){
			closeObj.Remove(other.gameObject);
		}
	}
	
	void FixedUpdate(){
		// Store the input axes.
        float h = Input.GetAxisRaw ("Horizontal");
        float v = Input.GetAxisRaw ("Vertical");

        // Move the player around the scene.
        Move (h, v);
		
		// Turn the player to face the mouse cursor.
        Turning ();
		
		// Animate the player.
        Animating (h, v);
        
        Shoot();
        
        PickDice();
	}
	
	void Move (float h, float v)
    {
        // Set the movement vector based on the axis input.
        movement.Set (h, 0f, v);
        
        // Normalise the movement vector and make it proportional to the speed per second.
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        rb.MovePosition (transform.position + movement);
    }
	
	void Turning ()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation (playerToMouse);

            // Set the player's rotation to this new rotation.
            rb.MoveRotation (newRotation);
        }
    }
	
	void Animating (float h, float v)
    {
        // Create a boolean that is true if either of the input axes is non-zero.
        bool walking = h != 0f || v != 0f;

        // Tell the animator whether or not the player is walking.
        anim.SetBool ("IsRunning", walking);
    }
    
    void Shoot(){
		bool isShooting = Input.GetButton("Fire1");
		anim.SetBool ("IsShooting", isShooting);
	}
	
	void PickDice(){
		
		if(Input.GetButtonDown("Fire2") && !isHolding){
			closeObj[0].GetComponent<DiceScript>().ResetDice();
			closeObj[0].GetComponent<Rigidbody>().isKinematic = true;
			closeObj[0].transform.parent = pickPivot;
			//closeObj[0].transform.position = Vector3.zero;
			isHolding = true;
		}else if(Input.GetButtonDown("Fire2") && isHolding){
			closeObj[0].GetComponent<DiceScript>().PlayDice();
			closeObj[0].transform.parent = null;
			closeObj[0].GetComponent<Rigidbody>().isKinematic = false;
			isHolding = false;
		}
	}
}
