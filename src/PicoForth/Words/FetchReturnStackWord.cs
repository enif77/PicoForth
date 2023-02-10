/* Copyright (C) Premysl Fara and Contributors */

namespace PicoForth.Words;

using PicoForth.Values;


internal class FetchReturnStackWord : IWord
{
    public string Name => "R@";
    public bool IsImmediate => false;
    public bool IsControlWord => false;
    

    public void Execute(IEvaluator evaluator)
    {
        evaluator.StackPush(evaluator.ReturnStackPeek());
    }
}
