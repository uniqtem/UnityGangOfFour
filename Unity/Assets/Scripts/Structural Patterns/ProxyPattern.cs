using UnityEngine;
using System.Collections;

/// <summary>
/// Proxy.
/// </summary>
namespace GangOfFour.Structural.Proxy
{
	public abstract class Subject
	{
		public abstract void Request ();
	}

	public class RealSubject : Subject
	{
		public override void Request ()
		{
			Debug.Log ("RealSubject Request");
		}
	}

	public class Proxy : Subject
	{
		private RealSubject mRealSubject;

		public Proxy ()
		{
			mRealSubject = new RealSubject ();
		}

		public override void Request ()
		{
			mRealSubject.Request ();
		}
	}

	public class ProxyPattern : MonoBehaviour
	{
		void Start ()
		{
			Proxy proxy = new Proxy ();

			Debug.Log (this.GetType().Name + " ----------");

			proxy.Request ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
