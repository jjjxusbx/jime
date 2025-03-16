// 使用 Wasmtime 运行时
public class WasmValidator
{
    private readonly Engine _engine = new();
    private readonly Module _module;

    public WasmValidator(string wasmPath)
    {
        _module = Module.FromFile(_engine, wasmPath);
    }

    public bool Validate(string targetData)
    {
        using var store = new Store(_engine);
        var instance = new Instance(store, _module, new IExternal[0]);

        // 注入输入数据
        var memory = instance.GetMemory("memory");
        var inputAddr = instance.GetFunction("alloc").Invoke(Encoding.UTF8.GetByteCount(targetData));
        memory.WriteString(store, (int)inputAddr, targetData);

        // 执行验证
        var result = instance.GetFunction("validate").Invoke(inputAddr);
        return result?.ToString() == "1";
    }
}