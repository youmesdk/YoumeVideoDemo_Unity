using System;
using UnityEngine;
using System.Collections.Generic;
using  System.Threading;


/// <summary>
/// 游密科技 Unity 纹理控件
/// </summary>
namespace YouMe
{
	public class TextureInfo
	{
		public int renderId;
        public string userid;
        public bool isStop;
        public Rect position;
		public Texture2D texture;
        public YouMe.I420Frame frame;
    }

	public class YouMeTexture: MonoBehaviour
	{
		private static int DEFAULT_WIDTH = 352;
		private static int DEFAULT_HEIGHT = 288;

		private static YouMeTexture mInstance = null;
		private Dictionary<int, TextureInfo> renders = new Dictionary<int, TextureInfo>(4);
        private Dictionary<int, Action<Texture2D>> videoRenderUpdates= new Dictionary<int, Action<Texture2D>>(4);

		public bool SetVideoRenderUpdateCallback(int renderid,Action<Texture2D> callback){
			if(!videoRenderUpdates.ContainsKey(renderid)){
				foreach (TextureInfo render in renders.Values){
                    if (render.renderId == renderid)
                    {
						videoRenderUpdates.Add(renderid, callback);
                        render.isStop = false;
						return true;
                    }
                }
            }else{
				foreach (TextureInfo render in renders.Values){
					if(render.renderId == renderid){
						render.isStop = false;
                        videoRenderUpdates[renderid] = callback;
                        return true;
					} 
                }
			}
            return false;
        }
		
		public bool RemoveVideoRenderUpdateCallback(int renderid){
			if(videoRenderUpdates.ContainsKey(renderid)){
                videoRenderUpdates.Remove(renderid);
                renders.Remove(renderid);
                foreach (TextureInfo render in renders.Values)
                { 
					if(render.renderId == renderid) render.isStop = true;
				}
                return true;
            }
            return false;
		}

		public bool PauseVideoRender(string userid){
			foreach (TextureInfo render in renders.Values)
            {
				if(render.userid == userid){
                    render.isStop = true;
                    return true;
                }
			}
            return false;
		}

		public bool ResumeVideoRender(string userid){
			foreach (TextureInfo render in renders.Values)
            {
				if(render.userid == userid){
                    render.isStop = false;
                    return true;
                }
			}
            return false;
		}

		public bool DeleteRender(string userid){
			foreach (TextureInfo render in renders.Values)
            {
				if(render.userid == userid){
					videoRenderUpdates.Remove(render.renderId);
                    YouMe.YouMeVoiceAPI.GetInstance().DeleteRender(render.renderId);
					renders.Remove(render.renderId);
                    return true;
                }
			}
            return false;
		}

        public static YouMeTexture GetInstance ()
		{
			if (mInstance == null) 
			{
				var youmeObj = new GameObject ("__YouMeVideoGameObject__");
				GameObject.DontDestroyOnLoad (youmeObj);
				youmeObj.hideFlags = HideFlags.DontSave;
				mInstance = youmeObj.AddComponent<YouMeTexture> ();
			}
			return mInstance;
		}

		/// <summary>
		/// 创建纹理
		/// </summary>
		/// <returns>The texture.</returns>
		/// <param name="userId">User identifier.</param>
		public int CreateTexture(string userId)
		{
			int renderId = YouMe.YouMeVoiceAPI.GetInstance ().CreateRender (userId);

			YouMe.YouMeVoiceAPI.GetInstance ().SetVideoCallback ();

			TextureInfo render = new TextureInfo ();
			render.position = new Rect (0, 0, DEFAULT_WIDTH, DEFAULT_HEIGHT);
			render.texture = new Texture2D (DEFAULT_WIDTH, DEFAULT_HEIGHT, TextureFormat.RGB24, false);
            // render.texture = Texture2D.CreateExternalTexture(DEFAULT_WIDTH, DEFAULT_HEIGHT, TextureFormat.RGB24, false,false,YouMeVoiceAPI.youme_getVideoFrame2(renderId));
            render.userid = userId;
            render.renderId = renderId;
            render.isStop = true;
            render.frame = new YouMe.I420Frame (DEFAULT_WIDTH * DEFAULT_HEIGHT * 3); /* rgb24 */
			if(renders.ContainsKey(renderId))
			{
                renders[renderId] = render;
            }else
            {
                renders.Add(renderId, render);
            }
            return renderId;
		}

		/// <summary>
		/// 删除所有控件
		/// </summary>
		public void DeleteAllTexture()
		{
			foreach (TextureInfo render in renders.Values)
            {
                YouMe.YouMeVoiceAPI.GetInstance().DeleteRender(render.renderId);
			}
			renders.Clear ();
		}

		void Start(){
			// Thread thr = new Thread(VideoUpdate);
			// thr.Start();
			// InvokeRepeating("VideoUpdate", 0.05f, 0.033f);
		}

		void Update(){
			VideoUpdate();
		}

        private List<Action> callQueue = new List<Action>();
        private readonly object callQueueLock = new object();
        void VideoUpdateMain(){
			if(callQueue.Count>0){
                    callQueue[0]();
				lock (callQueueLock)
                {
                    callQueue.RemoveAt(0);
                }
            }
		}

		/// <summary>
		/// 更新数据,Unity Update驱动
		/// </summary>
		void VideoUpdate()
		{
            // while (true)
            // {
                foreach(TextureInfo  render in renders.Values)
                {
					if(render.isStop){
                    	continue;
                	}
                    // lock (callQueueLock)
                    // {
                        int ret = YouMe.YouMeVoiceAPI.GetInstance().GetVideoFrame(render.userid, ref render.frame);

                        if (ret > 0)
                        {
                            // Debug.Log("YouMeTexture renderId:" + render.renderId + " frame renderId:" + frame.renderId + " len:" + frame.len);
                            // render.texture.UpdateExternalTexture(YouMeVoiceAPI.youme_getVideoFrame2(render.renderId));

                            // callQueue.Add(() =>
                            // {
								if (render.frame.width != render.texture.width || render.frame.height != render.texture.height){
									render.texture.Resize (render.frame.width, render.frame.height);
								}
                                render.texture.LoadRawTextureData(render.frame.data);
                                render.texture.Apply();
                                Action<Texture2D> videoRenderUpdate = null;
                                if (videoRenderUpdates.TryGetValue(render.renderId, out videoRenderUpdate))
                                {
                                    videoRenderUpdate(render.texture);
                                }
                            // });

                        }
                        else
                        {
                            // Debug.Log("YouMeTexture renderId:" + render.renderId + " ret:" + ret);
                        }
                    // }
                }
                // Thread.Sleep(60);
            // }
        }

		/// <summary>
		/// 显示
		/// </summary>
		public void Draw () 
		{
			foreach (TextureInfo texture in renders.Values) 
			{
				GUI.DrawTexture (texture.position, texture.texture);
			}
		}

		/// <summary>
		/// 设置渲染控件位置
		/// </summary>
		/// <param name="textureId">Texture identifier.</param>
		/// <param name="position">Position.</param>
		public void SetPosition (int textureId, Rect position) 
		{
			if (renders.ContainsKey (textureId)) 
			{
				renders [textureId].position = position;
			}
		}
	}
}

