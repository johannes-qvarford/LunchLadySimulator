using System;

/**
  * Class for doing things that should only be done once.
  * Used to avoid the "if(done) {...} done = true" pattern.
  * Provides the ability to reset the done status, but this generally should be avoided.
**/
public class DoOncer
{
	private bool hasDone = false;
	
	public void doOnce(Action action)
	{
		if(hasDone == false)
		{
			action();
		}
		hasDone = true;
	}
	
	void reset()
	{
		hasDone = false;
	}
}

