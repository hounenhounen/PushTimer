using UnityEngine;
using System.Collections;
using System;
using NCMB;

public class ReceiveTest : MonoBehaviour {
	private static bool _isInitialized = false;

	/// <summary>
	///イベントリスナーの登録
	/// </summary>
	void OnEnable()
	{
		NCMBManager.onRegistration += OnRegistration;
		NCMBManager.onNotificationReceived += OnNotificationReceived;
	}

	/// <summary>
	///イベントリスナーの削除
	/// </summary>
	void OnDisable ()
	{
		NCMBManager.onRegistration -= OnRegistration;
		NCMBManager.onNotificationReceived -= OnNotificationReceived;
	}

	/// <summary>
	///端末登録後のイベント
	/// </summary>
	void OnRegistration (string errorMessage)
	{
		if (errorMessage == null) {
			Debug.Log ("OnRegistrationSucceeded");
		} else {
			Debug.Log ("OnRegistrationFailed:" + errorMessage);
		}
	}

	/// <summary>
	///メッセージ受信後のイベント
	/// </summary>
	void OnNotificationReceived(NCMBPushPayload payload)
	{
		
		// クラスのNCMBObjectを作成
		NCMBObject PushTime = new NCMBObject("PushTime");
		// オブジェクトに値を設定
		PushTime["SendTime"] = SendPush.SendTime;
		System.DateTime ReceiveTime = System.DateTime.UtcNow;
		PushTime["ReceiveTime"] = ReceiveTime;
		TimeSpan ts = ReceiveTime - SendPush.SendTime;
		PushTime ["DeliveryTime"] = ts.TotalSeconds;
		// データストアへの登録
		PushTime.SaveAsync();
		Debug.Log("OnNotificationReceived");
	}

	/// <summary>
	///シーンを跨いでGameObjectを利用する設定
	/// </summary>
	public virtual void Awake ()
	{
		if (!_isInitialized) {
			_isInitialized = true;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
