using UnityEngine;
using System.Collections;

/// <summary>
/// Abstract Factory.
/// </summary>
namespace GangOfFour.Creational.Abstract
{
	public abstract class AbstractProductA
	{
	}

	public abstract class AbstractProductB
	{
		public abstract void Interact (AbstractProductA a);
	}

	public abstract class AbstractFactory
	{
		public abstract AbstractProductA CreateProductA ();
		public abstract AbstractProductB CreateProductB ();
	}

	public class ProductA1 : AbstractProductA
	{
	}

	public class ProductB1 : AbstractProductB
	{
		public override void Interact (AbstractProductA a)
		{
			Debug.Log (this.GetType().Name + "interacts with " + a.GetType().Name);
		}
	}

	public class ProductA2 : AbstractProductA
	{
	}

	public class ProductB2 : AbstractProductB
	{
		public override void Interact (AbstractProductA a)
		{
			Debug.Log (this.GetType().Name + " interacts with " + a.GetType().Name);
		}
	}

	public class ConcreteFactory1 : AbstractFactory
	{
		public override AbstractProductA CreateProductA ()
		{
			return new ProductA1 ();
		}

		public override AbstractProductB CreateProductB ()
		{
			return new ProductB1 ();
		}
	}

	public class ConcreteFactory2 : AbstractFactory
	{
		public override AbstractProductA CreateProductA ()
		{
			return new ProductA2 ();
		}

		public override AbstractProductB CreateProductB ()
		{
			return new ProductB2 ();
		}
	}

	public class Client
	{
		private AbstractProductA mAbstractProductA;
		private AbstractProductB mAbstractProductB;

		public Client (AbstractFactory factory)
		{
			mAbstractProductA = factory.CreateProductA ();
			mAbstractProductB = factory.CreateProductB ();
		}

		public void Run ()
		{
			mAbstractProductB.Interact (mAbstractProductA);
		}
	}

	public class AbstractFactoryPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log (this.GetType().Name + " ----------");

			Client client1 = new Client (new ConcreteFactory1 ());
			client1.Run ();

			Client client2 = new Client (new ConcreteFactory2 ());
			client2.Run ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
