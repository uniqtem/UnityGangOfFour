using UnityEngine;
using System.Collections;

/// <summary>
/// Decorator.
/// </summary>
namespace GangOfFour.Structural.Decorator
{
	public abstract class Component
	{
		public abstract void Operation ();
	}

	public class ConcreteComponent : Component
	{
		public override void Operation ()
		{
			Debug.Log ("ConcreteComponent Operation");
		}
	}

	public abstract class Decorator : Component
	{
		protected Component mComponent;

		public void SetComponent (Component component)
		{
			mComponent = component;
		}

		public override void Operation ()
		{
			if (mComponent != null) {
				mComponent.Operation ();
			}
		}
	}

	public class ConcreteComponentA : Decorator
	{
		public override void Operation ()
		{
			base.Operation ();
			Debug.Log ("ConcreteComponentA Operation");
		}
	}

	public class ConcreteComponentB : Decorator
	{
		public override void Operation ()
		{
			base.Operation ();
			AddedBehavior ();
			Debug.Log ("ConcreteComponentB Operation");
		}

		private void AddedBehavior ()
		{
			Debug.Log ("ConcreteComponentB AddedBehavior");
		}
	}

	public class DecoratorPattern : MonoBehaviour
	{
		void Start ()
		{
			ConcreteComponent c = new ConcreteComponent ();
			ConcreteComponentA c1 = new ConcreteComponentA ();
			ConcreteComponentB c2 = new ConcreteComponentB ();

			c1.SetComponent (c);
			c2.SetComponent (c1);

			Debug.Log (this.GetType().Name + " ----------");

			c2.Operation ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}


