using UnityEngine;
using System.Collections;

public class triggerMovePlatform extends Photon.MonoBehaviour {
private float height = 3.2;
private float speed = 2.0;
private float timingOffset = 0.0;
private boolean startMove;
private GameObject target;

private Vector3 originPos;

// Use this for initialization
void Start () {
	startMove = false;
	originPos = target.transform.position;
}

// Update is called once per frame
void Update () {
	if (startMove  && PhotonNetwork.isMasterClient) 
	{
		//var offset = (1 + Mathf.Sin(PhotonNetwork.time * speed + timingOffset)) * height / 2;
		//target.transform.position = originPos + Vector3(0, offset, 0);
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
}

void OnTriggerEnter() {
	startMove = true;
}

void OnTriggerExit() {
	startMove = false;
}


}