using System;
using System.Collections;

namespace AbstractMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            // x * (y + 2)
            Expression e = new Operation(
                new VariableReferece("x"), 
                '*', 
                new Operation(
                    new VariableReferece("y"), 
                    '+', 
                    new Constant(2)
                    )
                );

            Hashtable vars = new Hashtable();

            vars["x"] = 3;
            vars["y"] = 5;

            Console.WriteLine(e.Evaluate(vars));

            vars["x"] = 1.5;
            vars["y"] = 9;

            Console.WriteLine(e.Evaluate(vars));
        }
    }

    public abstract class Expression
    {
        public abstract double Evaluate(Hashtable vars);
    }

    public class Constant: Expression
    {
        double value;

        public Constant(double value)
        {
            this.value = value;
        }

        public override double Evaluate(Hashtable vars)
        {
            return value;
        }
    }

    public class VariableReferece: Expression
    {
        string name;

        public VariableReferece(string name)
        {
            this.name = name;
        }

        public override double Evaluate(Hashtable vars)
        {
            object value = vars[name];
            
            if (value == null)
            {
                throw new Exception("Unknown variable: " + name);
            }

            return Convert.ToDouble(value);
        }
    }

    public class Operation: Expression
    {
        readonly Expression left;
        char op;
        readonly Expression right;

        public Operation(Expression left, char op, Expression right)
        {
            this.left = left;
            this.op = op;
            this.right = right;
        }

        public override double Evaluate(Hashtable vars)
        {
            double x = left.Evaluate(vars);
            double y = right.Evaluate(vars);
            switch (op)
            {
                case '+':
                    return x + y;
                case '-':
                    return x - y;
                case '*':
                    return x * y;
                case '/':
                    return x / y;
            }

            throw new Exception("Unknown operator");
        }
    }
}
