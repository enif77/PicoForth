/* Copyright (C) Premysl Fara and Contributors */

namespace EFrtScript;

/// <summary>
/// Defines a state, in which an interpreter can be.
/// </summary>
public enum InterpreterStateCode
{
    /// <summary>
    /// The interpreter is in the interpretation mode.
    /// </summary>
    Interpreting,

    /// <summary>
    /// The interpreter is compiling a new word, variable or constant.
    /// </summary>
    Compiling,

    /// <summary>
    /// State after the [ word. Interpreter can return to Compiling state by the ] word.
    /// </summary>
    SuspendingCompilation,

    /// <summary>
    /// The interpreter just executed the QUIT word. The current interpretation is terminated and can be resumed.
    /// </summary>
    Breaking,

    /// <summary>
    /// The interpreter just executed the BYE word. The current interpretation is terminated and should not be restarted.
    /// </summary>
    Terminating
}
