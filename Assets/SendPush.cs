using UnityEngine;
using System.Collections;
using NCMB;
public class SendPush : MonoBehaviour {
	public static System.DateTime SendTime;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PushSend(){
		NCMBPush PushSend = new NCMBPush ();
		PushSend.Add ("title","TestTest");
		PushSend.Add ("message","clientTest");
		PushSend.PushToAndroid = true;
		PushSend.SendPush ((NCMBException e) => { 
				if (e != null) {
					UnityEngine.Debug.Log ("失敗: " + e.ErrorMessage);
				} else {
					SendTime = System.DateTime.UtcNow;
					UnityEngine.Debug.Log ("成功" + SendTime);
				}
			}
		);

	}
}
