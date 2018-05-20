using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Collections.Generic;

namespace BlackFireFramework.Test
{
    [TestClass]
    public class ConvertorTest
    {
        [TestMethod]
        public void TestMethod_Convertor()
        {
            Debug.WriteLine(Utility.Convertor.Convert("int"));
            Debug.WriteLine(Utility.Convertor.Convert("float"));
            Debug.WriteLine(Utility.Convertor.Convert("double"));
            Debug.WriteLine(Utility.Convertor.Convert("decimal"));
            Debug.WriteLine(Utility.Convertor.Convert("char"));
            Debug.WriteLine(Utility.Convertor.Convert("string"));

            Debug.WriteLine(Utility.Convertor.Convert("List<int>"));
            Debug.WriteLine(Utility.Convertor.Convert("List<float>"));
            Debug.WriteLine(Utility.Convertor.Convert("List<double>"));
            Debug.WriteLine(Utility.Convertor.Convert("List<decimal>"));
            Debug.WriteLine(Utility.Convertor.Convert("List<char>"));
            Debug.WriteLine(Utility.Convertor.Convert("List<string>"));

            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,int>"));
            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,float>"));
            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,double>"));
            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,decimal>"));
            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,char>"));
            Debug.WriteLine(Utility.Convertor.Convert("Dictionary<string,string>"));


            Debug.WriteLine(Utility.Convertor.Convert("int[]"));
            Debug.WriteLine(Utility.Convertor.Convert("float[]"));
            Debug.WriteLine(Utility.Convertor.Convert("double[]"));
            Debug.WriteLine(Utility.Convertor.Convert("decimal[]"));
            Debug.WriteLine(Utility.Convertor.Convert("char[]"));
            Debug.WriteLine(Utility.Convertor.Convert("string[]"));


            Debug.WriteLine(Utility.Convertor.Convert("int[][]"));
            Debug.WriteLine(Utility.Convertor.Convert("float[][]"));
            Debug.WriteLine(Utility.Convertor.Convert("double[][]"));
            Debug.WriteLine(Utility.Convertor.Convert("decimal[][]"));
            Debug.WriteLine(Utility.Convertor.Convert("char[][]"));
            Debug.WriteLine(Utility.Convertor.Convert("string[][]"));

        }
    }
}
