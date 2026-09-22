using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendningMachine.App
{
    internal static class CoinSlot
    {
        static readonly SortedSet<float> _acceptedMoney = new SortedSet<float> { 0.1f, 0.2f, 0.5f, 1f, 20f, 50f };

        // exact "== 0" comparisom gave me a headache and a bunch of errors, so used epsillon to get around it.
        const float Epsilon = 0.0001f;

        public static float ValidateMoney(float target, List<float> sumNumbers)
        {
            float maxTemp = _acceptedMoney.Max;
            float minTemp = _acceptedMoney.Min;

            float targetValue = target;

            if (targetValue < 0) return -1;

            for (int i = _acceptedMoney.Count; i <= _acceptedMoney.Count; i--)
            {
                if (i < 0) break;

                if (targetValue < Epsilon)
                    break;

                if (targetValue >= maxTemp)
                {
                    targetValue -= maxTemp;
                    sumNumbers.Add(maxTemp);

                    continue;
                }
                else if (Math.Abs(targetValue - minTemp) < Epsilon)
                {
                    targetValue = 0;
                    sumNumbers.Add(minTemp);

                    continue;
                }
                else if (targetValue < _acceptedMoney.Max && targetValue > _acceptedMoney.Min)
                {
                    int j = 0;
                    for (j = _acceptedMoney.Count - 1; j >= 0; j--)
                    {
                        if (targetValue < maxTemp)
                        {
                            if (Math.Abs(targetValue - _acceptedMoney.ElementAt(j)) < Epsilon)
                            {
                                targetValue = 0;
                                sumNumbers.Add(_acceptedMoney.ElementAt(j));

                                break;
                            }

                            while (targetValue - _acceptedMoney.ElementAt(j) > Epsilon)
                            {
                                targetValue -= _acceptedMoney.ElementAt(j);
                                sumNumbers.Add(_acceptedMoney.ElementAt(j));
                            }
                        }

                        if (targetValue < Epsilon)
                            break;
                    }

                    if (targetValue >= Epsilon)
                    {
                        return -1;
                    }
                }
            }
            return targetValue < Epsilon ? 0 : targetValue;
        }

        public static bool IsAcceptedDenomination(float value)
        {
            foreach (float coin in _acceptedMoney)
            {
                if (Math.Abs(coin - value) < Epsilon)
                    return true;
            }

            return false;
        }
    }
}
