using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Composite.
/// </summary>
namespace GangOfFour.Structural.Composite
{
	public abstract class Component
	{
		protected string mName;

		public Component (string name)
		{
			mName = name;
		}

		public abstract void Add (Component component);
		public abstract void Remove (Component component);
		public abstract void Display ();
	}

	public class Composite : Component
	{
		private List<Component> mList = new List<Component> ();

		public Composite (string name) : base (name)
		{
		}

		public override void Add (Component component)
		{
			mList.Add (component);
		}

		public override void Remove (Component component)
		{
			mList.Remove (component);
		}

		public override void Display ()
		{
			Debug.Log ("Composite Name : " + mName);

			if (mList.Count > 0) {
				for (int i = 0; i < mList.Count; i++) {
					Debug.Log (mName + " List Index : " + i);
					mList [i].Display ();
				}
			}
		}
	}

	public class Leaf : Component
	{
		public Leaf (string name) : base (name)
		{
		}

		public override void Add (Component component)
		{
			Debug.LogWarning ("Cannot add to a leaf");
		}

		public override void Remove (Component component)
		{
			Debug.LogWarning ("Cannot remove to a leaf");
		}

		public override void Display ()
		{
			Debug.Log ("Leaf Name : " + mName);
		}
	}

	public class CompositePattern : MonoBehaviour
	{
		void Start ()
		{
			Composite root = new Composite ("Root");
			root.Add (new Leaf ("Leaf A"));
			root.Add (new Leaf ("Leaf B"));

			Composite comp = new Composite ("Composite X");
			comp.Add (new Leaf ("Leaf XA"));
			comp.Add (new Leaf ("Leaf XB"));

			root.Add (comp);
			root.Add (new Leaf ("Leaf C"));

			Leaf leaf = new Leaf ("Leaf D");
			root.Add (leaf);
			root.Remove (leaf);

			Debug.Log (this.GetType().Name + " ----------");

			root.Display ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
