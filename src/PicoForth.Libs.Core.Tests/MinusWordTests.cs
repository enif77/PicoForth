/* Copyright (C) Premysl Fara and Contributors */

namespace PicoForth.Libs.Core.Tests;

using Xunit;

using PicoForth.Extensions;


public class MinusWordTests
{
    [Theory]
    [InlineData( 0,  5, -5)]
    [InlineData( 5,  0,  5)]
    [InlineData( 0, -5,  5)]
    [InlineData(-5,  0, -5)]
    [InlineData( 1,  2, -1)]
    [InlineData( 1, -2,  3)]
    [InlineData(-1,  2, -3)]
    [InlineData(-1, -2,  1)]
    [InlineData( 0,  1, -1)]
    public void CalculationResultsMatchExpectedMathResults(int a, int b, int expected)
    {
        var interpreter = TestsHelper.CreateInterpreter();
        
        interpreter.StackPush(a);
        interpreter.StackPush(b);

        var w = interpreter.GetRegisteredWord("-");

        w.Execute(interpreter);
        
        Assert.Equal(expected, interpreter.StackPop().Integer);
    }
}

/*

https://forth-standard.org/standard/core/Minus

Testing:

T{          0  5 - ->       -5 }T
T{          5  0 - ->        5 }T
T{          0 -5 - ->        5 }T
T{         -5  0 - ->       -5 }T
T{          1  2 - ->       -1 }T
T{          1 -2 - ->        3 }T
T{         -1  2 - ->       -3 }T
T{         -1 -2 - ->        1 }T
T{          0  1 - ->       -1 }T
T{ MID-UINT+1  1 - -> MID-UINT }T

 */