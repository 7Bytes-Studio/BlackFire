//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using BlackFireFramework.Pattern;

namespace BlackFireFramework.Unity
{
	public static class IMVPManagerExtension
	{

		public static void BindVP<TView,TPresenter>(this IMVPManager mvpManager) where TView:ViewBase where TPresenter:PresenterBase
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter)});
		}

		public static void BindVP<TView,TPresenter1,TPresenter2>(this IMVPManager mvpManager) where TView:ViewBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter1),typeof(TPresenter2)});
		}
		
		public static void BindVP<TView,TPresenter1,TPresenter2,TPresenter3>(this IMVPManager mvpManager) where TView:ViewBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase 
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3)});
		}
		
		public static void BindVP<TView,TPresenter1,TPresenter2,TPresenter3,TPresenter4>(this IMVPManager mvpManager) where TView:ViewBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase where TPresenter4:PresenterBase
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3),typeof(TPresenter4)});
		}
		
		public static void BindVP<TView,TPresenter1,TPresenter2,TPresenter3,TPresenter4,TPresenter5>(this IMVPManager mvpManager) where TView:ViewBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase where TPresenter4:PresenterBase where TPresenter5:PresenterBase
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3),typeof(TPresenter4),typeof(TPresenter4)});
		}
		
		
		
		public static void BindMP<TModel,TPresenter>(this IMVPManager mvpManager) where TModel:ModelBase where TPresenter:PresenterBase
		{
			mvpManager.BindMP(typeof(TModel),new []{typeof(TPresenter)});
		}

		public static void BindMP<TModel,TPresenter1,TPresenter2>(this IMVPManager mvpManager) where TModel:ModelBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase
		{
			mvpManager.BindMP(typeof(TModel),new []{typeof(TPresenter1),typeof(TPresenter2)});
		}
		
		public static void BindMP<TModel,TPresenter1,TPresenter2,TPresenter3>(this IMVPManager mvpManager) where TModel:ModelBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase 
		{
			mvpManager.BindMP(typeof(TModel),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3)});
		}
		
		public static void BindMP<TModel,TPresenter1,TPresenter2,TPresenter3,TPresenter4>(this IMVPManager mvpManager) where TModel:ModelBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase where TPresenter4:PresenterBase
		{
			mvpManager.BindVP(typeof(TModel),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3),typeof(TPresenter4)});
		}
		
		public static void BindMP<TModel,TPresenter1,TPresenter2,TPresenter3,TPresenter4,TPresenter5>(this IMVPManager mvpManager) where TModel:ModelBase where TPresenter1:PresenterBase where TPresenter2:PresenterBase where TPresenter3:PresenterBase where TPresenter4:PresenterBase where TPresenter5:PresenterBase
		{
			mvpManager.BindVP(typeof(TModel),new []{typeof(TPresenter1),typeof(TPresenter2),typeof(TPresenter3),typeof(TPresenter4),typeof(TPresenter4)});
		}
		
		
		
		
		public static void BindMVP<TModel,TView,TPresenter>(this IMVPManager mvpManager) where TModel:Pattern.ModelBase where TView:ViewBase where TPresenter:PresenterBase
		{
			mvpManager.BindVP(typeof(TView),new []{typeof(TPresenter)});
			mvpManager.BindMP(typeof(TModel),new []{typeof(TPresenter)});
		}

		
		
		public static void UnBind<T>(this IMVPManager mvpManager) where T : PatternEntityTreeNode
		{
			mvpManager.UnBind(typeof(T));
		}

	
		public static Pattern.ModelBase AcquireModel<T>(this IMVPManager mvpManager) where T : Pattern.ModelBase
		{
			return mvpManager.AcquireModel(typeof(T));
		}

		public static ViewBase AcquireView<T>(this IMVPManager mvpManager) where T : ViewBase
		{
			return mvpManager.AcquireView(typeof(T));
		}

		public static PresenterBase AcquirePresenter<T>(this IMVPManager mvpManager) where T : PresenterBase
		{
			return mvpManager.AcquirePresenter(typeof(T));
		}
		
		
		
		
	}
}