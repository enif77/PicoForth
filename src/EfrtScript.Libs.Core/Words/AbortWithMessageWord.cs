/* Copyright (C) Premysl Fara and Contributors */

namespace EFrtScript.Libs.Core.Words;

using System;


internal class AbortWithMessageWord : IWord
{
    public string Name => "ABORT\"";
    public bool IsImmediate => true;


    public int Execute(IInterpreter interpreter)
    {
        if (interpreter.IsCompiling == false)
        {
            throw new Exception("ABORT\" outside a new word definition.");
        }

        interpreter.WordBeingDefined!
            .AddWord(new AbortWithMessageControlWord(interpreter.CurrentInputSource!.ReadStringFromSource()));
        
        return 1;
    }
}
