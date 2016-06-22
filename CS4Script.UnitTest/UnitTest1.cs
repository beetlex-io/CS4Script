using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CS4Script.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Script script = new Script();
            script.LoadCSCode(@"
using System;
public class Program{
           public static void main(string name){Console.Write(" + "name" + @");}
}");
            script.Invoke("Program:main", "bbq");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Script script = new Script();
            script.LoadCSCode(@"
using System;
using CS4Script.UnitTest;
public class Program{
         public static string Register(User user){Console.Write(user.Name);user.EMail="
                + "\"henryfan@msn.com\";return user.EMail;" + @"}
}");
            string email = (string)script.Invoke("Program:Register", new User { Name = "henry" });
            Console.WriteLine(email);
        }
    }
}
