using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton.
/// </summary>
namespace GangOfFour.Creational.Singleton
{
	public class Singleton
	{
		private static Singleton mInstance;

		public static Singleton Instance
		{
			get {
				if (mInstance == null) {
					mInstance = new Singleton ();
				}

				return mInstance;
			}
		}
	}
	
	public class SingletonPattern : MonoBehaviour
	{
		void Start ()
		{
			Singleton singleton1 = Singleton.Instance;
			Singleton singleton2 = Singleton.Instance;

			Debug.Log (this.GetType().Name + " ----------");

			if (singleton1 == singleton2) {
				Debug.Log (Singleton.Instance.GetType().Name + " objects are the same instance");
			}

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
