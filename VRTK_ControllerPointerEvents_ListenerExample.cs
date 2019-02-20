namespace VRTK.Examples
{
    using UnityEngine;
	using UnityEngine.Video;
	using UnityEngine.SceneManagement;
	using System.Collections.Generic;
	using System.Collections;
    public class VRTK_ControllerPointerEvents_ListenerExample : MonoBehaviour
    {
        public bool showHoverState = false;
		SteamVR_TrackedObject TransfromObj;
		
		//objects for tutorial
		public GameObject camera;
		public GameObject obj1;
		public GameObject obj2;
		public GameObject obj3;
		public GameObject obj4;
		public GameObject obj5;
		public GameObject obj6;
		public GameObject obj7;
		public GameObject obj8;
		public GameObject obj9;
		public GameObject obj10;
		public GameObject obj11;
		public GameObject obj12;
		public Behaviour[] obj13;
		public VideoClip abc;
		public VideoPlayer videoplayer123;
		public AudioSource music;
		public GameObject panel;

		public GameObject abc1;
		public GameObject abc2;
		public GameObject abc3;
		public GameObject abc4;
		public GameObject abc5;
		public GameObject abc6;
		public Material color1;
		public Material color2;
		public static bool open = true;
		public static bool open2 = true;

		public bool lock1 = true;
		public bool lock2 = false;

		public GameObject movieComfirm;
		bool isplaying = false;
		public yesornoConfirm yesnoConfirm;

		public bool uiIsOpen = false;
        private void Start()
        {

            if (GetComponent<VRTK_DestinationMarker>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerPointerEvents_ListenerExample", "VRTK_DestinationMarker", "the Controller Alias"));
                return;
            }

            //Setup controller event listeners
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
            if (showHoverState)
            {
                GetComponent<VRTK_DestinationMarker>().DestinationMarkerHover += new DestinationMarkerEventHandler(DoPointerHover);
            }
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
            GetComponent<VRTK_DestinationMarker>().DestinationMarkerSet += new DestinationMarkerEventHandler(DoPointerDestinationSet);
        }

        private void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
        {
            string targetName = (target ? target.name : "<NO VALID TARGET>");
            string colliderName = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
            VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + targetName + "] on the collider named [" + colliderName + "] - the pointer tip position is/was: " + tipPosition);
        }
		
		//pointer events control
        private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER IN", e.target, e.raycastHit, e.distance, e.destinationPosition);
			if (e.target.name == "botton_1") {
				camera.transform.position = obj1.transform.position;
				camera.transform.rotation = obj1.transform.rotation;
			} else if (e.target.name == "confirm") {
				lock1 = false;
				obj12.SetActive (false);
			} else if (e.target.name == "no") {
				panel.SetActive (false);
				lock2 = true;
			} else if (e.target.name == "yes") {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			} else if (e.target.name == "yesToWatch") {
				videoplayer123.gameObject.SetActive (true);
				music.gameObject.SetActive (true);
				movieComfirm.SetActive (false);
				lock1 = true;
			} else if (e.target.name == "noWatch") {
				videoplayer123.gameObject.SetActive (false);
				music.gameObject.SetActive (false);
				movieComfirm.SetActive (false);

				lock1 = false;
				StartCoroutine (ToNextScene());
			}else if (e.target.name == "Plane") {
					videoplayer123.Play ();
					music.Play ();
			} 
			else if (e.target.name == "on1") {
				videoplayer123.gameObject.SetActive (true);
				music.gameObject.SetActive (true);
				abc1.GetComponent<Renderer> ().material = color1;
				abc2.GetComponent<Renderer> ().material = color2;
			}else if (e.target.name == "off1") {
				videoplayer123.gameObject.SetActive (false);
				music.gameObject.SetActive (false);
				abc1.GetComponent<Renderer> ().material = color2;
				abc2.GetComponent<Renderer> ().material = color1;
			}else if (e.target.name == "on2") {
				open = true;
				abc3.GetComponent<Renderer> ().material = color1;
				abc4.GetComponent<Renderer> ().material = color2;
			}else if (e.target.name == "off2") {
				open = false;
				abc3.GetComponent<Renderer> ().material = color2;
				abc4.GetComponent<Renderer> ().material = color1;
			}else if (e.target.name == "on3") {
				open2 = true; 
				abc5.GetComponent<Renderer> ().material = color1;
				abc6.GetComponent<Renderer> ().material = color2;
			}else if (e.target.name == "off3") {
				open2 = false;
				abc5.GetComponent<Renderer> ().material = color2;
				abc6.GetComponent<Renderer> ().material = color1;
			}

			if (lock1 == false) {
				if (e.target.name == "ggg"&&uiIsOpen == false) {
					obj2.SetActive (true);
					uiIsOpen = true;
					obj2.GetComponent<yesno> ().yesorno = true;
				}
				else if (e.target.name.StartsWith ("Cusinart")&&uiIsOpen == false) {
					obj3.SetActive (true);
					uiIsOpen = true;
					obj3.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("Coffee")&&uiIsOpen == false) {
					obj4.SetActive (true);
					uiIsOpen = true;
					obj4.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("blue")&&uiIsOpen == false) {
					obj5.SetActive (true);
					uiIsOpen = true;
					obj5.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("big")&&uiIsOpen == false) {
					obj6.SetActive (true);
					uiIsOpen = true;
					obj6.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("filter")&&uiIsOpen == false) {
					obj7.SetActive (true);
					uiIsOpen = true;
					obj7.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("kettle")&&uiIsOpen == false) {
					obj8.SetActive (true);
					uiIsOpen = true;
					obj8.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("mug")&&uiIsOpen == false) {
					obj9.SetActive (true);
					uiIsOpen = true;
					obj9.GetComponent<yesno> ().yesorno = true;
				} else if (e.target.name.StartsWith ("water")&&uiIsOpen == false) {
					obj10.SetActive (true);
					uiIsOpen = true;
					obj10.GetComponent<yesno> ().yesorno = true;	
				} else if (e.target.name.StartsWith ("pow")&&uiIsOpen == false) {
					obj11.SetActive (true);
					uiIsOpen = true;
					obj11.GetComponent<yesno> ().yesorno = true;
				}
				if (e.target.name == "confirm1") {
					obj2.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm2")) {
					obj4.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm3")) {
					obj3.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm4")) {
					obj5.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm5")) {
					obj6.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm6")) {
					obj7.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm7")) {
					obj8.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm8")) {
					obj9.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm9")) {
					obj10.SetActive (false);
					uiIsOpen = false;
				} else if (e.target.name.StartsWith ("confirm10")) {
					
					obj11.SetActive (false);
					uiIsOpen = false;
				}
			}
        }

        private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER OUT", e.target, e.raycastHit, e.distance, e.destinationPosition);

        }

        private void DoPointerHover(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER HOVER", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

        private void DoPointerDestinationSet(object sender, DestinationMarkerEventArgs e)
        {
            DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER DESTINATION", e.target, e.raycastHit, e.distance, e.destinationPosition);
        }

		IEnumerator ToNextScene()
		{
			yield return new  WaitForSeconds (2f);
			panel.SetActive (true);
		}
    }
}