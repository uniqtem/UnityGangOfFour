using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Visitor.
/// </summary>
namespace GangOfFour.Behavioral.Visitor
{
	public abstract class Visitor
	{
		public abstract void VisitConcreteElementA (ConcreteElementA concreteElementA);
		public abstract void VisitConcreteElementB (ConcreteElementB concreteElementB);
	}

	public class ConcreteVisitor1 : Visitor
	{
		public override void VisitConcreteElementA (ConcreteElementA concreteElementA)
		{
			Debug.Log (string.Format ("{0} visited by {1}", concreteElementA.GetType ().Name, this.GetType ().Name));
		}

		public override void VisitConcreteElementB (ConcreteElementB concreteElementB)
		{
			Debug.Log (string.Format ("{0} visited by {1}", concreteElementB.GetType ().Name, this.GetType ().Name));
		}
	}

	public class ConcreteVisitor2 : Visitor
	{
		public override void VisitConcreteElementA (ConcreteElementA concreteElementA)
		{
			Debug.Log (string.Format ("{0} visited by {1}", concreteElementA.GetType ().Name, this.GetType ().Name));
		}

		public override void VisitConcreteElementB (ConcreteElementB concreteElementB)
		{
			Debug.Log (string.Format ("{0} visited by {1}", concreteElementB.GetType ().Name, this.GetType ().Name));
		}
	}

	public abstract class Element
	{
		public abstract void Accept (Visitor visitor);
	}

	public class ConcreteElementA : Element
	{
		public override void Accept (Visitor visitor)
		{
			visitor.VisitConcreteElementA (this);
		}

		public void OperationA ()
		{
		}
	}

	public class ConcreteElementB : Element
	{
		public override void Accept (Visitor visitor)
		{
			visitor.VisitConcreteElementB (this);
		}

		public void OperationB ()
		{
		}
	}

	public class ObjectStructure
	{
		private List<Element> mElements = new List<Element> ();

		public void Add (Element element)
		{
			mElements.Add (element);
		}

		public void Remove (Element element)
		{
			mElements.Remove (element);
		}

		public void Accept (Visitor visitor)
		{
			foreach (Element element in mElements) {
				element.Accept (visitor);
			}
		}
	}

	public class VisitorPattern : MonoBehaviour
	{
		void Start ()
		{
			ObjectStructure objectStructure = new ObjectStructure ();
			objectStructure.Add (new ConcreteElementA ());
			objectStructure.Add (new ConcreteElementB ());

			ConcreteVisitor1 concreteVisitor1 = new ConcreteVisitor1 ();
			ConcreteVisitor2 concreteVisitor2 = new ConcreteVisitor2 ();

			Debug.Log (this.GetType().Name + " ----------");

			objectStructure.Accept (concreteVisitor1);
			objectStructure.Accept (concreteVisitor2);

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
