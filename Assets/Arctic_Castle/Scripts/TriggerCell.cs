using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCell : MonoBehaviour {

	public GameObject objectsInsideCell;
	public GameObject objectsOutsideCell;
	public bool playerStartsInsideCell = false;

	void Start() {
		if (playerStartsInsideCell) {			
			objectsInsideCell.SetActive (true);
			objectsOutsideCell.SetActive (false);
			Debug.Log("deactivated shore");
		}

		if (!playerStartsInsideCell) {
			objectsInsideCell.SetActive (false);
			objectsOutsideCell.SetActive (true);
			Debug.Log("deactivated castle");
        }

    }


	void OnTriggerEnter(Collider other){
        if (other.GetComponent<CharController_Motor>() == null) return;
        objectsInsideCell.SetActive (true);
		objectsOutsideCell.SetActive (false);
		Debug.Log("activated castle");

    }

	void OnTriggerExit(Collider other){
        if (other.GetComponent<CharController_Motor>() == null) return;
        objectsInsideCell.SetActive (false);
		objectsOutsideCell.SetActive (true);
		Debug.Log("smth");
    }
}
