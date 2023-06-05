namespace Tibby;

public static class TibbyHelper
{
    //there are one Trillion mojos per chia. 
    const double MOJOS_PER_CHIA = 1000000000000;

    /// <summary>
    /// Returns Mojos for an amount provided as the parameter.
    /// </summary>
    /// <param name="amount">Amount of XCH</param>
    /// <returns></returns>
    public static double ConvertToMojos(double amount)
    {
        return amount * MOJOS_PER_CHIA;
    }

    /// <summary>
    /// Returns amount of tokens that is being requested taking into account tibetswaps 0.7% Liquidity fee.
    /// </summary>
    /// <param name="input_amount">Input amount in mojos</param>
    /// <param name="input_reserve">Input reserve from quote api call</param>
    /// <param name="output_reserve">Output reset from quote api call</param>
    /// <returns></returns>
    public static double GetInputPrice(double input_amount, double input_reserve, double output_reserve)
    {
        if (input_amount == 0) return 0;

        var input_amount_with_fee = input_amount * 993;
        var numerator = input_amount_with_fee * output_reserve;
        var denominator = (input_reserve * 1000) + input_amount_with_fee;
        return Math.Floor((numerator / denominator));
    }

    /// <summary>
    /// Returns the lowest xch amount required for the swap taking into account tibetswaps 0.7% Liquidity fee.
    ///
    /// </summary>
    /// <param name="output_amount">amount_out from quote api call</param>
    /// <param name="input_reserve">input_reserve from quote api call</param>
    /// <param name="output_reserve">output_reserve from quote api cal</param>
    /// <returns></returns>
    public static double getOutputPrice(double output_amount, double input_reserve, double output_reserve)
    {
        if (output_amount > output_reserve)
        {
            return 0;
        }

        if (output_amount == 0) return 0;

        var numerator = input_reserve * output_amount * 1000;

        //liquidity fee for TibetSwaps swap is 0.7%
        var denominator = (output_reserve - output_amount) * 993;
        return Math.Floor(numerator / denominator) + 1;
    }

    /// <summary>
    /// Calculate Fee to go to Donation Addresses by returning lowestxchAmount * devFee. TibetSwap adds a dev fee of 0.3%
    /// </summary>
    /// <param name="lowestxchAmount">Amount offering in mojos</param>
    /// <param name="devFee">Percentage of xch amount</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double CalculateFee(double lowestxchAmount, double devFee=1.003)
    {
        if (devFee < 1 || devFee > 1.5)
            throw new ArgumentException("Fee cannot be lower than 1.0 or greater than 1.5");
        
        return Math.Floor(lowestxchAmount * devFee); //input + dev fee
    }
}