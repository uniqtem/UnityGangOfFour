using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Iterator.
/// </summary>
namespace GangOfFour.Behavioral.Iterator
{
	public abstract class Aggregate
	{
		public abstract Iterator CreateIterator ();
	}

	public class ConcreteAggregate : Aggregate
	{
		private List<object> mList = new List<object> ();

		public override Iterator CreateIterator ()
		{
			return null;
		}

		public int Count {
			get {
				return mList.Count;
			}
		}

		public object this[int index] {
			get {
				return mList [index];
			} set {
				mList.Insert (index, value);
			}
		}
	}

	public abstract class Iterator
	{
		public abstract object First ();
		public abstract object Next ();
		public abstract bool IsDone ();
		public abstract object CurrentItem ();
	}

	public class ConcreteIterator : Iterator
	{
		private ConcreteAggregate mAggregate;
		private int mCurrent;

		public ConcreteIterator (ConcreteAggregate aggregate)
		{
			mAggregate = aggregate;
			mCurrent = 0;
		}

		public override object First ()
		{
			return mAggregate [0];
		}

		public override object Next ()
		{
			if (mCurrent >= mAggregate.Count - 1) {
				return null;
			}

			return mAggregate [++mCurrent];
		}

		public override bool IsDone ()
		{
			return mCurrent >= mAggregate.Count;
		}

		public override object CurrentItem ()
		{
			return mAggregate [mCurrent];
		}
	}

	public class IteratorPattern : MonoBehaviour
	{
		void Start ()
		{
			ConcreteAggregate a = new ConcreteAggregate ();
			a [0] = "Item A";
			a [1] = "Item B";
			a [2] = "Item C";
			a [3] = "Item D";

			ConcreteIterator i = new ConcreteIterator (a);

			Debug.Log (this.GetType().Name + " ----------");

			object item = i.First ();
			while (item != null) {
				Debug.Log (item);
				item = i.Next ();
			}

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}


