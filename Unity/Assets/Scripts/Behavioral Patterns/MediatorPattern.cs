using UnityEngine;
using System.Collections;

/// <summary>
/// Midiator.
/// </summary>
namespace GangOfFour.Behavioral.Mediator
{
	public abstract class Mediator
	{
		public abstract void Send (string message, Colleague colleague);
	}

	public class ConcreteMediator : Mediator
	{
		private ConcreteColleague1 mColleague1;
		private ConcreteColleague2 mColleague2;

		public ConcreteColleague1 Colleague1 {
			set {
				mColleague1 = value;
			}
		}

		public ConcreteColleague2 Colleague2 {
			set {
				mColleague2 = value;
			}
		}

		public override void Send (string message, Colleague colleague)
		{
			if (colleague == mColleague1) {
				mColleague2.Notify (message);
			} else {
				mColleague1.Notify (message);
			}
		}
	}

	public abstract class Colleague
	{
		protected Mediator mMediator;

		public Colleague (Mediator mediator)
		{
			mMediator = mediator;
		}
	}

	public class ConcreteColleague1 : Colleague
	{
		public ConcreteColleague1 (Mediator mediator) : base (mediator)
		{
		}

		public void Send (string message)
		{
			mMediator.Send (message, this);
		}

		public void Notify (string message)
		{
			Debug.Log ("ConcreteColleague1 Notify " + message);
		}
	}

	public class ConcreteColleague2 : Colleague
	{
		public ConcreteColleague2 (Mediator mediator) : base (mediator)
		{
		}

		public void Send (string message)
		{
			mMediator.Send (message, this);
		}

		public void Notify (string message)
		{
			Debug.Log ("ConcreteColleague2 Notify " + message);
		}
	}

	public class MediatorPattern : MonoBehaviour
	{
		void Start ()
		{
			ConcreteMediator mediator = new ConcreteMediator ();

			ConcreteColleague1 colleague1 = new ConcreteColleague1 (mediator);
			ConcreteColleague2 colleague2 = new ConcreteColleague2 (mediator);

			mediator.Colleague1 = colleague1;
			mediator.Colleague2 = colleague2;

			Debug.Log (this.GetType().Name + " ----------");

			colleague1.Send ("Hello !!");
			colleague2.Send ("Hi.");

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
