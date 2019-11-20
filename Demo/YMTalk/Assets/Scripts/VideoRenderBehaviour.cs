using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using YouMe;
using System.Collections.Generic;

public class VideoRenderBehaviour : MonoBehaviour {

	public RawImage videoImage;//用于渲染视频图像
    public Button videoButton;//用于控制是否频弊这个人的视频接收
	public Texture2D closeTexture;
	public Texture2D pauseTexture;

    private string bundleUserid;
	private int bundleRenderid;
    private bool videoReciveStoped;

    //绑定基本信息
    public void BundleVideoRenderder(string userid,int renderid){
        bundleUserid = userid;
        bundleRenderid = renderid;
		videoImage.transform.rotation = Quaternion.Euler(180, 0, 0);
		videoButton.gameObject.SetActive(true);
    }

	//给视频画面更新留个通知
	public void OnVideoUpdate(Texture2D texture){
        videoImage.texture = texture;
	}

	public void SwitchVideoRecive(){
		if(videoReciveStoped){
            ResumeVideoRecive();
        }else{
            StopVideoRecive();
        }
	}

	//屏蔽这个人的视频流
	public void StopVideoRecive(){
        videoReciveStoped = true;
        YouMe.YouMeVoiceAPI.GetInstance().MaskVideoByUserId( bundleUserid ,true );
		YouMeTexture.GetInstance().PauseVideoRender(bundleUserid);
        videoImage.texture = pauseTexture;
    }
	//接收这个人的视频流
	public void ResumeVideoRecive(){
        videoReciveStoped = false;
		YouMeTexture.GetInstance().ResumeVideoRender(bundleUserid);
		YouMe.YouMeVoiceAPI.GetInstance().MaskVideoByUserId( bundleUserid ,false );
    }
	//这个视频被动暂停了,可能是对方关闭了摄像头
	public void Paused(){
		Debug.LogError("Paused:"+bundleUserid);
		videoButton.gameObject.SetActive(false);
		YouMeTexture.GetInstance().PauseVideoRender(bundleUserid);
        videoImage.texture = pauseTexture;
    }
	//这个视频被动恢复正常了,可能是对方重新打开摄像头
	public void Resume(){
		Debug.LogError("Resume:"+bundleUserid);
		YouMeTexture.GetInstance().ResumeVideoRender(bundleUserid);
		videoButton.gameObject.SetActive(true);
	}
	//对方视频断开了，下线了、掉线了、3s以上没有收到数据包
	public void Stop(){
		Debug.LogError("Stop:"+bundleUserid);
        YouMeTexture.GetInstance().DeleteRender(bundleUserid);
        videoImage.texture = closeTexture;
        videoButton.gameObject.SetActive(false);
    }
}
