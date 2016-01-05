using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Flyweight.
/// </summary>
namespace GangOfFour.Structural.Flayweight
{
	public abstract class Flyweight
	{
		public abstract void Operation ();
	}

	public class ConcreteFlyweight : Flyweight
	{
		public override void Operation ()
		{
			Debug.Log ("ConcreteFlayweight Operation");
		}
	}

	public class UnsharedConcreteFlyweight : Flyweight
	{
		public override void Operation ()
		{
			Debug.Log ("UnsharedConcreteFlyweight Operation");
		}
	}

	public class FlyweightFactory
	{
		private Dictionary<string, ConcreteFlyweight> mFlyweights;

		public FlyweightFactory ()
		{
			mFlyweights = new Dictionary<string, ConcreteFlyweight> ();
			mFlyweights.Add ("X", new ConcreteFlyweight ());
			mFlyweights.Add ("Y", new ConcreteFlyweight ());
			mFlyweights.Add ("Z", new ConcreteFlyweight ());
		}

		public Flyweight GetFlyweight (string key)
		{
			if (!mFlyweights.ContainsKey (key)) {
				return null;
			}

			return (Flyweight)mFlyweights [key];
		}
	}

	public class FlyweightPattern : MonoBehaviour
	{
		void Start ()
		{
			FlyweightFactory factory = new FlyweightFactory ();

			Flyweight fx = factory.GetFlyweight ("X");
			Flyweight fy = factory.GetFlyweight ("Y");
			Flyweight fz = factory.GetFlyweight ("Z");

			UnsharedConcreteFlyweight fu = new UnsharedConcreteFlyweight ();

			Debug.Log (this.GetType().Name + " ----------");

			fx.Operation ();
			fy.Operation ();
			fz.Operation ();
			fu.Operation ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
