using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Interpreter.
/// </summary>
namespace GangOfFour.Behavioral.Interpreter
{
	public class Context
	{
	}

	public abstract class AbstractExpression
	{
		public abstract void Interpret (Context context);
	}

	public class TerminalExpression : AbstractExpression
	{
		public override void Interpret (Context context)
		{
			Debug.Log ("TerminalExpression Interpret");
		}
	}

	public class NonterminalExpression : AbstractExpression
	{
		public override void Interpret (Context context)
		{
			Debug.Log ("NonterminalExpression Interpret");
		}
	}

	public class InterpreterPattern : MonoBehaviour
	{
		void Start ()
		{
			Context context = new Context ();

			List<AbstractExpression> list = new List<AbstractExpression> ();
			list.Add (new TerminalExpression ());
			list.Add (new NonterminalExpression ());
			list.Add (new TerminalExpression ());

			Debug.Log (this.GetType().Name + " ----------");

			foreach (AbstractExpression exe in list) {
				exe.Interpret (context);
			}

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
