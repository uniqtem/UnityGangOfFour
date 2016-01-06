using UnityEngine;
using System.Collections;

/// <summary>
/// ChainOfResponsibility.
/// </summary>
namespace GangOfFour.Behavioral.ChainOfResponsibility
{
	public abstract class Handler
	{
		protected Handler mSuccessor;

		public void SetSuccessor (Handler successor)
		{
			mSuccessor = successor;
		}

		public abstract void HandlerRequest (int request);
	}

	public class ConcreteHandler1 : Handler
	{
		public override void HandlerRequest (int request)
		{
			if (request >= 0 && request < 10) {
				Debug.Log ("ConcreteHandler1 HandlerRequest : " + request);
			} else if (mSuccessor != null) {
				mSuccessor.HandlerRequest (request);
			}
		}
	}

	public class ConcreteHandler2 : Handler
	{
		public override void HandlerRequest (int request)
		{
			if (request >= 10 && request < 20) {
				Debug.Log ("ConcreteHandler2 HandlerRequest : " + request);
			} else if (mSuccessor != null) {
				mSuccessor.HandlerRequest (request);
			}
		}
	}

	public class ConcreteHandler3 : Handler
	{
		public override void HandlerRequest (int request)
		{
			if (request >= 20 || request < 0) {
				Debug.Log ("ConcreteHandler3 HandlerRequest : " + request);
			} else if (mSuccessor != null) {
				mSuccessor.HandlerRequest (request);
			}
		}
	}

	public class ChainOfRespPattern : MonoBehaviour
	{
		void Start ()
		{
			Handler h1 = new ConcreteHandler1 ();
			Handler h2 = new ConcreteHandler2 ();
			Handler h3 = new ConcreteHandler3 ();

			h1.SetSuccessor (h2);
			h2.SetSuccessor (h3);

			Debug.Log (this.GetType().Name + " ----------");

			for (int i = 0; i < 10; i++) {
				h1.HandlerRequest ((int)Random.Range (-10, 30));
			}

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}


