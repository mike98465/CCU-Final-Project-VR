using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machine_cup : MonoBehaviour {

	public GameObject abc;
	public ParticleSystem left;
	public ParticleSystem right;
	public ParticleSystem front;
	public ParticleSystem back;
	
	//GameObject r is for position reference
	public GameObject r;
	int cnt1 = 0;
	public GameObject coffee;
	public GameObject copy;
	Vector3 pos;
	public bool test1 = false;
	public GameObject[] water;
	public GameObject wat;
	int water_cnt=0;

	//Instantiate a coffeebean with one direction (left), if you want it can run for other directions,
	//you have to add those.
	void Update () {
		if (/*Mathf.Abs*/(abc.transform.rotation.x) > 0.4f)
		{
			if (wat.activeSelf == true) {	
				left.GetComponent<ParticleSystem> ().Play ();
				InvokeRepeating ("close", 0.5f, 5);

				/*instantiate a coffeebean per action*/

				if (cnt1 < 1) {
					pos = r.transform.position;
					Instantiate (copy, pos, Quaternion.identity);
					cnt1++;
				}

				test1 = true;
			}
		}
		else
		{
			left.GetComponent<ParticleSystem>().Stop();
			CancelInvoke("close");
			if (wat.activeSelf == true) {	
				if (test1 == true) {
					Instantiate (coffee, pos, Quaternion.identity);
					test1 = false;
				}
				cnt1 = 0;
			}
		}
		//According to the cup direction to open particleSystem
		if (/*Mathf.Abs*/(abc.transform.rotation.x) < -0.4f)
		{
			right.GetComponent<ParticleSystem>().Play();
		}
		else
		{
			right.GetComponent<ParticleSystem>().Stop();
		}

		if (/*Mathf.Abs*/(abc.transform.rotation.z) > 0.4f)
		{
			front.GetComponent<ParticleSystem>().Play();
		}
		else
		{
			front.GetComponent<ParticleSystem>().Stop();
		}

		if (/*Mathf.Abs*/(abc.transform.rotation.z) < -0.4f)
		{
			back.GetComponent<ParticleSystem>().Play();
		}
		else
		{
			back.GetComponent<ParticleSystem>().Stop();
		}

	}

	void close()
	{
		water [water_cnt++].SetActive (false);
		if (water_cnt == 2)
			wat.SetActive (false);
	}
}
