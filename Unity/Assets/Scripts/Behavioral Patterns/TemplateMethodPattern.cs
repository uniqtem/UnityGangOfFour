using UnityEngine;
using System.Collections;

/// <summary>
/// TemplateMethod.
/// </summary>
namespace GangOfFour.Behavioral.TemplateMethod
{
	public abstract class AbstractClass
	{
		public abstract void PrimitiveOperation1 ();
		public abstract void PrimitiveOperation2 ();

		public void TemplateMethod ()
		{
			PrimitiveOperation1 ();
			PrimitiveOperation2 ();

			Debug.Log ("AbstractClass TemplateMethod");
		}
	}

	public class ConcreteClassA : AbstractClass
	{
		public override void PrimitiveOperation1 ()
		{
			Debug.Log ("ConcreteClassA PrimitiveOperation1");
		}

		public override void PrimitiveOperation2 ()
		{
			Debug.Log ("ConcreteClassA PrimitiveOperation2");
		}
	}

	public class ConcreteClassB : AbstractClass
	{
		public override void PrimitiveOperation1 ()
		{
			Debug.Log ("ConcreteClassB PrimitiveOperation1");
		}

		public override void PrimitiveOperation2 ()
		{
			Debug.Log ("ConcreteClassB PrimitiveOperation2");
		}
	}

	public class TemplateMethodPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log (this.GetType().Name + " ----------");

			AbstractClass aA = new ConcreteClassA ();
			aA.TemplateMethod ();

			AbstractClass aB = new ConcreteClassB ();
			aB.TemplateMethod ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
