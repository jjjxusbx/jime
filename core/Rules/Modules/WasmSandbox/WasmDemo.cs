// WasmDemo.cs
using WasmSandbox.Runtime;

namespace WasmSandbox.Examples
{
    public class WasmDemo
    {
        public static void RunDemo()
        {
            var validator = new WasmValidator("core/Rules/Modules/WasmSandbox/Rules/xss_rule.wasm");
            var testCases = new[] {
                "<script>alert(1)</script>",
                "safe text"
            };

            foreach (var input in testCases)
            {
                bool isVuln = validator.Validate(input);
                Console.WriteLine($"输入: {input}\n检测结果: {isVuln}\n");
            }
        }
    }
}