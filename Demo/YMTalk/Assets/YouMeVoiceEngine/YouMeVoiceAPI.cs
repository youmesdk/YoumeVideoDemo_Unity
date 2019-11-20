using UnityEngine;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System;

#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
using AOT;
#endif

namespace YouMe{

    public struct I420Frame
    {
        public int  renderId;
        public int  width;
        public int  height;
        public int  degree;
        public int  len;

        public byte[] data;

		public I420Frame (int length) {
            renderId = 0;
			width = 0;
			height = 0;
			degree = 0;
			len = length;
			data = new byte[length];
        }
    }

	public class YouMeVoiceAPI
	{
	    //////////////////////////////////////////////////////////////////////////////////////////////
		// 导出SDK所有的C接口API
	    //////////////////////////////////////////////////////////////////////////////////////////////
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setExternalInputMode(bool bInputModeEnabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_init(string strAPPKey, string strAPPSecret, int serverRegionId, string strExtServerRegionName);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_unInit();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern System.IntPtr youme_getCbMessage ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_freeCbMessage (System.IntPtr pMsg);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setOutputToSpeaker (bool bOutputToSpeaker);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setSpeakerMute (bool bOn);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getSpeakerMute ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getMicrophoneMute ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setMicrophoneMute (bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern void youme_setAutoSendStatus (bool bAutoSend);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_getVolume ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setVolume (uint uiVolume);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern bool youme_getUseMobileNetworkEnabled ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setUseMobileNetworkEnabled (bool bEnabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_joinChannelSingleMode (string strUserID, string strChannelID, int userRole,bool autoRecvVideo);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_joinChannelMultiMode (string strUserID, string strChannelID, int userRole );

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_speakToChannel(string strChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_leaveChannelMultiMode(string strChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_leaveChannelAll();

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setOtherMicMute (string userID, bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setOtherSpeakerMute (string userID, bool mute);

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int youme_setListenOtherVoice (string userID, bool isOn);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setServerRegion (int regionId, string strExtRegionId, bool bAppend);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_playBackgroundMusic (string pFilePath, bool bRepeat);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_pauseBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_resumeBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_stopBackgroundMusic ();

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setBackgroundMusicVolume (int volume);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
	    private static extern int youme_setHeadsetMonitorOn(bool micEnabled, bool bgmEnabled);
	    
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setReverbEnabled(bool enabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setVadCallbackEnabled(bool enabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setMicLevelCallback(int maxLevel);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_pauseChannel();
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_resumeChannel();
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setRecordingTimeMs(uint timeMs);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
                [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setMixVideoSize(int width, int height);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_addMixOverlayVideo(string userId, int x, int y, int z, int width, int height);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setPlayingTimeMs(uint timeMs);
        
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_getSDKVersion();

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_requestRestApi( string strCommand , string  strQueryBody, ref int  requestID );
		
		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_getChannelUserList( string strChannelID , int maxCount ,  bool  notifyMemChange );

		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_setToken( string strToken );
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern int youme_setUserLogPath (string pFilePath);
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setReleaseMicWhenMute(bool enabled);
		
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
    	private static extern int youme_setExitCommModeWhenHeadsetPlugin(bool enabled);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_startGrabMicAction(string pChannelID, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopGrabMicAction(string pChannelID, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_releaseGrabMic(string pChannelID);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_requestInviteMic(string pChannelID, string pUserID, string pContent);


        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_responseInviteMic(string pUserID, bool isAccept, string pContent);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopInviteMic();
		
		#if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		[DllImport("__Internal")]
		#else
		[DllImport("youme_voice_engine")]
		#endif
		private static extern int  youme_sendMessage( string pChannelID , string  pContent, ref int  requestID );

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
        [DllImport("__Internal")]
        #else
        [DllImport("youme_voice_engine")]
        #endif
        private static extern int  youme_kickOtherFromChannel( string pUserID , string pChannelID , int lastTime );

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
        [DllImport("__Internal")]
        #else
        [DllImport("youme_voice_engine")]
        #endif
        private static extern void  youme_setLogLevel(  int consoleLevel, int fileLevel );

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
        [DllImport("__Internal")]
        #else
        [DllImport("youme_voice_engine")]
        #endif
        private static extern int  youme_setExternalInputSampleRate(  int sampleRate, int mixedCallbackSampleRate );

        // 设置是否开启视频编码器
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_openVideoEncoder(string pFilePath);
    
        // 创建渲染ID
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_createRender(string userId);
    
        // 设置视频回调
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setVideoCallback(string strObjName);
    
        // 开始camera capture
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_startCapture();
    
        // 停止camera capture
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopCapture();
    
        // 设置camera capture property
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setVideoLocalResolution(int width, int height);
    
        // 设置是否前置摄像头
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setCaptureFrontCameraEnable(bool enable);
        
        
        // 获取视频数据
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		public static extern System.IntPtr youme_getVideoFrame(string userid, ref int len, ref int width, ref int height);

        // 设置屏蔽某人视频
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_maskVideoByUserId(string userId, bool mask);

        // 删除渲染ID
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_deleteRender(int renderId);
		
		// 是否是测试模式,测试模式使用测试服
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setTestConfig(int bTest);
		
		// 获取是否开启变声
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool youme_getSoundtouchEnabled();
		
		// 设置是否开启变声
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setSoundtouchEnabled(bool bEnable);
		
		// 获取变速，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern float youme_getSoundtouchTempo();
		
		// 设置变速，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setSoundtouchTempo(float nTempo);
		
		// 获取节拍，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern float youme_getSoundtouchRate();
		
		// 设置节拍，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setSoundtouchRate(float nRate);
		
		// 获取变调，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern float youme_getSoundtouchPitch();
		
		// 设置变调，1为正常值
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setSoundtouchPitch(float nPitch);
		
		//(七牛接口)将提供的音频数据混合到麦克风或者扬声器的音轨里面。void*暂改为byte[]
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern YouMeErrorCode youme_inputAudioFrame(byte[] data, int len, ulong timestamp);
		
		//(七牛接口)将提供的视频数据到producer。void*暂改为byte[]
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern YouMeErrorCode youme_inputVideoFrame(byte[] data, int len, int width, int height, int fmt, int rotation, int mirror, ulong timestamp);
		
		// 设置是否启动远端语音音量回调
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setFarendVoiceLevelCallback(int maxLevel);
		
		// 
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setServerMode(int mode);
		
		// 进入房间后，切换身份
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int  youme_setUserRole(int userRole);
		
		// 获取身份
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern YouMeUserRole youme_getUserRole();
		
		// 背景音乐是否在播放
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool  youme_isBackgroundMusicPlaying();
		
		// 是否初始化成功
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool  youme_isInited();
		
		// 是否在某个语音房间内
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool  youme_isInChannel(string pChannelID);
		
		// 切换前后摄像头
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_switchCamera();
		
		// 视频数据输入(七牛接口，房间内其它用户会收到YOUME_EVENT_OTHERS_VIDEO_INPUT_START事件)void*暂改为byte[]
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_inputPixelBuffer(byte[] data, int width, int height, int fmt, int rotation, int mirror, ulong timestamp);
		
		// 停止视频数据输入(七牛接口，在youme_inputVideoFrame之后调用，房间内其它用户会收到YOUME_EVENT_OTHERS_VIDEO_INPUT_STOP事件)
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_stopInputVideoFrame();
		
		// 权限检测结束后重置摄像头
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_resetCamera();
		
		// 设置视频网络传输过程的分辨率,高分辨率
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int  youme_setVideoNetResolution( int width, int height );
		
		// 设置音视频统计数据时间间隔
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setAVStatisticInterval( int interval  );
		
		// 设置Audio的传输质量
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern void youme_setAudioQuality( int quality );
		
		// 设置视频数据上行的码率的上下限。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setVideoCodeBitrate( uint maxBitrate,  uint minBitrate );
		
	    // 获取视频数据上行的当前码率。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern uint youme_getCurrentVideoCodeBitrate( );
		
		// 设置视频数据是否同意开启硬编硬解
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setVideoHardwareCodeEnable( bool bEnable );
		
		// 获取视频数据是否同意开启硬编硬解
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool youme_getVideoHardwareCodeEnable( );
		
		// 设置视频无帧渲染的等待超时时间，超过这个时间会给上层回调
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern void youme_setVideoNoFrameTimeout(int timeout);
		
		// 查询多个用户视频信息（支持分辨率）
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_queryUsersVideoInfo( string userList);
		
		// 设置多个用户视频信息（支持分辨率）
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern int youme_setUsersVideoInfo( string videoinfoList );
        		
		// 调用后同步完成麦克风释放，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool youme_releaseMicSync();
		
		// 调用后恢复麦克风到释放前的状态，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern bool youme_resumeMicSync();
		
		// 美颜开关，默认是关闭美颜。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern YouMeErrorCode youme_openBeautify(bool open);
		
		// 美颜强度参数设置。
        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
        private static extern YouMeErrorCode youme_beautifyChanged(float param);

        #if UNITY_IOS && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            [DllImport("__Internal")]
        #else
            [DllImport("youme_voice_engine")]
        #endif
		private static extern YouMeErrorCode youme_setVideoFrameRawCbEnabled(bool enable);
		

        //////////////////////////////////////////////////////////////////////////////////////////////
        // 导出SDK所有的C接口API -- end
        //////////////////////////////////////////////////////////////////////////////////////////////


        //
        // 回调消息类型定义， 需要跟底层匹配
        //
        private enum CallbackType
        {
            CALLBACK_TYPE_EVENT = 0,
            CALLBACK_TYPE_REST_API_RESPONSE, 
            CALLBACK_TYPE_MEMBER_CHANGE,
            CALLBACK_TYPE_BROADCAST
        }

        //
        // 回调处理
        // 主动调用底层函数查询当前是否有回调消息，如果有的话，做Json解析并传给上层
        //
        private class YoumeCallbackObject : MonoBehaviour {

            void Start() {
                InvokeRepeating("YoumeCallback", 0.5f, 0.05f);
            }

            void YoumeCallback ()
            {				
                System.IntPtr pMsg = YouMeVoiceAPI.youme_getCbMessage();
                if (pMsg == System.IntPtr.Zero) {
                    return;
                }
                string strMessage = Marshal.PtrToStringAuto(pMsg);
                //Debug.Log("recv message:" + strMessage);
                if(null != strMessage)
                {
                    try {
                        YouMeVoiceAPI.GetInstance().ParseJsonCallbackMessage(strMessage);
                    } catch (System.Exception e) {
                        Debug.LogError(e.StackTrace);
                    }
                }

                YouMeVoiceAPI.youme_freeCbMessage(pMsg);
                pMsg = System.IntPtr.Zero;
            }

        }

        //
        // 解析回调消息的Json字符串
        //
        private void ParseJsonCallbackMessage(string strMessage)
        {
            string strMethodName = null;
            string strCbMessage = null;

            JsonData jsonMessage =  JsonMapper.ToObject (strMessage);
            YouMeVoiceAPI.CallbackType cbType = (YouMeVoiceAPI.CallbackType)(int)jsonMessage ["type"];
            //Debug.Log ("###### callback message type:" + msgType);
            switch (cbType) {
                case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_EVENT:
                {
                    strMethodName = "OnEvent";
                    int eventType = (int)jsonMessage ["event"];
                    int errCode = (int)jsonMessage ["error"];
                    string channelId = (string)jsonMessage ["channelid"];
                    string param = (string)jsonMessage ["param"];
                    strCbMessage = "" + eventType + "," + errCode + "," + channelId + "," + param;
                    //Debug.Log ("eventType:" + eventType + ",errCode:" + errCode + ", channelId:" + channelId + ",param:" + param );
                }
                break;
                case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_REST_API_RESPONSE:
                {
                    strMethodName = "OnRequestRestApi";
                    strCbMessage = strMessage;
                }
                break;
                case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_MEMBER_CHANGE:
                {
                    strMethodName = "OnMemberChange";
                    strCbMessage = strMessage;
                }
                break;
                case YouMeVoiceAPI.CallbackType.CALLBACK_TYPE_BROADCAST:
                {
                    strMethodName = "OnBroadcast";
                    int bcType = (int)jsonMessage["bc"];
                    string channelId = (string)jsonMessage["channelid"];
                    string param1 = (string)jsonMessage["param1"];
                    string param2 = (string)jsonMessage["param2"];
                    string content = (string)jsonMessage["content"];
                    strCbMessage = "" + bcType + "," + channelId + "," + param1 + "," + param2 + "," + content;
                }
                break;
            }
            
            if ((mCallbackObjName != null) && (strMethodName != null) && (strCbMessage != null)) {
                var gameObject = GameObject.Find(mCallbackObjName);
                if (gameObject != null)
                {
                    gameObject.SendMessage(strMethodName, strCbMessage);
                }
            }
        }

		//成员变量定义
		private static YouMeVoiceAPI mInstance;
		private string mCallbackObjName = null;
 		#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		private  bool mAndroidInited = false;
		private  bool mAndroidInitOK = false;
		private  AndroidJavaClass instance_youme_java;
		#endif

		//单实例对象
		public static YouMeVoiceAPI GetInstance()
		{
			if (mInstance == null)
			{
				mInstance = new YouMeVoiceAPI();
			}
			return mInstance;
		}

		YouMeVoiceAPI()
		{
			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				instance_youme_java = new AndroidJavaClass ("com.youme.voiceengine.api");					
			#endif
		}

        //////////////////////////////////////////////////////////////////////////////////////////////
        // C# 对外接口定义
        //////////////////////////////////////////////////////////////////////////////////////////////

		// 初始化Android Java部分，并load so库，同时启动Android Service
		#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
		private void InitAndroidJava()
		{
			try {
				if (!mAndroidInited) {
					mAndroidInited = true;

					AndroidJavaClass unity = new AndroidJavaClass ("com.unity3d.player.UnityPlayer");
					AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject> ("currentActivity");
					AndroidJavaClass YouMeManager = new AndroidJavaClass ("com.youme.voiceengine.mgr.YouMeManager");
					mAndroidInitOK = YouMeManager.CallStatic<bool> ("Init", currentActivity);
					if (mAndroidInitOK) {
						AndroidJavaClass VoiceEngineService = new AndroidJavaClass ("com.youme.voiceengine.VoiceEngineService");
						AndroidJavaObject intentObject = new AndroidJavaObject ("android.content.Intent", currentActivity, VoiceEngineService);
						currentActivity.Call<AndroidJavaObject> ("startService", intentObject);
					}
				} 
			} catch {
				Debug.Log("android init exception!!!");
			}
		}
		#endif

        /// <summary>
        /// 设置接收回调消息的对象名。这个函数必须最先调用，这样才能收到后面所有调用的回调消息，包括Init(...)函数的回调。
        /// </summary>
        /// <param name="strObjName">用于接收回调消息的对象名</param>
        ///
		public void SetCallback(string strObjName)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif 

			mCallbackObjName = strObjName;
		}

        /// <summary>
        /// 设置是否由外部输入音视频
        /// </summary>
        /// <param name="bInputModeEnabled">true:外部输入模式，false:SDK内部采集模式</param>
        ///
        public void SetExternalInputMode(bool bInputModeEnabled)
        {
            youme_setExternalInputMode (bInputModeEnabled);
        }

        /// <summary>
        /// 初始化语音引擎，做APP验证和资源初始化
        /// 这是一个异步调用接口，如果函数返回 YOUME_SUCCESS， 则需要等待以下事件回调达到才表明初始化完成。只有初始化成功，才能进行。
        /// 其他的操作，如进入/退出频道，开关麦克风等。
        /// YouMeEvent.YOUME_EVENT_INIT_OK - 表明初始化成功
        /// YouMeEvent.YOUME_EVENT_INIT_NOK - 表明初始化失败，最常见的失败原因是网络错误或者 AppKey/AppSecret 错误
        /// </summary>
        /// <param name="strAPPKey">从游密申请到的 app key, 这个你们应用程序的唯一标识</param>
        /// <param name="strAPPKey">对应 strAPPKey 的私钥, 这个需要妥善保存，不要暴露给其他人</param>
        /// <param name="serverRegionId">
        /// 设置首选连接服务器的区域码
        /// 如果在初始化时不能确定区域，可以填RTC_DEFAULT_SERVER，后面确定时通过 SetServerRegion 设置。
        /// 如果YOUME_RTC_SERVER_REGION定义的区域码不能满足要求，可以把这个参数设为 RTC_EXT_SERVER，然后
        /// 通过后面的参数 strExtServerRegionName 设置一个自定的区域值（如中国用 "cn" 或者 “ch"表示），然后把这个自定义的区域值同步给游密。
        /// 我们将通过后台配置映射到最佳区域的服务器。
        /// </param>
        /// <param name="strExtServerRegionName">扩展的服务器区域
        /// </param>
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode Init(string strAppKey,string strAPPSecret, 
									YOUME_RTC_SERVER_REGION serverRegionId, string strExtServerRegionName)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif 

			GameObject callbackObj = new GameObject ("youme_update_once");
			GameObject.DontDestroyOnLoad (callbackObj);
			callbackObj.hideFlags = HideFlags.HideInHierarchy;
			callbackObj.AddComponent <YoumeCallbackObject>();

			return (YouMeErrorCode)youme_init (strAppKey, strAPPSecret, (int)serverRegionId, strExtServerRegionName);
		}

        /// <summary>
        /// 功能描述:反初始化引擎，在应用退出之前需要调用这个接口释放资源
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode UnInit ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_unInit();
		}

        /// <summary>
        /// 设置服务器区域，默认是中国
        /// </summary>
        ///
        /// <param name="regionId">
        /// 设置首选连接服务器的区域码
        /// 如果YOUME_RTC_SERVER_REGION定义的区域码不能满足要求，可以把这个参数设为 RTC_EXT_SERVER，然后
        /// 通过下面的参数 strExtRegionName 设置一个自定的区域值，然后把这个自定义的区域值同步给游密。
        /// 我们将通过后台配置映射到最佳区域的服务器。
        /// </param>
        /// <param name="strExtRegionName">扩展的服务器区域
        /// </param>
        ///
        public void SetServerRegion(YOUME_RTC_SERVER_REGION regionId, string strExtRegionName, bool bAppend){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif 

			youme_setServerRegion((int)regionId, strExtRegionName, false);
        }

        /// <summary>
        /// 设置参与通话各方所在的区域
        /// 这个接口适合于分布区域比较广的应用。最简单的做法是只设定前用户所在区域。但如果能确定其他参与通话的应用所在的区域，则能使服务器选择更优。
        /// </summary>
        ///
        /// <param name="regionNames">
        /// 	指定参与通话各方区域的数组，数组里每个元素为一个区域代码。用户可以自行定义代表各区域的字符串（如中国用 "cn" 或者 “ch"表示），
        ///     然后把定义好的区域表同步给游密，游密会把这些定义配置到后台，在实际运营时选择最优服务器。
        /// </param>
        ///
        public void SetServerRegion(string[] regionNames){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				InitAndroidJava();
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			if ((regionNames != null) && (regionNames.Length > 0)) {
				youme_setServerRegion ((int)YouMe.YOUME_RTC_SERVER_REGION.RTC_EXT_SERVER, regionNames[0], false);
			}
			for (int i = 1; i < regionNames.Length; i++) {
				youme_setServerRegion ((int)YouMe.YOUME_RTC_SERVER_REGION.RTC_EXT_SERVER, regionNames[i], true);
	        }
        }

        /// <summary>
        /// 切换语音输出设备
        /// 默认输出到扬声器，在加入房间成功后设置（iOS受系统限制，如果已释放麦克风则无法切换到听筒）
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bOutputToSpeaker">true为扬声器，false为听筒</param>
        ///
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode SetOutputToSpeaker (bool bOutputToSpeaker)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_setOutputToSpeaker (bOutputToSpeaker);
		}

        /// <summary>
        /// 设置扬声器是否静音
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bMute">true为麦克风静音，false为打开扬声器</param>
        ///
		public void SetSpeakerMute (bool bMute)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSpeakerMute (bMute);
		}
			
        /// <summary>
        /// 获取扬声器的静音状态
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true 扬声器当前处于静音状态，false 扬声器当前处于打开状态， 默认情况下扬声器是打开的</returns>
        ///
		public bool GetSpeakerMute ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

				return youme_getSpeakerMute ();
		}


        /// <summary>
        /// 设置麦克风是否静音
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bMute">true为麦克风静音，false为打开麦克风，默认情况下麦克风是关闭的</param>
        ///
        public void SetMicrophoneMute (bool mute)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setMicrophoneMute (mute);
        }


        /// <summary>
        /// 获取麦克风的静音状态
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true 麦克风当前处于静音状态，false 麦克风当前处于打开状态</returns>
        ///
		public bool GetMicrophoneMute ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return false;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getMicrophoneMute ();
		}

		/// <summary>
		/// 设置是否通知其他人，自己开关麦克风扬声器的状态
		/// </summary>
		///
		/// <param name="bAutoSend">true通知，false不通知
		///
		public void SetAutoSendStatus (bool bAutoSend)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return;
			}
			#endif

			youme_setAutoSendStatus (bAutoSend);
		}

        /// <summary>
        /// 设置通话音量
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="uiVolume"> 取值范围是[0-100] 100表示最大音量， 默认音量是100</param>
        ///
        public void SetVolume (uint uiVolume)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setVolume (uiVolume);
        }

        /// <summary>
        /// 获取音量大小,此音量值为程序内部的音量，与系统音量相乘得到程序使用的实际音量
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>当前音量值，范围 [0-100]</returns>
        ///
		public int GetVolume ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

				return youme_getVolume ();
		}


        /// <summary>
        /// 设置是否允许使用移动网络(2G/3G/4G)进行通话。如果当前已经进入了语音频道，这个设置是不生效的，它只对下次通话有效。
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <param name="bEnabled"> true-移动网络下允许通话，false-移动网络下不允许通话，默认允许 </param>
        ///
        public void SetUseMobileNetworkEnabled (bool bEnabled)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

                youme_setUseMobileNetworkEnabled (bEnabled);
        }

        /// <summary>
        /// 获取当前是否允许使用移动网络(2G/3G/4G)进行通话
        /// 这是一个同步调用接口，函数返回时表明操作已经完成
        /// </summary>
        ///
        /// <returns>true-移动网络下允许通话，false-移动网络下不允许通话</returns>
        ///
		public bool GetUseMobileNetworkEnabled ()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

				return youme_getUseMobileNetworkEnabled ();
		}


        /// <summary>
        /// 加入语音频道（单频道模式，每个时刻只能在一个语音频道里面）
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_CONNECTED - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        /// <param name="userRole"> 用户在语音频道里面的角色，见YouMeUserRole定义 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode JoinChannelSingleMode (string strUserID, string strChannelID, YouMeUserRole userRole, bool autoRecvVideo = true)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

				return (YouMeErrorCode)youme_joinChannelSingleMode (strUserID, strChannelID, (int)userRole, autoRecvVideo);
		}
				
        /// <summary>
        /// 加入语音频道（多频道模式，可以同时听多个语音频道的内容，但每个时刻只能对着一个频道讲话）
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_CONNECTED - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        /// <param name="userRole"> 用户在语音频道里面的角色，见YouMeUserRole定义 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode JoinChannelMultiMode (string strUserID, string strChannelID, YouMeUserRole userRole)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_joinChannelMultiMode (strUserID, strChannelID, (int)userRole);
        }

        /// <summary>
        /// 多频道模式下，指定当前要讲话的频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_SPEAK_SUCCESS - 成功进入语音频道
        /// YouMeEvent.YOUME_EVENT_SPEAK_FAILED - 进入语音频道失败，可能原因是网络或服务器有问题
        /// </summary>
        ///
        /// <param name="strUserID"> 全局唯一的用户标识，全局指在当前应用程序的范围内 </param>
        /// <param name="strChannelID"> 全局唯一的频道标识，全局指在当前应用程序的范围内 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了进入语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SpeakToChannel (string strChannelID)
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_speakToChannel (strChannelID);
        }

        /// <summary>
        /// 退出指定的语音频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_TERMINATED - 成功退出语音频道
        /// YouMeEvent.YOUME_EVENT_TERMINATE_FAILED - 退出语音频道失败，可能原因是网络或服务器有问题。
        ///     只对多频道模式有意义，单频道模式下，退出总是成功的。
        /// </summary>
        ///
        /// <param name="strChannelID"> 指定要退出的频道的标识符 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了退出语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode LeaveChannelMultiMode (string strChannelID)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

				return (YouMeErrorCode)youme_leaveChannelMultiMode (strChannelID);
		}

        /// <summary>
        /// 退出所有的语音频道
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_TERMINATED。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功了启动了退出所有语音频道的流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode LeaveChannelAll ()
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_leaveChannelAll ();
        }

		/// <summary>
		/// 设置他人麦克风静音
		/// </summary>
		///
		/// <param name="userID">要控制的用户的ID</param>
		/// <param name="mute">true为静音，false为取消静音</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetOtherMicMute (string userID,bool mute){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setOtherMicMute(userID, mute );
		}

		/// <summary>
		/// 设置他人扬声器静音
		/// </summary>
		///
		/// <param name="userID">要控制的用户的ID</param>
		/// <param name="mute">true为静音，false为取消静音</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetOtherSpeakerMute (string userID,bool mute){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setOtherSpeakerMute(userID, mute);
		}

		/// <summary>
		/// 设置是否接收指定用户的语音
		/// </summary>
		///
		/// <param name="userID">要屏蔽的用户的ID</param>
		/// <param name="isOn">true为打开，false为关闭</param>
		///
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		///
		public YouMeErrorCode SetListenOtherVoice (string userID,bool isOn){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setListenOtherVoice(userID, isOn);
		}


        /// <summary>
        /// 播放指定的音乐文件。播放的音乐将会通过扬声器输出，并和语音混合后发送给接收方。这个功能适合于主播/指挥等使用。
        /// 如果当前已经有一个音乐文件在播放，正在播放的音乐会被停止，然后播放新的文件。
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，将通过如下回调事件通知音乐播放的状态：
        /// YouMeEvent.YOUME_EVENT_BGM_STOPPED - 音乐播放结束了
        /// YouMeEvent.YOUME_EVENT_BGM_FAILED - 音乐文件无法播放（比如文件损坏，格式不支持等）
        /// </summary>
        ///
        /// <param name="strFilePath"> 音乐文件的路径 </param>
        /// <param name="bRepeat"> true 重复播放这个文件， false 只播放一次就停止播放 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功启动了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode PlayBackgroundMusic (string strFilePath, bool bRepeat){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_playBackgroundMusic(strFilePath, bRepeat);
		}

        /// <summary>
        /// 暂停播放当前正在播放的背景音乐。
        /// 这是一个同步调用接口。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功暂停了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode PauseBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_pauseBackgroundMusic();
		}

        /// <summary>
        /// 恢复当前暂停播放的背景音乐。
        /// 这是一个同步调用接口。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功恢复了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode ResumeBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_resumeBackgroundMusic();
		}

        /// <summary>
        /// 停止播放当前正在播放的背景音乐。
        /// 这是一个同步调用接口，函数返回时，音乐播放也就停止了。
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功停止了音乐播放流程
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode StopBackgroundMusic (){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_stopBackgroundMusic();
		}

        /// <summary>
        /// 设定背景音乐的音量。这个接口用于调整背景音乐和语音之间的相对音量，使得背景音乐和语音混合听起来协调。
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="volume"> 背景音乐的音量，范围 [0-100], 100为最大音量 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了背景音乐的音量
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode SetBackgroundMusicVolume (int volume){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_setBackgroundMusicVolume(volume);
		}

        /// <summary>
        /// 设置插耳机的情况下开启或关闭语音监听（即通过耳机听到自己说话的内容或背景音乐）
        /// 外部输入模式下不起作用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="micEnabled"> 是否监听麦克风 true 监听，false 不监听 </param>
        /// <param name="bgmEnabled"> 是否监听背景音乐 true 监听，false 不监听 默认为true </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了语音监听
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetHeadsetMonitorOn(bool micEnabled, bool bgmEnabled = true){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setHeadsetMonitorOn(micEnabled, bgmEnabled);
        }

        /// <summary>
        /// 设置是否开启混响音效，这个主要对主播/指挥有用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled"> true 开启混响，false 关闭混响 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了混响音效
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetReverbEnabled(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_setReverbEnabled(enabled);
        }
        
        /// <summary>
        /// 设置是否开启语音检测回调
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled"> true 开启语音检测，false 关闭语音检测 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明成功设置了语音检测回调
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetVadCallbackEnabled(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setVadCallbackEnabled(enabled);
        }

        /// <summary>
        /// 设置麦克风音量回调参数
        /// 你可以在初始化成功后随时调用这个接口。在整个APP生命周期只需要调用一次，除非你想修改参数。
        /// 设置成功后，当用户讲话时，你将收到回调事件 MY_MIC_LEVEL， 回调参数 iStatus 表示当前讲话的音量级别。
        /// </summary>
        ///
        /// <param name="maxMicLevel">
        /// 设为 0 表示关闭麦克风音量回调
        /// 设为 大于0的值表示音量最大时对应的值，这个可以根据你们的UI设计来设定。
        /// 比如你用10级的音量条来表示音量变化，则传10。这样当底层回传音量是10时，则表示当前mic音量达到最大值。
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表示设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetMicLevelCallback(int maxMicLevel){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setMicLevelCallback(maxMicLevel);
        }

        /// <summary>
        /// 暂停通话，释放对麦克风等设备资源的占用。当需要用第三方模块临时录音时，可调用这个接口。
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_PAUSED - 成功暂停语音
        /// YouMeEvent.YOUME_EVENT_CONNECT_FAILED - 暂停语音失败
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明暂停通话正在进行当中
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode PauseChannel(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

                return (YouMeErrorCode)youme_pauseChannel();
        }
        
        /// <summary>
        /// 恢复通话，调用PauseChannel暂停通话后，可调用这个接口恢复通话
        /// 这是一个异步调用接口，函数返回YouMeErrorCode.YOUME_SUCCESS后，还需要等待如下事件回调
        /// YouMeEvent.YOUME_EVENT_RESUMED - 成功恢复语音
        /// YouMeEvent.YOUME_EVENT_RESUME_FAILED - 恢复语音失败
        /// </summary>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明恢复通话正在进行当中
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode ResumeChannel(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_resumeChannel();
        }

        /// <summary>
        /// 设置当前录音的时间戳。当通过录游戏脚本进行直播时，要保证观众端音画同步，在主播端需要进行时间对齐。
        /// 这个接口设置的就是当前游戏画面录制已经进行到哪个时间点了。
        /// </summary>
        ///
		/// <param name="timeMs"> 当前游戏画面对应的时间点，单位为毫秒 </param>
        /// <returns> void </returns>
        ///
        public void SetRecordingTimeMs(uint timeMs){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setRecordingTimeMs(timeMs);
        }

        /// <summary>
        /// 设置当前声音播放的时间戳。当通过录游戏脚本进行直播时，要保证观众端音画同步，游戏画面的播放需要和声音播放进行时间对齐。
        /// 这个接口设置的就是当前游戏画面播放已经进行到哪个时间点了。
        /// </summary>
        ///
		/// <param name="timeMs"> 当前游戏画面播放对应的时间点，单位为毫秒 </param>
        /// <returns> void </returns>
        ///
        public void SetPlayingTimeMs(uint timeMs){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

            youme_setPlayingTimeMs(timeMs);
        }

        /// <summary>
        /// 获取SDK版本号，版本号分为4段，如 2.5.0.0，这4段在int里面的分布如下
        /// | 4 bits | 6 bits | 8 bits | 14 bits|
        /// </summary>
        ///
        /// <returns>
        /// 压缩过的版本号
        /// </returns>
        ///
        public int GetSDKVersion(){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 0;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_getSDKVersion();
        }
		
				/**
 		 *  功能描述:Rest API , 向服务器请求额外数据
   		 *  @param strCommand: 请求的命令字符串
  		 *  @param strQueryBody: 请求需要的数据,json格式，内容参考restAPI
   		 *  @param requestID: 回传id,回调的时候传回，标识消息。
   		 *  @return YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
		 */
		public YouMeErrorCode  RequestRestApi( string command, string queryBody, ref int  requestID ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_requestRestApi( command,  queryBody, ref requestID );
		}
		
				/**
   		*  功能描述:查询频道的用户列表(必须在频道中)
   		*  @param channelID:要查询的频道ID
    	*  @param maxCount:想要获取的最大数量，-1表示获取全部
     	*  @param notifyMemChagne: 其他用户进出房间时，是否要收到通知
     	*  @return 错误码，详见YouMeConstDefine.h定义
     	*/
		public YouMeErrorCode  GetChannelUserList( string channelID,  int maxCount, bool notifyMemChange  ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_getChannelUserList( channelID,  maxCount, notifyMemChange);
		}

		/**
        *  功能描述:设置身份验证的token
        *  @param strToken: 身份验证用token，设置为NULL或者空字符串，清空token值,则不验证。
        *  @return 无
        */
		public void  SetToken( string strToken  ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return;
			}
			#endif

			youme_setToken(strToken);
		}

        /// <summary>
        /// 设置用户自定义Log路径
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="strFilePath"> 文件的路径 </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
		public YouMeErrorCode SetUserLogPath (string strFilePath){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setUserLogPath(strFilePath);
		}

        /// <summary>
        /// 设置当麦克风静音时，是否释放麦克风设备，在初始化之后、加入房间之前调用
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled">
        ///     true 当麦克风静音时，释放麦克风设备，此时允许第三方模块使用麦克风设备录音。在Android上，语音通过媒体音轨，而不是通话音轨输出。
        ///     false 不管麦克风是否静音，麦克风设备都会被占用。
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetReleaseMicWhenMute(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setReleaseMicWhenMute(enabled);
        }

        /// <summary>
        /// 设置插入耳机时，是否自动退出系统通话模式(禁用手机系统硬件信号前处理)
        /// 系统提供的前处理效果包括回声消除、自动增益等，有助于抑制背景音乐等回声噪音，减少系统资源消耗
        /// 由于插入耳机可从物理上阻断回声产生，故可设置禁用该效果以保留背景音乐的原生音质效果
        /// 默认为false，在初始化之后、加入房间之前调用
        /// 注：Windows和macOS不支持该接口
        /// 这是一个同步调用接口
        /// </summary>
        ///
        /// <param name="enabled">
        ///     true 当插入耳机时，自动禁用系统硬件信号前处理，拔出时还原
        ///     false 插拔耳机不做处理
        /// </param>
        ///
        /// <returns>
        /// YouMeErrorCode.YOUME_SUCCESS 表明设置成功
        /// 返回其他值时请看 YouMeErrorCode 的定义
        /// </returns>
        ///
        public YouMeErrorCode SetExitCommModeWhenHeadsetPlugin(bool enabled){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

            return (YouMeErrorCode)youme_setExitCommModeWhenHeadsetPlugin(enabled);
        }

		//---------------------抢麦接口---------------------//
        /**
        * 功能描述:    抢麦相关设置（抢麦活动发起前调用此接口进行设置）
        * @param const char * pChannelID: 抢麦活动的频道id
        * @param int mode: 抢麦模式（1:先到先得模式；2:按权重分配模式）
        * @param int maxAllowCount: 允许能抢到麦的最大人数
        * @param int maxTalkTime: 允许抢到麦后使用麦的最大时间（秒）
        * @param unsigned int voteTime: 抢麦仲裁时间（秒），过了X秒后服务器将进行仲裁谁最终获得麦（仅在按权重分配模式下有效）
        * @return   YOUME_SUCCESS - 成功
        *          其他 - 具体错误码
        */
        public YouMeErrorCode SetGrabMicOption(string pChannelID, int mode, int maxAllowCount, int maxTalkTime, uint voteTime)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_setGrabMicOption(pChannelID, mode, maxAllowCount, maxTalkTime, voteTime);
        }
		
		/**
		* 功能描述:    发起抢麦活动
		* @param const char * pChannelID: 抢麦活动的频道id
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode StartGrabMicAction(string pChannelID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_startGrabMicAction(pChannelID, pContent);
        }
		
		/**
		* 功能描述:    停止抢麦活动
		* @param const char * pChannelID: 抢麦活动的频道id
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode StopGrabMicAction(string pChannelID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_stopGrabMicAction(pChannelID, pContent);
        }
		
		/**
		* 功能描述:    发起抢麦请求
		* @param const char * pChannelID: 抢麦的频道id
		* @param int score: 积分（权重分配模式下有效，游戏根据自己实际情况设置）
		* @param bool isAutoOpenMic: 抢麦成功后是否自动开启麦克风权限
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
        public YouMeErrorCode requestGrabMic(string pChannelID, int score, bool isAutoOpenMic, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_requestGrabMic(pChannelID, score, isAutoOpenMic, pContent);
        }
		
		/**
		* 功能描述:    释放抢到的麦
		* @param const char * pChannelID: 抢麦活动的频道id
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/		
		public YouMeErrorCode releaseGrabMic(string pChannelID)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_releaseGrabMic(pChannelID);
        }
		
		//---------------------连麦接口---------------------//
		/**
		* 功能描述:    连麦相关设置（角色是频道的管理者或者主播时调用此接口进行频道内的连麦设置）
		* @param const char * pChannelID: 连麦的频道id
		* @param int waitTimeout: 等待对方响应超时时间（秒）
		* @param int maxTalkTime: 最大通话时间（秒）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
		public YouMeErrorCode setInviteMicOption(string pChannelID, int waitTimeout, int maxTalkTime)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_setInviteMicOption(pChannelID, waitTimeout, maxTalkTime);
        }
		
		/**
		* 功能描述:    发起与某人的连麦请求（主动呼叫）
		* @param const char * pUserID: 被叫方的用户id
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/		
		public YouMeErrorCode requestInviteMic(string pChannelID, string pUserID, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_requestInviteMic(pChannelID, pUserID, pContent);
        }

		/**
		* 功能描述:    对连麦请求做出回应（被动应答）
		* @param const char * pUserID: 主叫方的用户id
		* @param bool isAccept: 是否同意连麦
		* @param const char * pContent: 游戏传入的上下文内容，通知回调会传回此内容（目前只支持纯文本格式）
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
		public YouMeErrorCode responseInviteMic(string pUserID, bool isAccept, string pContent)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_responseInviteMic(pUserID, isAccept, pContent);
        }
		
		/**
		* 功能描述:    停止连麦
		* @return   YOUME_SUCCESS - 成功
		*          其他 - 具体错误码
		*/
		public YouMeErrorCode stopInviteMic()
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
            #endif

            return (YouMeErrorCode)youme_stopInviteMic();
        }
		
		
		/**
    	 * 功能描述:   向房间广播消息
     	 * @param channelID: 广播房间
    	 * @param content: 广播内容-文本串
	     * @param requestID:返回消息标识，回调的时候会回传该值
   		 *  @return YOUME_SUCCESS - 成功
     	 *          其他 - 具体错误码
		 */
		public YouMeErrorCode  SendMessage( string channelID, string content, ref int  requestID ){
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_sendMessage( channelID,  content, ref requestID );
		}
   
        /**
         *  功能描述: 把某人踢出房间
         *  @param  userID: 被踢的用户ID
         *  @param  channelID: 从哪个房间踢出
         *  @param  lastTime: 踢出后，多长时间内不允许再次进入
         *  @return YOUME_SUCCESS - 成功
         *          其他 - 具体错误码
         */
        private YouMeErrorCode KickOtherFromChannel( string userID , string channelID , int lastTime )
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            if (!mAndroidInitOK) {
            return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
            }
            #endif

            return (YouMeErrorCode)youme_kickOtherFromChannel( userID, channelID, lastTime );
        }

        /**
         *  功能描述: 设置日志等级
         *  @param consoleLevel: 控制台日志等级
         *  @param fileLevel: 文件日志等级
         */
        private void SetLogLevel( YOUME_LOG_LEVEL consoleLevel, YOUME_LOG_LEVEL  fileLevel )
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            return ;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
            if (!mAndroidInitOK) {
            return ;
            }
            #endif

            youme_setLogLevel( (int)consoleLevel, (int)fileLevel );
        }
        
        /**
        *  功能描述: 设置外部输入模式的语音采样率
        *  @param inputSampleRate: 输入语音采样率
        *  @param mixedCallbackSampleRate: mix后输出语音采样率
        *  @return YOUME_SUCCESS - 成功
        *          其他 - 具体错误码
        */
		private YouMeErrorCode SetExternalInputSampleRate( YOUME_SAMPLE_RATE  inputSampleRate, YOUME_SAMPLE_RATE mixedCallbackSampleRate )
        {
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
			return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setExternalInputSampleRate( (int)inputSampleRate, (int)mixedCallbackSampleRate );
        }




        // 设置是否开启视频编码器
        public YouMeErrorCode OpenVideoEncoder(string pFilePath)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return (YouMeErrorCode)youme_openVideoEncoder(pFilePath);
        }    
        
        // 创建渲染ID
        public int CreateRender(string userId)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_createRender(userId);
        }

        // 创建渲染ID
        public int DeleteRender(int renderId)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

            return youme_deleteRender(renderId);
        }
    
        // 设置视频回调
        public YouMeErrorCode SetVideoCallback()
        {

            return (YouMeErrorCode)youme_setVideoCallback("");

        }
    
        // 开始camera capture
        public YouMeErrorCode StartCapture()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_SUCCESS;
				}
			#endif

            return (YouMeErrorCode)youme_startCapture();
        }
    
        // 停止camera capture
        public YouMeErrorCode StopCapture()
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_SUCCESS;
				}
			#endif

            return (YouMeErrorCode)youme_stopCapture();
        }
    
        // 设置camera capture property
        public YouMeErrorCode SetVideoLocalResolution(int width, int height)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_SUCCESS;
				}
			#endif

            return (YouMeErrorCode)youme_setVideoLocalResolution(width, height);
        }
    
        // 设置是否前置摄像头
        public YouMeErrorCode SetCaptureFrontCameraEnable(bool enable)
        {
            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return YouMeErrorCode.YOUME_SUCCESS;
				}
			#endif

            return (YouMeErrorCode)youme_setCaptureFrontCameraEnable(enable);
        }

        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        // 获取视频数据
        public int GetVideoFrame(string userid, ref I420Frame frame)
        {
#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
#endif

            int len = 0;
            int width = 0;
            int height = 0;

            IntPtr dataPtr = youme_getVideoFrame(userid, ref len, ref width, ref height);
            if (dataPtr == System.IntPtr.Zero)
            {
                return 0;
            }

            if (len > frame.len)
            {
                frame.data = new byte[len];
                frame.len = len;
            }

            frame.width = width;
            frame.height = height;

            Marshal.Copy(dataPtr, frame.data, 0, len);

            //rgbtorgb24(bgr)
            for(int i =0; i<len; i+=3)
            {
                Swap(ref frame.data[i],ref frame.data[i + 2]);
            }
            return len;
        }

        public YouMeErrorCode MaskVideoByUserId(string userId, bool mask){
            if(userId==null){
                Debug.LogError("call MaskVideoByUserId,but userId is null");
                return YouMeErrorCode.YOUME_ERROR_INVALID_PARAM;
            }
            return (YouMeErrorCode)youme_maskVideoByUserId(userId, mask);
        }

        		
		/// <summary>
        /// 功能描述:是否是测试模式,测试模式使用测试服
		public void SetTestConfig(int bTest)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setTestConfig(bTest);
		}
		
		/// <summary>
        /// 功能描述:获取是否开启变声
		public bool GetSoundtouchEnabled()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getSoundtouchEnabled();
		}
		
		/// <summary>
        /// 功能描述:设置是否开启变声
		public void SetSoundtouchEnabled(bool bEnable)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSoundtouchEnabled(bEnable);
		}
		
		/// <summary>
        /// 功能描述:获取变速，1为正常值
        ///
		public float GetSoundtouchTempo()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 1;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

			return youme_getSoundtouchTempo();
		}
		
		/// <summary>
        /// 功能描述:设置变速，1为正常值
        ///
		public void SetSoundtouchTempo(float nTempo)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSoundtouchTempo(nTempo);
		}
		
		/// <summary>
        /// 功能描述:获取节拍，1为正常值
        ///
		public float GetSoundtouchRate()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 1;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

			return youme_getSoundtouchRate();
		}
		
		/// <summary>
        /// 功能描述:设置节拍，1为正常值
        ///
		public void SetSoundtouchRate(float nRate)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSoundtouchRate(nRate);
		}
		
		/// <summary>
        /// 功能描述:获取变调，1为正常值
        ///
		public float GetSoundtouchPitch()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 1;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

			return youme_getSoundtouchPitch();
		}
		
		/// <summary>
        /// 功能描述:设置变调，1为正常值
        ///
		public void SetSoundtouchPitch(float nPitch)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setSoundtouchPitch(nPitch);
		}

		/// <summary>
        /// 功能描述:(七牛接口)将提供的音频数据混合到麦克风或者扬声器的音轨里面。void*暂改为byte[]
        /// <param name="data">指向PCM数据的缓冲区</param>
		/// <param name="len">音频数据的大小</param>
		/// <param name="timestamp">时间搓</param>
        /// <returns>返回接口调用是否成功</returns>
        ///
		public YouMeErrorCode InputAudioFrame(byte[] data, int len, ulong timestamp)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_inputAudioFrame(data,len,timestamp);
		}

        /// <summary>
        /// 功能描述:(七牛接口)将提供的视频数据到producer。void*暂改为byte[]
        /// <param name="data">指向视频数据的缓冲区</param>
        /// <param name="len">视频数据的大小</param>
        /// <param name="timestamp">时间搓</param>
        /// <returns>返回接口调用是否成功</returns>
        ///
        public YouMeErrorCode InputVideoFrame(byte[] data, int len, int width, int height, int fmt, int rotation, int mirror, ulong timestamp)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_inputVideoFrame(data, len, width, height, fmt, rotation, mirror, timestamp);
		}
		
		/// <summary>
        /// 功能描述:设置是否启动远端语音音量回调
        /// <returns></returns>
        ///
		public YouMeErrorCode SetFarendVoiceLevelCallback(int maxLevel)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_setFarendVoiceLevelCallback(maxLevel);
		}
		
		/// <summary>
        /// 功能描述:设置服务器模式
        ///
		public void SetServerMode(int mode)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setServerMode(mode);
		}
		
		/// <summary>
        /// 功能描述:进入房间后，切换身份
        ///
		public YouMeErrorCode  SetUserRole(YouMeUserRole userRole)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_setUserRole((int)userRole);
		}
		
		/// <summary>
        /// 功能描述:获取身份
        ///
		public YouMeUserRole GetUserRole()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeUserRole.YOUME_USER_HOST;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeUserRole.YOUME_USER_HOST;
				}
			#endif

			return (YouMeUserRole)youme_getUserRole();
		}
		
		/// <summary>
        /// 功能描述:背景音乐是否在播放
        ///
		public bool IsBackgroundMusicPlaying()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_isBackgroundMusicPlaying();
		}
		
		/// <summary>
        /// 功能描述:是否初始化成功
        ///
		public bool IsInited()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_isInited();
		}
		
		/// <summary>
        /// 功能描述:是否在某个语音房间内
        ///
		public bool  IsInChannel(string pChannelID)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_isInChannel(pChannelID);
		}
		
		/// <summary>
        /// 功能描述:切换前后摄像头
        ///
		public YouMeErrorCode SwitchCamera()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_switchCamera();
		}

        /// <summary>
        /// 功能描述:视频数据输入(七牛接口，房间内其它用户会收到YOUME_EVENT_OTHERS_VIDEO_INPUT_START事件)void*暂改为byte[]
        /// <param name="data">视频帧数据(ios:CVPixelBufferRef, android:textureid)</param>
        /// <param name="width">视频图像宽</param>
        /// <param name="height">视频图像高</param>
        /// <param name="fmt">视频格式</param>
        /// <param name="rotation">视频角度</param>
        /// <param name="mirror">镜像</param>
        /// <param name="timestamp">时间戳</param>
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
        public YouMeErrorCode InputPixelBuffer(byte[] data, int width, int height, int fmt, int rotation, int mirror, ulong timestamp)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_inputPixelBuffer(data,width,height,fmt,rotation,mirror,timestamp);
		}
		
		/// <summary>
        /// 功能描述:停止视频数据输入(七牛接口，在youme_inputVideoFrame之后调用，房间内其它用户会收到YOUME_EVENT_OTHERS_VIDEO_INPUT_STOP事件)
        /// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
		public YouMeErrorCode StopInputVideoFrame()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_stopInputVideoFrame();
		}
		
		/// <summary>
        /// 功能描述:权限检测结束后重置摄像头
		/// <returns>返回接口调用是否成功的状态码，YouMeErrorCode.YOUME_SUCCESS表示成功</returns>
        ///
		public YouMeErrorCode ResetCamera()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_resetCamera();
		}
		
		/// <summary>
        /// 功能描述:设置视频网络传输过程的分辨率,高分辨率
		/// <param name="width">视频图像宽</param>
		/// <param name="height">视频图像高</param>
        ///
		public YouMeErrorCode  SetVideoNetResolution( int width, int height )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			    return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
				    return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
				}
			#endif

			return (YouMeErrorCode)youme_setVideoNetResolution(width,height);
		}
		
		/// <summary>
        /// 功能描述:设置音视频统计数据时间间隔
		/// <param name="interval">时间间隔</param>
        ///
		public void SetAVStatisticInterval( int interval  )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return ;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return ;
				}
			#endif

		    youme_setAVStatisticInterval(interval);
		}
		
		/// <summary>
        /// 功能描述:设置Audio的传输质量
		/// <param name="quality">0: low 1: high</param>
        ///
		public void SetAudioQuality( YOUME_AUDIO_QUALITY quality )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return ;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return ;
				}
			#endif

			youme_setAudioQuality((int)quality);
		}
		
		/// <summary>
        /// 功能描述:设置视频数据上行的码率的上下限。
		/// <param name="maxBitrate">最大码率，单位kbit/s.  0无效</param>
		/// <param name="minBitrate">最小码率，单位kbit/s.  0无效</param>
        ///
		public void SetVideoCodeBitrate( uint maxBitrate,  uint minBitrate )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return ;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return ;
				}
			#endif

			youme_setVideoCodeBitrate(maxBitrate,minBitrate);
		}
		
		/// <summary>
        /// 功能描述:获取视频数据上行的当前码率。
        /// <returns>视频数据上行的当前码率</returns>
		public uint GetCurrentVideoCodeBitrate( )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return 1;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return 0;
				}
			#endif

			return youme_getCurrentVideoCodeBitrate();
		}
		
		/// <summary>
        /// 功能描述:设置视频数据是否同意开启硬编硬解
        ///
		public void SetVideoHardwareCodeEnable( bool bEnable )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return ;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return ;
				}
			#endif

			youme_setVideoHardwareCodeEnable(bEnable);
		}
		
		/// <summary>
        /// 功能描述:获取视频数据是否同意开启硬编硬解
        ///
		public bool GetVideoHardwareCodeEnable( )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return false;
				}
			#endif

			return youme_getVideoHardwareCodeEnable();
		}
		
		/// <summary>
        /// 功能描述:设置视频无帧渲染的等待超时时间，超过这个时间会给上层回调
		/// <param name="timeout"> 超时时间，单位为毫秒</param>
        ///
		public void SetVideoNoFrameTimeout(int timeout)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				return;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
				if (!mAndroidInitOK) {
					return;
				}
			#endif

			youme_setVideoNoFrameTimeout(timeout);
		}
		
		/// <summary>
        /// 功能描述:查询多个用户视频信息（支持分辨率）
		/// <param name="userList"> 用户ID列表的json数组</param>
        ///
		public YouMeErrorCode QueryUsersVideoInfo( string userList)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_queryUsersVideoInfo(userList);
		}
		
		/// <summary>
        /// 功能描述:设置多个用户视频信息（支持分辨率）
		/// <param name="videoinfoList"> 用户对应分辨率列表的json数组</param>
        ///
		public YouMeErrorCode SetUsersVideoInfo( string videoinfoList )
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return (YouMeErrorCode)youme_setUsersVideoInfo(videoinfoList);
		}

        /// <summary>
        /// 功能描述:调用后同步完成麦克风释放，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        ///
		public bool ReleaseMicSync()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return false;
			}
			#endif

			return youme_releaseMicSync();
		}
		
		/// <summary>
        /// 功能描述:调用后恢复麦克风到释放前的状态，只是为了方便使用 IM 的录音接口时切换麦克风使用权。
        ///
		public bool ResumeMicSync()
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return true;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return false;
			}
			#endif

			return youme_resumeMicSync();
		}
		
		/// <summary>
        /// 功能描述: 美颜开关，默认是关闭美颜。
		/// <param name="open"> true表示开启美颜，false表示关闭美颜</param>
        ///
		public YouMeErrorCode OpenBeautify(bool open)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return youme_openBeautify(open);
		}
		
		/// <summary>
        /// 功能描述: 美颜强度参数设置。
		/// <param name="param"> 美颜强度参数，0.0 - 1.0 ，默认为0，几乎没有美颜效果，0.5左右效果明显</param>
        ///
		public YouMeErrorCode BeautifyChanged(float param)
		{
			#if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return youme_beautifyChanged(param);
		}

        public YouMeErrorCode SetVideoFrameRawCbEnabled(bool enable)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			return YouMeErrorCode.YOUME_SUCCESS;
			#endif

			#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			if (!mAndroidInitOK) {
				return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			}
			#endif

			return youme_setVideoFrameRawCbEnabled( enable );
        }

        /// <summary>
        /// 功能描述: 设置自己预览画面的大小。
        /// <param name="open"> true表示开启美颜，false表示关闭美颜</param>
        ///
        public void SetMixVideoSize(int width, int height)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			                        return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
			                        if (!mAndroidInitOK) {
				                        return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
			                        }
            #endif

            youme_setMixVideoSize(width, height);
        }

        public void AddMixOverlayVideo(string userId, int x, int y, int z, int width, int height)
        {
            #if UNITY_EDITOR && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
	            return YouMeErrorCode.YOUME_SUCCESS;
            #endif

            #if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
	            if (!mAndroidInitOK) {
		            return YouMeErrorCode.YOUME_ERROR_UNKNOWN;
	            }
            #endif

            youme_addMixOverlayVideo(userId, x, y, z, width, height);
        }

    } //YouMeVoiceAPI
}
