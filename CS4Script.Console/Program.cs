using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4Script.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CS4Script.Script script = new Script();
            script.LoadCSCode(@"
  using System;
  class Program
    {
        static void Test(string name)
        {
            Console.WriteLine(name);
        }
    }
");
            script.Invoke("Program:Test", "henry");



           script.LoadCSCode(@"
  using System;
  using CS4Script.Console;
  public class Command:Program.ICommand
    {
        public  void Execute(string cmd)
        {
            System.Console.WriteLine(cmd);
        }
    }
");
            script.Invoke("Command:Execute", "henry");

            ICommand cmd = (ICommand)script.CreateInstance("Command");
            cmd.Execute("henry");
            System.Console.Read();
        }

        public interface ICommand
        {
            void Execute(string cmd);
        }
    }


}
