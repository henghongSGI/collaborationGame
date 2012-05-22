using UnityEngine;
using System.Collections;


/// <summary>
/// This script is attached to each player and ensures that each player's movements are updated across the network
/// </summary>



public class LiftUpdate : Photon.MonoBehaviour {
	
	
	
	//Variables
	private Vector3 lastPosition;
	private Quaternion lastRotation;
	private Transform myTransform;
	private Vector3 FinalPosition;
	
	
	// Use this for initialization
	void Awake () 
	{
		
		
			myTransform = transform;
			
			//Ensure that everyone sees the player at the correct location
			//the moment they spawn
			
		//	photonView.RPC("updateMovement", PhotonTargets.All, myTransform.position, myTransform.rotation);
			
		
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//If the player has moved at all then fire an RPC to update across the network
		GameObject SpawnManager = GameObject.Find("Code");
		GameManagerVik MoverTest = SpawnManager.GetComponent<GameManagerVik>();
		
		if(MoverTest.selectedClass == "Mover")
		{
			if(Vector3.Distance(myTransform.position, lastPosition) >=0.1)
			{
				//Capture the player's position before the RPC is fired
				//This determines if the player has moved in the previous if statement
			
				lastPosition = myTransform.position;
			
				photonView.RPC("updateMovement", PhotonTargets.All, myTransform.position, myTransform.rotation);
			}
		
			if(Quaternion.Angle(myTransform.rotation, lastRotation) >=1)
			{	
				//Capture the player's rotation before the RPC is fired
				//This determins if the player has turned in the previous if statement
			
				lastRotation = myTransform.rotation;
			
				photonView.RPC("updateMovement", PhotonTargets.All, myTransform.position, myTransform.rotation);
			}
			
		}
		else
		{
			if(myTransform.position != FinalPosition)
			{
				 transform.position = Vector3.Lerp(transform.position, FinalPosition,  0.05F);
			}
		}
	}
	
	

	[RPC]
	void updateMovement (Vector3 newPosition, Quaternion newRotation)
	{	
		
		 FinalPosition = newPosition;
		
	}
	
	
	
	
}
