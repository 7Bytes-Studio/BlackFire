//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OpenCVForUnity;
using UnityEngine;
using BlackFireFramework;
using Rect = OpenCVForUnity.Rect;

namespace BlackFireFramework.Unity
{
	public sealed partial class GraphicsManager
	{

		private AsynchronousFaceDetectionWebCamTexture m_Afdwct;
		private void Init_FaceTracker()
		{
			var afdwctTpl = Resources.Load<AsynchronousFaceDetectionWebCamTexture>("CG/AsynchronousFaceDetection");
			m_Afdwct = Instantiate<AsynchronousFaceDetectionWebCamTexture>(afdwctTpl, transform);
			m_Afdwct.OnFaceTrackRect += _OnFaceTrackRect;
		}

		private void Destroy_FaceTracker()
		{
			m_Afdwct.OnFaceTrackRect -= _OnFaceTrackRect;
		}

		private void _OnFaceTrackRect(Rect[] obj)
		{
			var args = new FaceTrackerEventArgs();
			for (int i = 0; i < obj.Length; i++)
			{
				args.Rects.Add(new UnityEngine.Rect(obj[i].x,obj[i].y,obj[i].width,obj[i].height));
			}
			if (null!=OnFaceTrack)
			{
				OnFaceTrack.Invoke(this,args);
			}
		}

		public event EventHandler<FaceTrackerEventArgs> OnFaceTrack;

	}

	public sealed class FaceTrackerEventArgs : EventArgs
	{
		//宽度:640 高度:480
		
		private List<UnityEngine.Rect> m_Rects = new List<UnityEngine.Rect>();
		public List<UnityEngine.Rect> Rects
		{
			get { return m_Rects; }
		}

		private UnityEngine.Rect m_AverageRect = UnityEngine.Rect.zero;
		public UnityEngine.Rect AverageRect
		{
			get
			{
				if (m_AverageRect!=UnityEngine.Rect.zero)
				{
					return m_AverageRect;
				}
				
				UnityEngine.Rect t= UnityEngine.Rect.zero;
				for (int i = 0; i < Rects.Count; i++)
				{
					t = new UnityEngine.Rect(t.x+Rects[i].x,t.y+Rects[i].y,t.width+Rects[i].height,t.height+Rects[i].height);
				}
				t=new UnityEngine.Rect(t.x/Rects.Count,t.y/Rects.Count,t.width/Rects.Count,t.height/Rects.Count);
				return t;
			}
		}

		public float Widthpercent
		{
			get { return AverageRect.x / 640; }
		}
		
		public float Heightpercent
		{
			get { return AverageRect.y / 480; }
		}
		
		public float Deeppercent
		{
			get { return AverageRect.width / 480; }
		}

	}


}
