# AssemblerInterpreter
Assembler interpreter with a little set of commands.

Instructions:
1) **LD r{number} #{number}**  Load number (byte 0-255) to register (0-14)
2) **MOV r{number} r{number}**  Copy number from first register to second
3) **ADD r{number} r{number}**  Add first register to second and save to first
4) **SUB r{number} r{number}**  Sub second register from first and save to first
5) **BR {TEXT}**  Jump to label {TEXT}
6) **BRGZ {TEXT} r{number}**  Jump to label {TEXT} if number > 0
7) **CLEAR**  Clear all registers
8) **SYSCALL r{number}**  Print to console register content

```
Program example:
LD r2 #1
LD r1 #0
LD r5 #100
L1:
ADD r1 r2
MOV r1 r0
SUB r0 r5
SYSCALL r1
BRGZ L1 r0
```
This program writing to console numbers from 1 to 100.
