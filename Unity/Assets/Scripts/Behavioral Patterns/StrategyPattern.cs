using UnityEngine;
using System.Collections;

/// <summary>
/// Strategy.
/// </summary>
namespace GangOfFour.Behavioral.Strategy
{
	public abstract class Strategy
	{
		public abstract void AlgorithmInterface ();
	}

	public class ConcreteStrategyA : Strategy
	{
		public override void AlgorithmInterface ()
		{
			Debug.Log ("ConcreteStrategyA AlgorithmInterface");
		}
	}

	public class ConcreteStrategyB : Strategy
	{
		public override void AlgorithmInterface ()
		{
			Debug.Log ("ConcreteStrategyB AlgorithmInterface");
		}
	}

	public class ConcreteStrategyC : Strategy
	{
		public override void AlgorithmInterface ()
		{
			Debug.Log ("ConcreteStrategyC AlgorithmInterface");
		}
	}

	public class Context
	{
		private Strategy mStrategy;

		public Context (Strategy strategy)
		{
			mStrategy = strategy;
		}

		public void ContextInterface ()
		{
			mStrategy.AlgorithmInterface ();
		}
	}

	public class StrategyPattern : MonoBehaviour
	{
		void Start ()
		{
			Debug.Log (this.GetType().Name + " ----------");

			Context context = new Context (new ConcreteStrategyA ());
			context.ContextInterface ();

			context = new Context (new ConcreteStrategyB ());
			context.ContextInterface ();

			context = new Context (new ConcreteStrategyC ());
			context.ContextInterface ();

			Debug.Log (this.GetType().Name + " ----------");

		}
	}
}
