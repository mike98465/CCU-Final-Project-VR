using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using System.Threading;
public class control : MonoBehaviour
{
    public GameObject[] solid;
    int time_start = 0;
    int time_end = 0;

    public GameObject[] Midpowder;
    public GameObject Powderleft;
    public GameObject Powderright;
    public GameObject Powdermid;
    public static int max = 0;

    public GameObject A;
    public ParticleSystem par;
    SteamVR_TrackedObject TransfromObj;
    
	public GameObject copy;
	public int cnt=0;
	public GameObject obj1;
	public GameObject obj2;
	public GameObject obj3;
	int del_start=0;
	public GameObject[] del_bean;
	public GameObject cap;
	public int cap_cnt=0;
	public GameObject grade;
	public GameObject final;
	public GameObject bun;

	//public bool flag = true;

	void Awake()
    {
        TransfromObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        par.GetComponent<ParticleSystem>().Stop();
		//cap.transform.rotation
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var device = SteamVR_Controller.Input((int)TransfromObj.index);
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            //Debug.Log("你按下了板機鍵");
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
           // Debug.Log("你鬆開了板機鍵");
        }
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
           // Debug.Log("你正按著板機鍵");
        }


        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
           // Debug.Log("你按下了菜單鍵");
        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Grip))
        {
            //Debug.Log("你正緊握");
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Grip))
        {
           // Debug.Log("你鬆開了");
        }

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f)
            {
               // Debug.Log("你按下了觸摸板的上");
                //Destroy(A);
                //par.GetComponent<ParticleSystem>().Play();
                //InvokeRepeating("timerStart", 1, 0.5f);

				//delete all coffeebeans
				if (cnt > 0) {
					InvokeRepeating("timerStart", 1, 0.5f);
                    //start the particleSystem
					par.GetComponent<ParticleSystem>().Play();

                    // top is the object where coffeebeans put on
					obj1 = GameObject.Find("top");
					beanSensor script1 = obj1.GetComponent<beanSensor> ();

					for (int i = 0; i < script1.coffeebeans.Length; i++)
						del_bean[i]=script1.coffeebeans [i];

					InvokeRepeating("destroy_bean", 0.5f, 0.5f);

					//cnt = 0;
			}

            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5)
            {
                //Debug.Log("你按下了觸摸板的下");
                if (Coffeepowder.max != 0 || CoffeepowderRight.max != 0)
                {
                    Powderleft.SetActive(false);
                    Powderright.SetActive(false);
                    Powdermid.SetActive(true);

                    int minus = Mathf.Abs(Coffeepowder.max - CoffeepowderRight.max);
                    int add = Coffeepowder.max + CoffeepowderRight.max;

                    //changes in powder models
                    if (minus % 2 == 0)
                    {
                        for (int i = 0; i < add / 2; i++)
                        {
                            Midpowder[i].SetActive(true);
                        }
                    }
                    if (minus % 2 == 1)
                    {
                        for (int i = 0; i < (add + 1) / 2; i++)
                        {
                            Midpowder[i].SetActive(true);
                        }
                    }
                }
            }

            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > 0.5f)
            {
                //Debug.Log("你按下了觸摸板的右");
            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -0.5f)
            {
                // Debug.Log("你按下了觸摸板的左");

                //remove cap
                if (cap_cnt == 0) {
					cap.SetActive (false);
					cap_cnt = 1;
				}
				else {	
					cap.SetActive (true);
					cap_cnt = 0;
				}
            }


        }

	if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y > 0.5f)
            {
                // Debug.Log("你觸摸了觸摸板的上");
            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).y < -0.5)
            {
                // Debug.Log("你觸摸了觸摸板的下");
            }

            if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x > 0.5f)
            {
                // Debug.Log("你觸摸了觸摸板的右");
            }
            else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x < -0.5f)
            {
                // Debug.Log("你觸摸了觸摸板的左");
            }
        }
        
        //notify user with pulsation
		pon script2 = obj2.GetComponent<pon> ();
		create_powder script3 = obj3.GetComponent<create_powder> ();
		if (script2.coffee_powder == 20 && script3.time_start != 4) {
			device.TriggerHapticPulse (2000);
		} else if (script3.time_start == 4)
			device.TriggerHapticPulse (0);

    }

    void timerStart()
    {
        time_start += 1;
        if (time_start == 6)
        {
            CancelInvoke("timerStart");
        }
			solid [time_start - 1].SetActive (true);
			//Debug.Log(time_start);
    }

    void test()
    {

        for (int i = 1; i < Midpowder.Length; i++)
        {
            //Debug.Log(int.Parse(sensorArray[i].tag));


            if (Midpowder[i].activeSelf && int.Parse(Midpowder[i].tag) > max)
                max = int.Parse(Midpowder[i].tag);


        }

        max = max / 10;
        //Debug.Log(max);
    }

    void Update()
    {
        test();
    }

	void destroy_bean()
	{
		del_start += 3;
		if (del_start == 100) {
			CancelInvoke ("destroy_bean");
		}
			
		//del_bean [del_start].SetActive (false);
		Destroy (del_bean [del_start - 3]);
		Destroy (del_bean [del_start - 2]);
		Destroy (del_bean [del_start - 1]);
	}
}

