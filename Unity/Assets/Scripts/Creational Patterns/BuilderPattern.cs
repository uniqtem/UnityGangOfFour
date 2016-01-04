using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Builder.
/// </summary>
namespace GangOfFour.Creational.Builder
{
	public abstract class Builder
	{
		public abstract void BuildPartA ();
		public abstract void BuildPartB ();
		public abstract Product GetProduct ();
	}

	public class Director
	{
		public void Construct (Builder build)
		{
			build.BuildPartA ();
			build.BuildPartB ();
		}
	}

	public class Product
	{
		private List<string> mList = new List<string> ();

		public void Add (string part)
		{
			mList.Add (part);
		}

		public void Show ()
		{
			for (int i = 0; i < mList.Count; i++) {
				Debug.Log (this.GetType().Name + " List " + i + " " + mList [i]);
			}
		}
	}

	public class ConcreteBuilder1 : Builder
	{
		private Product mProduct = new Product ();

		public override void BuildPartA ()
		{
			mProduct.Add ("PartA");
		}

		public override void BuildPartB ()
		{
			mProduct.Add ("PartB");
		}

		public override Product GetProduct ()
		{
			return mProduct;
		}
	}

	public class ConcreteBuilder2 : Builder
	{
		private Product mProduct = new Product ();

		public override void BuildPartA ()
		{
			mProduct.Add ("PartX");
		}

		public override void BuildPartB ()
		{
			mProduct.Add ("PartY");
		}

		public override Product GetProduct ()
		{
			return mProduct;
		}
	}

	public class BuilderPattern : MonoBehaviour
	{
		void Start ()
		{
			Director director = new Director ();

			Builder build1 = new ConcreteBuilder1 ();
			Builder build2 = new ConcreteBuilder2 ();

			director.Construct (build1);
			director.Construct (build2);

			Debug.Log (this.GetType().Name + " ----------");

			build1.GetProduct ().Show ();
			build2.GetProduct ().Show ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
