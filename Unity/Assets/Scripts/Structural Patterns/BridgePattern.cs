using UnityEngine;
using System.Collections;

/// <summary>
/// Bridge.
/// </summary>
namespace GangOfFour.Structural.Bridge
{
	public abstract class Implementor
	{
		public abstract void Operation ();
	}

	public class Abstraction
	{
		private Implementor mImplementor;

		public Implementor Implementor
		{
			set {
				mImplementor = value;
			}
		}

		public virtual void Operation ()
		{
			mImplementor.Operation ();
		}
	}

	public class RefindedAbstraction : Abstraction
	{
	}

	public class ConcreteImplementorA : Implementor
	{
		public override void Operation ()
		{
			Debug.Log ("ConcreteImplementorA Operation");
		}
	}

	public class ConcreteImplementorB : Implementor
	{
		public override void Operation ()
		{
			Debug.Log ("ConcreteImplementorB Operation");
		}
	}

	public class BridgePattern : MonoBehaviour
	{
		void Start ()
		{
			Abstraction abstraction = new RefindedAbstraction ();

			Debug.Log (this.GetType().Name + " ----------");

			abstraction.Implementor = new ConcreteImplementorA ();
			abstraction.Operation ();

			abstraction.Implementor = new ConcreteImplementorB ();
			abstraction.Operation ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
