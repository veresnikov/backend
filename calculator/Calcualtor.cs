namespace Calculator
{
    public class Calcualtor
    {
        private static dynamic Add(dynamic left, dynamic right)
        {
            return left + right;
        }

        private static dynamic Sub(dynamic left, dynamic right)
        {
            return left - right;
        }

        private static dynamic Mul(dynamic left, dynamic right)
        {
            return left * right;
        }

        private static dynamic Div(dynamic left, dynamic right)
        {
            if (right == 0)
            {
                throw new Exception("Division by zero");
            }

            return (decimal) left / right;
        }

        private string[] operations = new string[]
        {
            "+",
            "-",
            "*",
            "/",
        };

        struct Expression
        {
            public dynamic Left;
            public dynamic Right;
            public string Operation;
        }

        private Expression parseExpression(string expression)
        {
            string operationKey = String.Empty;
            int operationIndex = 0;
            foreach (var op in operations)
            {
                if (expression.Contains(op))
                {
                    operationKey = op;
                    operationIndex = expression.IndexOf(op);
                    break;
                }
            }

            if (string.IsNullOrEmpty(operationKey))
            {
                throw new Exception("Operation not found");
            }

            string left = expression.Substring(0, operationIndex);
            string right = expression.Substring(operationIndex + 1);
            if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right))
            {
                throw new Exception("Operand not found");
            }

            dynamic leftOperand;
            if (left.Contains(','))
            {
                decimal l;
                if (!decimal.TryParse(left, out l))
                {
                    throw new Exception("Operand parsing error");
                }

                leftOperand = l;
            }
            else
            {
                int l;
                if (!int.TryParse(left, out l))
                {
                    throw new Exception("Operand parsing error");
                }

                leftOperand = l;
            }

            dynamic rightOperand;
            if (right.Contains(','))
            {
                decimal r;
                if (!decimal.TryParse(left, out r))
                {
                    throw new Exception("Operand parsing error");
                }

                rightOperand = r;
            }
            else
            {
                int r;
                if (!int.TryParse(right, out r))
                {
                    throw new Exception("Operand parsing error");
                }

                rightOperand = r;
            }

            return new Expression() {Left = leftOperand, Right = rightOperand, Operation = operationKey};
        }

        public dynamic Calculate(string expression)
        {
            Expression result = parseExpression(expression);
            switch (result.Operation)
            {
                case "+": return Add(result.Left, result.Right);
                case "-": return Sub(result.Left, result.Right);
                case "*": return Mul(result.Left, result.Right);
                case "/": return Div(result.Left, result.Right);
            }

            throw new Exception("Invalid operation");
        }
    }
}