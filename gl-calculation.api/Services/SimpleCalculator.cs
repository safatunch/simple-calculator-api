namespace gl_calculation.api.Services
{
    public class SimpleCalculator : ISimpleCalculator
    {
        public int Add(int start, int amount)
        {
            var res= (long)start + amount;
            if (res > int.MaxValue)
                throw new ArgumentOutOfRangeException("Exceeding max value!");
            return (int)res;
        }
        public int Subtract(int start, int amount)
        {
            var res = (long)start - amount;
            if (res < int.MinValue)
                throw new ArgumentOutOfRangeException("Exceeding max value!");
            return (int)res;
        }
    }
}
