using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanSensor : MonoBehaviour {

	public GameObject A;
	public GameObject obj1;
	public GameObject[] coffeebeans;
	public int i=0;
	void OnTriggerEnter(Collider other)
	{
		//detect coffeebeans and notify control script
		if (other.gameObject.name.StartsWith("coffeebean")) { 
			coffeebeans[i++] = other.gameObject;  
			control script1 = obj1.GetComponent<control> ();
			Debug.Log (script1.cnt++);
		}
	}
}
