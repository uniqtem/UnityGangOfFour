using UnityEngine;
using System.Collections;

/// <summary>
/// Factory Method.
/// </summary>
namespace GangOfFour.Creational.Factory
{
	public abstract class Product
	{
	}

	public class ConcreteProductA : Product
	{
	}

	public class ConcreteProductB : Product
	{
	}

	public abstract class Creator
	{
		public abstract Product FactoryMethod ();
	}

	public class ConcreteCreatorA : Creator
	{
		public override Product FactoryMethod ()
		{
			return new ConcreteProductA ();
		}
	}

	public class ConcreteCreatorB : Creator
	{
		public override Product FactoryMethod ()
		{
			return new ConcreteProductB ();
		}
	}

	public class FactoryMethodPattern : MonoBehaviour
	{
		void Start ()
		{
			Creator[] creators = new Creator[2];
			creators [0] = new ConcreteCreatorA ();
			creators [1] = new ConcreteCreatorB ();

			Debug.Log (this.GetType().Name + " ----------");

			for (int i = 0; i < creators.Length; i++) {
				Product product = creators [i].FactoryMethod ();
				Debug.Log ("Created " + i + " " + product.GetType().Name);
			}

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
