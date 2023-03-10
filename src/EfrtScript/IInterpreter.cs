/* Copyright (C) Premysl Fara and Contributors */

namespace EFrtScript;


public interface IInterpreter
{
    IInterpreterState State { get; }
    IOutputWriter Output { get; }
    IInputSource? CurrentInputSource { get; }


    #region words

    bool IsCompiling { get; }
    INonPrimitiveWord? WordBeingDefined { get; }

    bool IsWordRegistered(string wordName);
    IWord GetRegisteredWord(string wordName);
    void RegisterWord(IWord word);

    void BeginNewWordCompilation(string wordName);
    void EndNewWordCompilation();

    #endregion


    #region execution

    /// <summary>
    /// The state, in which is this interpreter.
    /// </summary>
    InterpreterStateCode InterpreterState { get; }
    
    /// <summary>
    /// True, if this program execution is currently terminated.
    /// </summary>
    bool IsExecutionTerminated { get; }
    
    
    /// <summary>
    /// Interprets a string.
    /// </summary>
    /// <param name="src">A string representing a Forth program.</param>
    void Interpret(string src);
    
    /// <summary>
    /// Executes a word. 
    /// Call this for a each word execution.
    /// </summary>
    /// <param name="word">A word to be executed.</param>
    /// <returns>A next word index.</returns>
    int ExecuteWord(IWord word);
    
    /// <summary>
    /// Cleans up the internal interpreters state.
    /// </summary>
    void Reset();

    /// <summary>
    /// Clears the stack and the object stack and calls the Quit() method.
    /// </summary>
    void Abort();

    /// <summary>
    /// The return stack is cleared and control is returned to the interpreter. The stack and the object stack are not disturbed.
    /// </summary>
    void Quit();

    /// <summary>
    /// Throws an system exception based on the exception code.
    /// </summary>
    /// <param name="exceptionCode">An exception code.</param>
    /// <param name="message">An optional exception message.</param>
    void Throw(int exceptionCode, string? message = null);
    
    /// <summary>
    /// Asks the interpreter to terminate the current script execution.
    /// </summary>
    void TerminateExecution();

    #endregion
}
