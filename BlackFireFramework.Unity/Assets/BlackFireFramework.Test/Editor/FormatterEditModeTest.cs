using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.IO;
using BlackFireFramework;

public class FormatterEditModeTest
{

	[Test]
	public void Serialize()
    {
        FileStream fs = new FileStream(@"D:\\Test.dat", FileMode.Create);
        var formatter = new BlackFireFormatter();
        formatter.Serialize(fs, new SerializeObject() { x = 111 });
        fs.Close();
    }

    [Test]
    public void Deserialize()
    {
        FileStream fs = new FileStream(@"D:\\Test.dat", FileMode.Open);
        var formatter = new BlackFireFormatter();
        formatter.Deserialize(fs);
        fs.Close();
    }


    [System.Serializable]
    private sealed class SerializeObject
    {
        public int x;
    }

}
