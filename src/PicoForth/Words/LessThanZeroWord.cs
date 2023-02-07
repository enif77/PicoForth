/* Copyright (C) Premysl Fara and Contributors */

using PicoForth.Values;

namespace PicoForth.Words;


internal class LessThanZeroWord : IWord
{
    public string Name => "0<";
    

    public void Execute(IEvaluator evaluator)
    {
        evaluator.StackPush(new IntValue(evaluator.StackPop().Integer < 0 ? -1 : 0));
    }
}
