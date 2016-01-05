using UnityEngine;
using System.Collections;

/// <summary>
/// Decorator.
/// </summary>
namespace GangOfFour.Structural.Decorator
{
	public class SubSystemOne
	{
		public void MethodOne ()
		{
			Debug.Log ("SubSystemOne MethodOne");
		}
	}

	public class SubSystemTwo
	{
		public void MethodTow ()
		{
			Debug.Log ("SubSystemTwo MethodTow");
		}
	}

	public class SubSystemThree
	{
		public void MethodThree ()
		{
			Debug.Log ("SubSystemThree MethodThree");
		}
	}

	public class SubSystemFour
	{
		public void MethodFour ()
		{
			Debug.Log ("SubSystemFour MethodFour");
		}
	}

	public class Facade
	{
		private SubSystemOne mOne;
		private SubSystemTwo mTwo;
		private SubSystemThree mThree;
		private SubSystemFour mFour;

		public Facade ()
		{
			mOne = new SubSystemOne ();
			mTwo = new SubSystemTwo ();
			mThree = new SubSystemThree ();
			mFour = new SubSystemFour ();
		}

		public void MethodA ()
		{
			Debug.Log ("Facade MethodA");
			mOne.MethodOne ();
			mTwo.MethodTow ();
			mFour.MethodFour ();
		}

		public void MethodB ()
		{
			Debug.Log ("Facade MethodB");
			mTwo.MethodTow ();
			mThree.MethodThree ();
		}
	}

	public class FacadePattern : MonoBehaviour
	{
		void Start ()
		{
			Facade facade = new Facade ();

			Debug.Log (this.GetType().Name + " ----------");

			facade.MethodA ();
			facade.MethodB ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
