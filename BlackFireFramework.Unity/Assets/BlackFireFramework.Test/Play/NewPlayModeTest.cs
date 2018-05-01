using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NewPlayModeTest {

	[Test]
	public void NewPlayModeTestSimplePasses() {
        // Use the Assert class to test conditions.
        Debug.Log("NewPlayModeTestSimplePasses");
    }

	// A UnityTest behaves like a coroutine in PlayMode
	// and allows you to yield null to skip a frame in EditMode
	[UnityTest]
	public IEnumerator NewPlayModeTestWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        while (true)
        {
            yield return null;
            Debug.Log("NewPlayModeTestWithEnumeratorPasses");
        }
		
        
    }
}
