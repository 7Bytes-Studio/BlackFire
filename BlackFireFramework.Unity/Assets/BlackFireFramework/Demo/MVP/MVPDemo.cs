using System;
using System.Collections;
using System.Collections.Generic;
using BlackFireFramework;
using BlackFireFramework.Pattern;
using BlackFireFramework.Unity;

namespace Alan
{
	public sealed class MVPDemo : ManagerBase
	{
		protected override void OnStart()
		{
			base.OnStart();
			RegisterModule<IMVPModule>();
			var mvpModule = GetModule<IMVPModule>();
			mvpModule.BindVP(typeof(V),new Type[]{typeof(P) });
			mvpModule.BindMP(typeof(M),new Type[]{typeof(P) });
		}
	}


	public interface IUpdateUIViewEventHandler : IViewEventHandler
	{
		void UpdateUI();
	}

	public interface ITestUIView
	{
		void SetNameText(string text);
	}


	public interface INameDataModel
	{
		string AcquireName();
	}


	public sealed class M : BlackFireFramework.Pattern.ModelBase,IModel,INameDataModel
	{

		protected override void OnInit()
		{
			//Log.Info("M::Init");
		}

		protected override void OnUpdate()
		{
			//Log.Info("M::OnUpdate");
		}

		protected override void OnDestroy()
		{
			//Log.Info("M::OnDestroy");
		}

		protected override IModel Model
		{
			get { return this ; }
		}

		public string AcquireName()
		{
			return "Alan";
		}
	}


	public sealed class V : BlackFireFramework.Pattern.ViewBase,IView,ITestUIView
	{

		protected override void OnInit()
		{
			//Log.Info("V::Init");
			Timer.Delay(3f).On(() => { Fire<IUpdateUIViewEventHandler>(i=>i.UpdateUI()); });
		}

		protected override void OnUpdate()
		{
			//Log.Info("V::OnUpdate");
		}

		protected override void OnDestroy()
		{
			//Log.Info("V::OnDestroy");
		}

		protected override IView View
		{
			get { return this; }
		}

		public void SetNameText(string text)
		{
			Log.Info("UI被设置::::  "+text);
		}
	}

	
	public sealed class P : BlackFireFramework.Pattern.PresenterBase,IUpdateUIViewEventHandler
	{
		protected override void OnInit()
		{
			//Log.Info("P::Init");
		}

		protected override void OnUpdate()
		{
			//Log.Info("P::OnUpdate");
		}

		protected override void OnDestroy()
		{
			//Log.Info("P::OnDestroy");
		}

		public void UpdateUI()
		{
			var name = (Model as INameDataModel).AcquireName();
			(View as ITestUIView).SetNameText(name);
		}
	}
	
	


}


