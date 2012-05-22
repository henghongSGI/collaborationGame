using UnityEngine;
using System.Collections;

public class triggerCsScript : Photon.MonoBehaviour {
public float height = 3.2f;
private float speed = 2.0f;
private float timingOffset = 0.0f;
private bool startMove;
public GameObject target;

private Vector3 originPos;

// Use this for initialization
void Start () {
	startMove = false;
	originPos = target.transform.position;
}

// Update is called once per frame
void Update () {
	if (startMove) 
	{
	float math = Mathf.Sin(((float)PhotonNetwork.time)*speed+timingOffset);
	float offset = (1.0f + math )* height / 2.0f;
	Vector3 FinalPosition = originPos + new Vector3(0.0f, offset, 0.0f);
	if(target.transform.position != FinalPosition){
			 target.transform.position = Vector3.Lerp(target.transform.position, FinalPosition,  Time.deltaTime * 5);
			}
		}		
			
			
	}
/*	else if (!startMove && target.transform.position != originPos) {
		var currentPos = target.transform.position;
		target.transform.position = currentPos - Vector3(0, 0.1, 0);
	}
	else{
		target.transform.position = originPos;
		originPos = target.transform.position;
	}
	*/
void OnTriggerEnter() {
	startMove = true;
}

void OnTriggerExit() {
	startMove = false;
}


}