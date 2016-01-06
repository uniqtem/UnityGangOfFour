using UnityEngine;
using System.Collections;

/// <summary>
/// Memento.
/// </summary>
namespace GangOfFour.Behavioral.Memento
{
	public class Originator
	{
		private string mStatus;

		public string Status {
			get {
				return mStatus;
			}
			set {
				mStatus = value;
				Debug.Log ("Status = " + mStatus);
			}
		}

		public Memento CreateMemento ()
		{
			return new Memento (mStatus);
		}

		public void SetMemento (Memento memento)
		{
			Debug.Log ("Restoring status");
			Status = memento.Status;
		}
	}

	public class Memento
	{
		private string mStatus;

		public Memento (string status)
		{
			mStatus = status;
		}

		public string Status
		{
			get {
				return mStatus;
			}
		}
	}

	public class Caretaker
	{
		private Memento mMemento;

		public Memento Memento
		{
			get {
				return mMemento;
			}
			set {
				mMemento = value;
			}
		}
	}

	public class MementoPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log (this.GetType().Name + " ----------");

			Originator originator = new Originator ();
			originator.Status = "On";

			Caretaker caretaker = new Caretaker ();
			caretaker.Memento = originator.CreateMemento ();

			originator.Status = "Off";

			originator.SetMemento (caretaker.Memento);

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
