using UnityEngine;
using System.Collections;

/// <summary>
/// Adapter.
/// </summary>
namespace GangOfFour.Structural.Adapter
{
	public class Target
	{
		public virtual void Request ()
		{
			Debug.Log ("Call Target Request");
		}
	}

	public class Adaptee
	{
		public void SpecificRequest ()
		{
			Debug.Log ("Call Adaptee SpecificRequest");
		}
	}

	public class Adapter : Target
	{
		Adaptee mAdaptee = new Adaptee ();

		public override void Request ()
		{
//			base.Request ();
			mAdaptee.SpecificRequest ();
		}
	}
	
	public class AdapterPattern : MonoBehaviour
	{
		void Start ()
		{
			Target target = new Adapter ();

			Debug.Log (this.GetType().Name + " ----------");

			target.Request ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
