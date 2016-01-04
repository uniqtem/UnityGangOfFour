using UnityEngine;
using System.Collections;

/// <summary>
/// Prototype.
/// </summary>
namespace GangOfFour.Creational.Prototype
{
	public abstract class Prototype
	{
		private string mId;

		public string Id {
			get {
				return mId;
			}
		}

		public Prototype (string id)
		{
			mId = id;
		}

		public abstract Prototype Clone ();
	}
	
	public class ConcretePrototype1 : Prototype
	{
		public ConcretePrototype1 (string id) : base (id)
		{
		}

		public override Prototype Clone ()
		{
			return (Prototype)this.MemberwiseClone ();
		}
	}

	public class ConcretePrototype2 : Prototype
	{
		public ConcretePrototype2 (string id) : base (id)
		{
		}

		public override Prototype Clone ()
		{
			return (Prototype)this.MemberwiseClone ();
		}
	}

	public class PrototypePattern : MonoBehaviour
	{
		void Start ()
		{
			ConcretePrototype1 prototype1 = new ConcretePrototype1 ("A");
			ConcretePrototype1 clone1 = (ConcretePrototype1)prototype1.Clone ();

			ConcretePrototype2 prototype2 = new ConcretePrototype2 ("B");
			ConcretePrototype2 clone2 = (ConcretePrototype2)prototype2.Clone ();

			Debug.Log (this.GetType().Name + " ----------");

			Debug.Log (clone1.GetType().Name + " : " + clone1.Id);
			Debug.Log (clone2.GetType().Name + " : " + clone2.Id);

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}

