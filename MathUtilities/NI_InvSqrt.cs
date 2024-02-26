namespace MathUtilities
{
    /// <summary>
    /// Provides methods for calculating the inverse square root using the Newton algorithm.
    /// </summary>
    public class NI_InvSqrt
    {
        /// <summary>
        /// Calculates the inverse square root of a number using the Newton algorithm.
        /// </summary>
        /// <param name="x">The number whose inverse square root is to be calculated.</param>
        /// <returns>The inverse square root of the specified number.</returns>
        public static float InverseSqrt(float x)
        {
            // If the number is zero, return positive infinity to avoid division by zero
            if (x == 0)
                return float.PositiveInfinity;

            // Initialize reciprocal
            float reciprocal = 0.0f;

            // Check if the number is a multiple of a power of 10
            if (x >= 10 && x < int.MaxValue && x % 10 == 0)
            {
                // Calculate the power of 10
                int power = (int)Math.Log10(x);

                // Calculate reciprocal by adding 0.01 for each power of 10
                for (int i = 0; i < power; i++)
                {
                    reciprocal += 0.01f;
                }

                // Multiply the number by the reciprocal
                x = x * reciprocal;
            }
            else
            {
                // If the number is not a multiple of a power of 10, calculate reciprocal as usual
                reciprocal = 1.0f / x;
            }

            // Initialize variables for Newton's method
            float xhalf = 0.5f * x;
            float guess = reciprocal * 0.5f;

            // Perform Newton's method iterations for higher accuracy
            for (int i = 0; i < 10; i++)
            {
                guess = guess * (1.5f - (xhalf * guess * guess));
            }

            // Return the result
            return guess;
        }
    }
}