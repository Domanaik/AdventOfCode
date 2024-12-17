using AdventOfCode._17;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        string[] inputData = Input.GetInput().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        int regA = int.Parse(inputData[0].Split(':')[1]);
        int regB = int.Parse(inputData[1].Split(':')[1]);
        int regC = int.Parse(inputData[2].Split(':')[1]);

        int[] program = inputData[3].Split(':')[1].Split(',').Select(s => int.Parse(s)).ToArray();

        // Part 1
        string output = RunProgram(regA, regB, regC, program);
        Console.WriteLine(output);

        // Part 2
        for (regA = 1; ; regA++)
        {
            output = RunProgram(regA, regB, regC, program);
            if (output == string.Join(",", program))
            {
                Console.WriteLine(regA);
                break;
            }
        }
    }

    static string RunProgram(int regA, int regB, int regC, int[] program)
    {
        int instructionPointer = 0;
        List<int> outputValues = [];

        while (instructionPointer < program.Length)
        {
            int opcode = program[instructionPointer];
            int operand = program[instructionPointer + 1];

            switch (opcode)
            {

                /* The adv instruction (opcode 0) performs division. The numerator is the
                value in the A register. The denominator is found by raising 2 to the power 
                of the instruction's combo operand. (So, an operand of 2 would divide A by 
                4 (2^2); an operand of 5 would divide A by 2^B.) The result of the division 
                operation is truncated to an integer and then written to the A register. */
                case 0:
                    regA /= (int)Math.Pow(2, GetComboValue(operand, regA, regB, regC));
                    break;

                /* The bxl instruction (opcode 1) calculates the bitwise XOR of register B and 
                the instruction's literal operand, then stores the result in register B. */
                case 1: // bxl: B ^= literal operand
                    regB ^= operand;
                    break;

                /* The bst instruction (opcode 2) calculates the value of its combo operand 
                modulo 8 (thereby keeping only its lowest 3 bits), then writes that value 
                to the B register. */
                case 2:
                    regB = GetComboValue(operand, regA, regB, regC) % 8;
                    break;

                /* The jnz instruction (opcode 3) does nothing if the A register is 0. 
                However, if the A register is not zero, it jumps by setting the instruction 
                pointer to the value of its literal operand; if this instruction jumps, the 
                instruction pointer is not increased by 2 after this instruction. */
                case 3:
                    if (regA != 0)
                    {
                        instructionPointer = operand;
                        continue;
                    }
                    break;

                /* The bxc instruction (opcode 4) calculates the bitwise XOR of register B and 
                register C, then stores the result in register B. (For legacy reasons, this 
                instruction reads an operand but ignores it.) */
                case 4:
                    regB ^= regC;
                    break;

                /* The out instruction (opcode 5) calculates the value of its combo operand 
                modulo 8, then outputs that value. (If a program outputs multiple values, 
                they are separated by commas.) */
                case 5:
                    outputValues.Add(GetComboValue(operand, regA, regB, regC) % 8);
                    break;

                /* The bdv instruction (opcode 6) works exactly like the adv instruction 
                except that the result is stored in the B register. (The numerator is still 
                read from the A register.) */
                case 6:
                    regB = regA / (int)Math.Pow(2, GetComboValue(operand, regA, regB, regC));
                    break;

                /* The cdv instruction (opcode 7) works exactly like the adv instruction 
                except that the result is stored in the C register. (The numerator is still 
                read from the A register.) */
                case 7:
                    regC = regA / (int)Math.Pow(2, GetComboValue(operand, regA, regB, regC));
                    break;
            }

            instructionPointer += 2;
        }

        return string.Join(",", outputValues);
    }

    static int GetComboValue(int operand, int regA, int regB, int regC)
    {
        return operand switch
        {
            0 => 0,
            1 => 1,
            2 => 2,
            3 => 3,
            4 => regA,
            5 => regB,
            6 => regC,
            7 => throw new InvalidOperationException("Combo operand 7 is reserved and will not appear in valid programs."),
            _ => throw new InvalidOperationException("Invalid combo operand")
        };
    }
}