namespace EvaCompiler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var program = """hi""";
            var vm = new CodeGenerator();
            vm.exec(program);
        }
    }
}
