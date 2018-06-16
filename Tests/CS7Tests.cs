using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    // Doc: https://blogs.msdn.microsoft.com/mazhou/2017/05/26/c-7-series-part-1-value-tuples/
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Tuples()
        {
            (string a, int b, object c) a = 
                (a : "a", b : 1, c : new { d = 2.71828 });
            var b = a.a;
            var c = foo(a);
            a = c;
            var t = new Tuple<int>(1);
            Assert.IsTrue(a.GetType().IsValueType);
            Assert.IsTrue(t.GetType().IsClass);
            (string a, int b, object notC) d = c;
            (string x, string y) = AbMethod();
        }

        private (string x, string y) AbMethod()
        {
            return default;
        }

        private (string a, int b, object c) foo(
            (string a, int b, object c) a)
        {
            return a;
        }
        
        // C# 7.1
        [TestMethod]
        public void DefaultCalls()
        {
            foo(default);
            var i = 1;
            switch(i){
                case 2: break;
                // doesn't work
                //case (default): break;
                default : break;
            }
        }

        [TestMethod]
        public void Discards()
        {
            var result = int.TryParse("42", out int i);
            result = int.TryParse("42", out _);
        }

        [TestMethod]
        public void Discards2()
        {
            bool _ = false, v = false;
            if(bool.TryParse("true", out var _))            
            {
                v = _;
                Assert.IsFalse(v); // !
            }
        }
    }
}
