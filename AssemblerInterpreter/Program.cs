﻿namespace AssemblerInterpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpr = new Interpreter();
            interpr.Interpret(
@"LD r2 #1
LD r1 #0
LD r5 #100
L1:
ADD r1 r2
MOV r1 r0
SUB r0 r5
SYSCALL r1
BRGZ L1 r0");
        }
    }
}
