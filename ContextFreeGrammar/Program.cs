using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ContextFreeGrammar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TuringMachine m = new TuringMachine(new int[] { 0, 1, 1, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 });

            foreach (int i in m._tape)
            {
                Console.Write(i);
            }

            Console.Write("\n\n");

            m.Execute();

            foreach (int i in m._tape)
            {
                Console.Write(i);
            }
        }

        public class TuringMachine
        {
            int _pointer = 0;
            public int[] _tape;

            public TuringMachine(int[] tape)
            {
                _tape = tape;
            }

            public void Execute()
            {
                _pointer = 0;
                executeRec(0);
            }

            private void executeRec(int state)
            {
                if (_pointer == _tape.Length)
                    return;

                if (state == 0)
                {

                    if (_tape[_pointer] == 0)
                    {
                        _tape[_pointer] = 0;
                        _pointer++;
                        executeRec(state);
                    }
                    else
                    {
                        _tape[_pointer] = 0;
                        _pointer++;
                        executeRec(++state);
                    }
                }
                else if (state == 1)
                {
                    if (_tape[_pointer] == 0)
                    {
                        _tape[_pointer] = 0;
                        _pointer++;
                        executeRec(++state);
                    }
                    else
                    {
                        _tape[_pointer] = 0;
                        _pointer++;
                        executeRec(state);
                    }
                }
                else if (state == 2)
                {
                    if (_tape[_pointer] == 0)
                    {
                        _tape[_pointer] = 0;
                        _pointer++;
                        executeRec(state);
                    }
                    else
                    {
                        _tape[_pointer] = 1;
                        _pointer++;
                        executeRec(++state);
                    }
                }
                else if (state == 3)
                {
                    if (_tape[_pointer] == 0)
                    {
                        _tape[_pointer] = 1;
                        _pointer++;
                        executeRec(state);
                    }
                    else
                    {
                        _tape[_pointer] = 1;
                        _pointer++;
                        executeRec(state);
                    }
                }
            }
        }

        static bool belongsToGrammar(string chain)
        {
            string T = "1234567890";
            
            Stack<char> charStack = new Stack<char>();


            foreach (char c in chain)
            {
                charStack.Push(c);
            }

            while(charStack.Count != 1)
            {
                var c1 = charStack.Pop();
                var c2 = charStack.Pop();

                if (!(T.Contains(c1) && T.Contains(c2)) && (c1 != 'S' || !T.Contains(c2)))
                {
                    return false;
                }

                charStack.Push('S');
            }

            var lastChar = charStack.Pop();

            if (T.Contains(lastChar) || lastChar == 'S')
                return true;
            else
            {
                return false;
            }
        }
    }
}
