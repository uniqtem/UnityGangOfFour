using UnityEngine;
using System.Collections;

/// <summary>
/// Command.
/// </summary>
namespace GangOfFour.Behavioral.Command
{
	public abstract class Command
	{
		protected Receiver mReceiver;

		public Command (Receiver receiver)
		{
			mReceiver = receiver;
		}

		public abstract void Execute ();
	}

	public class ConcreteCommand : Command
	{
		public ConcreteCommand (Receiver receiver) : base (receiver)
		{
		}

		public override void Execute ()
		{
			mReceiver.Action ();
		}
	}

	public class Receiver
	{
		public void Action ()
		{
			Debug.Log ("Receiver Action");
		}
	}

	public class Invoker
	{
		private Command mCommand;

		public void SetCommand (Command command)
		{
			mCommand = command;
		}

		public void ExecuteCommand ()
		{
			mCommand.Execute ();
		}
	}

	public class CommandPattern : MonoBehaviour
	{
		void Start ()
		{
			Receiver receiver = new Receiver ();
			Command command = new ConcreteCommand (receiver);
			Invoker invoker = new Invoker ();

			invoker.SetCommand (command);

			Debug.Log (this.GetType().Name + " ----------");

			invoker.ExecuteCommand ();

			Debug.Log (this.GetType().Name + " ----------");
		}
	}
}
