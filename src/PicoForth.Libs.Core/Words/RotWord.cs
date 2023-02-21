/* Copyright (C) Premysl Fara and Contributors */

namespace PicoForth.Libs.Core.Words;

using PicoForth.Extensions;


internal class RotWord : IWord
{
    public string Name => "ROT";
    public bool IsImmediate => false;


    public int Execute(IInterpreter interpreter)
    {
        interpreter.StackExpect(3);

        var n3 = interpreter.StackPop();
        var n2 = interpreter.StackPop();
        var n1 = interpreter.StackPop();

        interpreter.StackPush(n2);
        interpreter.StackPush(n3);
        interpreter.StackPush(n1);

        return 1;
    }
}
