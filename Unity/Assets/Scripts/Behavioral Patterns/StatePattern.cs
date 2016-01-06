using UnityEngine;
using System.Collections;

/// <summary>
/// State.
/// </summary>
namespace GangOfFour.Behavioral.State
{
	public abstract class State
	{
		public abstract void Handle (Context context);
	}

	public class ConcreteStateA : State
	{
		public override void Handle (Context context)
		{
			context.State = new ConcreteStateB ();
		}
	}

	public class ConcreteStateB : State
	{
		public override void Handle (Context context)
		{
			context.State = new ConcreteStateA ();
		}
	}

	public class Context
	{
		private State mState;

		public Context (State status)
		{
			mState = status;
		}

		public State State
		{
			get {
				return mState;
			}
			set {
				mState = value;
				Debug.Log ("State : " + mState.GetType ().Name);
			}
		}

		public void Request ()
		{
			mState.Handle (this);
		}
	}

	public class StatePattern : MonoBehaviour
	{
		void Start ()
		{
			Context context = new Context (new ConcreteStateA ());

			Debug.Log (this.GetType().Name + " ----------");

			context.Request ();
			context.Request ();
			context.Request ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
