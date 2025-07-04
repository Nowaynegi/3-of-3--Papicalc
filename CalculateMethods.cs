namespace Papicalc
{
    internal static class CalculateMethods
    {
        public static double Calculate(double operand1, int operatorInt, double operand2)
        {
            switch (operatorInt)
            {
                case 0:
                    return operand1 + operand2;
                case 1:
                    return operand1 - operand2;
                case 2:
                    return operand1 * operand2;
                case 3:
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException("hey silly >~< don't divide by zeroo~ i dont know that one..");
                    }
                    return operand1 / operand2;
                default:
                    throw new Exception("unsupported operator! please enter + , - , * , or /");
            }
        }
        public static string HandleCalculation(int op1, int operatorInt, int op2)
        {
            try
            {
                return CalculateMethods.Calculate(op1, operatorInt, op2).ToString();
            }
            catch (DivideByZeroException)
            {
                return "?";
            }
            catch (Exception)
            {
                return "??";
            }
        }
    }
}