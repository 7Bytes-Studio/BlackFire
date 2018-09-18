using System;
using System.Collections;
using System.Collections.Generic;
using BlackFireFramework;
using BlackFireFramework.Pattern;
using BlackFireFramework.Unity;
using UnityEngine;

namespace Alan
{
	public sealed class MVPDemo : MonoBehaviour
	{
		private void Start()
		{
			BlackFire.MVP.BindMVP<M,V,P>();
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

		protected override IModel ModelInterface
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

		protected override IView ViewInterface
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
			var name = (ModelInterface as INameDataModel).AcquireName();
			(ViewInterface as ITestUIView).SetNameText(name);
		}
	}
	
	


}


