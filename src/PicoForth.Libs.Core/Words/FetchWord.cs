/* Copyright (C) Premysl Fara and Contributors */

namespace PicoForth.Libs.Core.Words;

using PicoForth.Extensions;


internal class FetchWord : IWord
{
    public string Name => "@";
    public bool IsImmediate => false;


    public int Execute(IInterpreter interpreter)
    {
        interpreter.StackExpect(1);

        interpreter.StackPush(interpreter.HeapFetch(interpreter.StackPop().Integer));

        return 1;
    }
}
