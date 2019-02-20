using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand_touch : MonoBehaviour {
	public bool tag = false;
	SteamVR_TrackedObject TransfromObj;

	public GameObject brown;
	public GameObject obj1;
    public GameObject obj2;



    void Awake()
	{
		TransfromObj = GetComponent<SteamVR_TrackedObject>();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.StartsWith ("Mesh") || other.gameObject.name.Equals("filter_paper")) 
		{
			SteamVR_Controller.Input((int)TransfromObj.index).TriggerHapticPulse (1500);
		} 
		
		//notify other scripts if triggered the button
		if (other.gameObject.name.StartsWith ("button")) 
		{
			obj1.GetComponent<NewJudgment> ().tag = true;

		}
        if (other.gameObject.name.StartsWith("bluebutton"))
        {
            obj2.GetComponent<CoffeeJudgment>().tag = true;
            

        }
}
