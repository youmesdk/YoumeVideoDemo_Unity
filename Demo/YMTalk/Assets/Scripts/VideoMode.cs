using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using YouMe;
using System.Collections.Generic;
// for test
using System.Runtime.InteropServices;


public class VideoMode : MonoBehaviour {
	//初始化状态标记值
	private volatile bool inited;
	//频道状态标记值
	private volatile YouMe.ChannelState state;
	private volatile string selfUserID;
	private volatile string roomID;
    private float deltaTime;

    public Text versionText;
    public Text fpsText;

    public Text speakerVolumeText;
	public Text buttonChannelText;
	public Toggle micToggle;
	public Toggle speakerToggle;

	public Button joinButton;
	public Button leaveButton;
	public Slider volumeSlider;
	public InputField userInput;
	public InputField roomInput;

    public Button cameraControlButton;
    public Texture2D closeTexture;
	public Texture2D pauseTexture;

    public List<System.Action> callbackList = new List<System.Action>();

    public RawImage selfVideoImage;
    public VideoRenderBehaviour[] videoRenderObjs;
    private Dictionary<int,string> usedPositions; //UI显示位置占坑记录
    private bool cameraIsOn = true;

    private Dictionary<string, int> userIds = new Dictionary<string, int>();

    private List<string> preChatRoomMembers = new List<string>();

    // Use this for initialization
    void Start () {
		//初设两个状态值
		inited = false;
		state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;
		selfUserID = null;
		roomID = null;

        usedPositions = new Dictionary<int,string>(10);

        //自行封装的未初始化成功时的ui展现
        NotInitedUI ();
		SetID ();

		userIds.Clear ();
        preChatRoomMembers.Clear();

        //注册回调
        YouMe.YouMeVoiceAPI.GetInstance ().SetCallback (gameObject.name);

        // ====================================================================================
        // ===================================== 初始化 =========================================

        //初始化，填入从游密申请到的AppKey和AppSecret（可在游密官网https://console.youme.im/user/register注册账号或者直接联系我方商务获取）
        //YouMe.YouMeVoiceAPI.GetInstance ().Init (您获取的AppKey, 您获取的AppSecret);
		Debug.Log("call init");
        var errorCode = YouMe.YouMeVoiceAPI.GetInstance ().Init ("YOUME5BE427937AF216E88E0F84C0EF148BD29B691556",
			"y1sepDnrmgatu/G8rx1nIKglCclvuA5tAvC0vXwlfZKOvPZfaUYOTkfAdUUtbziW8Z4HrsgpJtmV/RqhacllbXD3abvuXIBlrknqP+Bith9OHazsC1X96b3Inii6J7Und0/KaGf3xEzWx/t1E1SbdrbmBJ01D1mwn50O/9V0820BAAE=",
			YouMe.YOUME_RTC_SERVER_REGION.RTC_CN_SERVER, "");
		//如果直接返回值不是成功，则不会进入回调，可按初始化失败时的方法处理
		if (errorCode != YouMe.YouMeErrorCode.YOUME_SUCCESS) {
			// TODO
			Debug.Log("init error:"+errorCode);
		}

        // ===================================== end初始化 =====================================
        // ====================================================================================
        ShowVersion();
    }

    // Update is called once per frame
    void Update () {
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        ShowFPS();
        //在主线程处理回调
        if(callbackList.Count>0){
			var call = callbackList [0];
			callbackList.RemoveAt (0);
			call ();
		}
    }

	/// <summary>
	/// 进入聊天频道
	/// </summary>
	public void OnClickButtonJoin(){
        //只有状态为leaved时才能直接加入频道
        if ( YouMe.ChannelState.CHANNEL_STATE_LEAVED == state) {
            # if UNITY_ANDROID
                        //安卓处理的接口
                        var errorCode1 = YouMe.YouMeVoiceAPI.GetInstance().SetVideoFrameRawCbEnabled(true);
                        Debug.Log("Android  Status:" + errorCode1);
            #endif
            //获取userID和roomID
            GetID ();

            //======================设置分辨率=========================
            YouMe.YouMeVoiceAPI.GetInstance().SetVideoLocalResolution(240, 320);
            YouMe.YouMeVoiceAPI.GetInstance().SetMixVideoSize(240, 320);
            YouMe.YouMeVoiceAPI.GetInstance().AddMixOverlayVideo(selfUserID, 0, 0, 0, 240, 320);
            YouMe.YouMeVoiceAPI.GetInstance().SetVideoNetResolution(240, 320);
            //======================调用加入频道接口=========================
            var errorCode = YouMe.YouMeVoiceAPI.GetInstance().JoinChannelSingleMode(selfUserID,roomID,YouMe.YouMeUserRole.YOUME_USER_TALKER_FREE);

			if (YouMe.YouMeErrorCode.YOUME_SUCCESS == errorCode) {
				//只有直接返回值为成功才会进回调
				state = YouMe.ChannelState.CHANNEL_STATE_JOINING;
			}
			//======================调用加入频道接口=========================
			userIds.Clear();
			Debug.Log ("User host " + selfUserID + " join");
			userIds.Add (selfUserID, 1);
			
			//=========================创建视频流=============================
			selfVideoImage.transform.rotation = Quaternion.Euler(180, 0, 0);//竖屏显示需要旋转下
			int videoRenderid = YouMeTexture.GetInstance ().CreateTexture (selfUserID);
			//更新视频，默认15帧每秒
            YouMeTexture.GetInstance().SetVideoRenderUpdateCallback(videoRenderid,(videoTexture)=>{
                UpdateVideoRender(videoTexture);
            });
			//=========================创建视频流=============================

			//显示自己的视频开关
            cameraControlButton.gameObject.SetActive(true);

        } else {
			//其它状态值都直接返回
			return;
		}
	}

	/// <summary>
	/// 其他用户的视频流过来
	/// </summary>
	/// <param name="userId"></param>
	public void UserJoin ( string userId)
	{
		if (userIds.ContainsKey (userId)) 
		{
			Debug.Log ("User " + userId + " already exist!");
			return;
		}
		userIds.Add (userId, 1);

        Debug.Log("Bing User " + userId + " video render!");
        BindRecivedUserVideo(userId);

    }
    /// <summary>
    /// 绑定对应用户的视频流
    /// </summary>
    /// <param name="userId"></param>
	public void BindRecivedUserVideo(string userId){
		//Texture2D myVedioTexture;
		//创建视频流
		int renderid = YouMeTexture.GetInstance ().CreateTexture (userId);
		//获取显示对象
		var renderObj = GetBundleVideoRender(userId);
        if (renderObj != null)
        {
            //设置显示对象需要的基本信息
            renderObj.BundleVideoRenderder(userId, renderid);
            //视频刷新事件绑定，目前约15帧每秒
            YouMeTexture.GetInstance().SetVideoRenderUpdateCallback(renderid, renderObj.OnVideoUpdate);
        }
	}

	/// <summary>
	/// 离开聊天频道
	/// </summary>
	public void OnClickButtonLeave(){
		//joining和joined的状态可以直接调用离开
		if ( YouMe.ChannelState.CHANNEL_STATE_JOINING == state || YouMe.ChannelState.CHANNEL_STATE_JOINED == state) {
			//调用加入频道接口
			var errorCode = YouMe.YouMeVoiceAPI.GetInstance().LeaveChannelAll();

			// 清除资源
			YouMe.YouMeVoiceAPI.GetInstance().StopCapture();
			YouMeTexture.GetInstance().PauseVideoRender(selfUserID);
			YouMe.YouMeTexture.GetInstance().DeleteAllTexture();

			ResetVideoRender ();
			userIds.Clear ();
            preChatRoomMembers.Clear();
			ShowSelfClose();
			cameraControlButton.gameObject.SetActive(false);

        } else {
			//其它状态值都直接返回
			return;
		}
	}

	//回调通知
	void OnEvent (string strParam){
		callbackList.Add (() => {
            ParseEventOnMainThread(strParam);
        });
	}

	//回调函数
	void ParseEventOnMainThread (string strParam)
	{
        Debug.LogError("strParam:"+strParam);
        string[] strSections = strParam.Split (new char[] { ',' },4);
		if (strSections == null){

			return;
		}
		//解析后得到四个字段，第一个为事件类型，第二个为错误码类型，第三个一版是频道id，第四个是userid
		YouMe.YouMeEvent eventType = (YouMeEvent)int.Parse (strSections [0]);
		YouMe.YouMeErrorCode errorCode = (YouMeErrorCode)int.Parse (strSections [1]);
		string channelID =  strSections [2];
		string param =  strSections [3];


		switch (eventType) {
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_OK://初始化成功
			inited = true;
			InitedUI ();
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_INIT_FAILED://初始化失败，一般都是网络原因

			break;
		case YouMe.YouMeEvent.YOUME_EVENT_JOIN_OK://进入聊天频道成功
			//如果已调用了离开接口，则无须再等此类回调
			if (YouMe.ChannelState.CHANNEL_STATE_LEAVING_ALL == state) {
				return;
			}

			ReSet();
			JoinedUI ();
			state = YouMe.ChannelState.CHANNEL_STATE_JOINED;
			//打开VAD通知
			YouMe.YouMeVoiceAPI.GetInstance().SetVadCallbackEnabled(true);
			//开启摄像头
			YouMe.YouMeVoiceAPI.GetInstance().StartCapture();
			//接收成员变化通知
			YouMe.YouMeVoiceAPI.GetInstance().GetChannelUserList(channelID, 100, true);
            break;
		case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ONE:
                break;
		case YouMe.YouMeEvent.YOUME_EVENT_LEAVED_ALL: //退出所有频道成功
			LeavedUI ();
			state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;

			break;
		case YouMe.YouMeEvent.YOUME_EVENT_JOIN_FAILED: //进入聊天频道失败
			//进入语音频道失败
			LeavedUI ();
			state = YouMe.ChannelState.CHANNEL_STATE_LEAVED;

			break;
		case YouMe.YouMeEvent.YOUME_EVENT_REC_PERMISSION_STATUS:
			// TODO 通知录音权限状态，成功获取权限时错误码为YOUME_SUCCESS，获取失败为YOUME_ERROR_REC_NO_PERMISSION（此时不管麦克风mute状态如何，都没有声音输出）

			break;
		case YouMe.YouMeEvent.YOUME_EVENT_RECONNECTING:
			// TODO 重连中,可以做个提示，不用处理什么特别的逻辑
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_RECONNECTED:
			// TODO 重连成功，可以做个提示
			break;

		case  YouMe.YouMeEvent.YOUME_EVENT_OTHERS_MIC_OFF:
			//其他用户的麦克风关闭：
			//Send Event callback, event(18):OTHERS_SPEAKER_ON, errCode:0, room:, param:3026935
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_MIC_ON:
			//其他用户的麦克风打开：
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_SPEAKER_ON:
			//其他用户的扬声器打开：
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_SPEAKER_OFF:
			//其他用户的扬声器关闭
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VOICE_ON:
			//其他用户开始讲话
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VOICE_OFF:
			//其他用户开始讲话
			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VIDEO_ON: //收到其他用户的视频流通知
			/* 收到其它用户的视频流 */
			UserJoin(param);

			break;
		case YouMe.YouMeEvent.YOUME_EVENT_OTHERS_VIDEO_SHUT_DOWN://视频断开事件
			{
				// 这个事件在暂停后、临时断网也会通知，不适合做用户下线通知
                // RemoveUserVideoRender(param);
			}
			break;
		default:
			break;
		}

	}
	
	void OnMemberChange (string strParam){
		//{"channelid":"2418video","memchange":[{"isJoin":true,"userid":"1001590"}],"type":2}
        Debug.LogError("memChange:" + strParam);
		JsonData jsonMessage =  JsonMapper.ToObject (strParam);
        JsonData memberList = jsonMessage["memchange"];
        for (int i = 0; i < memberList.Count;i++){
            JsonData item = memberList[i];
			if( !(bool)item["isJoin"] ){
				RemoveUserVideoRender((string)item["userid"]);
			}
        }
    }


	public void onMicToggle() {
		if (micToggle.isOn) {
			//打开麦克风
			YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute (false);

		} else {
			//关闭麦克风
			YouMe.YouMeVoiceAPI.GetInstance().SetMicrophoneMute (true);

		}

		bool result = YouMe.YouMeVoiceAPI.GetInstance().GetMicrophoneMute();
	}

	public void onSpeakerToggle() {
		if (speakerToggle.isOn) {
			//打开扬声器
			YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute (false);
		} else {
			//关闭扬声器
			YouMe.YouMeVoiceAPI.GetInstance().SetSpeakerMute (true);
		}
		bool result = YouMe.YouMeVoiceAPI.GetInstance().GetSpeakerMute();
	}

	public void OnSpeakerVolumeChanged()
	{
		speakerVolumeText.text =  volumeSlider.value.ToString();
		YouMe.YouMeVoiceAPI.GetInstance().SetVolume ((uint)volumeSlider.value);
		var currentVolume = YouMe.YouMeVoiceAPI.GetInstance().GetVolume();
	}


	//初始化成功后的ui变化，以保障初始化成功才能进行加入频道的操作
	private void InitedUI(){
		joinButton.interactable = true;
		leaveButton.interactable = true;
	}

	private void NotInitedUI(){
		LeavedUI ();
		joinButton.interactable = false;
		leaveButton.interactable = false;
	}

	private void JoinedUI(){
		joinButton.interactable = false;
        joinButton.gameObject.SetActive(false);
        leaveButton.gameObject.SetActive(true);

        micToggle.gameObject.SetActive(true);
		speakerToggle.gameObject.SetActive (true);
		volumeSlider.gameObject.SetActive (true);
		speakerVolumeText.gameObject.SetActive (true);

		micToggle.isOn = false;
		speakerToggle.isOn = true;
		volumeSlider.value = 100;
		speakerVolumeText.text = "100";
	}

	private void LeavedUI(){
        leaveButton.gameObject.SetActive(false);
		joinButton.gameObject.SetActive(true);
        joinButton.interactable = true;
		micToggle.gameObject.SetActive(false);
		speakerToggle.gameObject.SetActive (false);
		volumeSlider.gameObject.SetActive (false);
		speakerVolumeText.gameObject.SetActive (false);
	}

	//每次重进频道，将所有相关状态重设
	private void ReSet()
	{
		YouMe.YouMeVoiceAPI.GetInstance ().SetMicrophoneMute (true);

		YouMe.YouMeVoiceAPI.GetInstance ().SetSpeakerMute (false);

		YouMe.YouMeVoiceAPI.GetInstance ().SetVolume (100);
	}

	private void SetID(){
		roomID = "2418video";
		int random;
		random = 1000000 + Random.Range (1, 10000);
		selfUserID = random.ToString ();
		roomInput.text = roomID;
		userInput.text = selfUserID;

	}

	/// <summary>
	/// 退出应用
	/// </summary>
	public void OnClickButtonReturn(){
		/* 释放资源 */
		YouMe.YouMeVoiceAPI.GetInstance().StopCapture();
		YouMe.YouMeTexture.GetInstance().DeleteAllTexture();
		ResetVideoRender ();
		userIds.Clear ();

		/* 反初始化退出到登陆界面 */
		YouMe.YouMeVoiceAPI.GetInstance().UnInit();
		Application.Quit();
	}

	private void GetID(){
		selfUserID = userInput.text;
		roomID = roomInput.text;
	}

	public void RemoveUserVideoRender(string userid){
        YouMe.YouMeTexture.GetInstance().DeleteRender(userid);
        userIds.Remove(userid);
        if (usedPositions.ContainsValue(userid)){
			int k = -1;
			foreach(var kv in usedPositions){
				if(kv.Value == userid){
                    videoRenderObjs[kv.Key].Stop();
                    k = kv.Key;
                    break;
                }
			}
			if(k>-1){
                usedPositions.Remove(k);
            }
		}
	}

    public void PuaseUserVideoRender(string userid) {
		if(userid== selfUserID){
			//这儿不处理自己的摄像头开关事件
            return;
        }
		if(usedPositions.ContainsValue(userid)){
			foreach(var kv in usedPositions){
				if(kv.Value == userid){
                    videoRenderObjs[kv.Key].Paused();
                    break;
                }
			}
		}
    }

	public void ResumeUserVideoRender(string userid) {
		if(userid== selfUserID){
			//这儿不处理自己的摄像头开关事件
            return;
        }
		if(usedPositions.ContainsValue(userid)){
			foreach(var kv in usedPositions){
				if(kv.Value == userid){
                    videoRenderObjs[kv.Key].Resume();
                    break;
                }
			}
		}else{
            BindRecivedUserVideo(userid);
        }
    }

    public void ResetVideoRender()  {
		foreach(var i in usedPositions){
            videoRenderObjs[i.Key].Stop();
        }
        usedPositions.Clear();
    }

	public VideoRenderBehaviour GetBundleVideoRender(string userid){
        int pos = -1;
        for (int i = 0; i < videoRenderObjs.Length;i++){
			if(!usedPositions.ContainsKey(i) ){
                pos = i;
                usedPositions.Add(pos,userid);
                break;
            }
		}
		if(pos==-1){
            Debug.LogError("没有空余的位置显示："+userid+" 的视频了。");
            return null;
        }
        return videoRenderObjs[pos];
    }

	public void UpdateVideoRender(Texture2D texture2d){
        selfVideoImage.texture = texture2d;
    }

	public void ControlCamera(){
		if(cameraIsOn){
            var code = YouMe.YouMeVoiceAPI.GetInstance().StopCapture();
            if(code == YouMeErrorCode.YOUME_SUCCESS){
				cameraIsOn = false;
                cameraControlButton.transform.Find("Text").GetComponent<Text>().text = "开";
				YouMeTexture.GetInstance().PauseVideoRender(selfUserID);
            	ShowSelfClose();
            }
        }else{
            var code = YouMe.YouMeVoiceAPI.GetInstance().StartCapture();
            if(code == YouMeErrorCode.YOUME_SUCCESS){
				cameraIsOn = true;
                cameraControlButton.transform.Find("Text").GetComponent<Text>().text = "关";
				YouMeTexture.GetInstance().ResumeVideoRender(selfUserID);
            }
        }
	}

	void ShowSelfClose(){
		selfVideoImage.texture = closeTexture;
	}

	void ShowVersion(){
        uint v = (uint)YouMe.YouMeVoiceAPI.GetInstance().GetSDKVersion();
        uint a = ((uint)v & (uint)4026531840) >> 28;
		uint b = ((uint)v & (uint)254803967) >> 22;
		uint c = ((uint)v & (uint)2097151) >> 14;
		uint d = ((uint)v & (uint)16383) ;
        versionText.text = a+"."+b+"."+c+"."+d;
    }

	void ShowFPS(){
		int w = Screen.width, h = Screen.height;


        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = fps.ToString("#.#")+" fps";
        fpsText.text = text;
    }

	void OnApplicationPause(bool isPause){
		if (isPause) {
			YouMe.YouMeVoiceAPI.GetInstance().PauseChannel();
		}
		else {
			YouMe.YouMeVoiceAPI.GetInstance().ResumeChannel();
		}
			
	}

	void OnApplicationQuit(){
		YouMe.YouMeVoiceAPI.GetInstance().UnInit();
	}

}
