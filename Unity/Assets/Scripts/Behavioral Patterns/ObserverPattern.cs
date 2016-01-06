using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Observer.
/// </summary>
namespace GangOfFour.Behavioral.Observer
{
	public abstract class Subject
	{
		private List<Observer> mObservers = new List<Observer> ();

		public void Add (Observer observer)
		{
			mObservers.Add (observer);
		}

		public void Detach (Observer observer)
		{
			mObservers.Remove (observer);
		}

		public void Notify ()
		{
			foreach (Observer observer in mObservers) {
				observer.Update ();
			}
		}
	}

	public class ConcreteSubject : Subject
	{
		private string mSubjectStatus;

		public string SubjectStatus
		{
			get {
				return mSubjectStatus;
			}
			set {
				mSubjectStatus = value;
			}
		}
	}

	public abstract class Observer
	{
		public abstract void Update ();
	}

	public class ConcreteObserver : Observer
	{
		private ConcreteSubject mSubject;
		private string mName;
		private string mObserverStatus;

		public ConcreteSubject Subject
		{
			get {
				return mSubject;
			}
			set {
				mSubject = value;
			}
		}

		public ConcreteObserver (ConcreteSubject subject, string name)
		{
			mSubject = subject;
			mName = name;
		}

		public override void Update ()
		{
			mObserverStatus = mSubject.SubjectStatus;

			Debug.Log (string.Format ("Observer {0}'s new status is {1}", mName, mObserverStatus));
		}
	}

	public class ObserverPattern : MonoBehaviour
	{
		void Start ()
		{
			ConcreteSubject subject = new ConcreteSubject ();

			subject.Add (new ConcreteObserver (subject, "X"));
			subject.Add (new ConcreteObserver (subject, "Y"));
			subject.Add (new ConcreteObserver (subject, "Z"));

			subject.SubjectStatus = "ABC";

			Debug.Log (this.GetType().Name + " ----------");

			subject.Notify ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
