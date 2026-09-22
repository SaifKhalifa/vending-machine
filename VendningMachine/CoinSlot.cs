using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendningMachine.App
{
    internal static class CoinSlot
    {
        static readonly SortedSet<float> _acceptedMoney = new SortedSet<float> { 0.1, 0.2, 0.5, 1, 20, 50};

        public static float ValidateMoney(float target, List<float> sumNumbers)
        {
            float maxTemp = _acceptedMoney.Max;
            float minTemp = _acceptedMoney.Min;

            _acceptedMoney.Append(target);

            float targetValue = target;

            if (targetValue < 0) return -1;

            for (int i = _acceptedMoney.Count; i <= _acceptedMoney.Count; i--)
            {
                if (i < 0) break;

                if (targetValue == 0)
                    break;

                if (targetValue >= maxTemp)
                {
                    targetValue -= maxTemp;
                    sumNumbers.Add(maxTemp);

                    continue;
                }
                else if (targetValue == minTemp)
                {
                    targetValue -= minTemp;
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
                            if (j > 0)
                            {
                                if ((targetValue - _acceptedMoney.ElementAt(j)) == 0)
                                {
                                    targetValue -= _acceptedMoney.ElementAt(j);
                                    sumNumbers.Add(_acceptedMoney.ElementAt(j));

                                    break;
                                }

                                while ((targetValue - _acceptedMoney.ElementAt(j)) > 0)
                                {
                                    targetValue -= _acceptedMoney.ElementAt(j);
                                    sumNumbers.Add(_acceptedMoney.ElementAt(j));
                                }
                            }
                        }

                        if (targetValue == 0)
                            break;
                    }

                    if (targetValue > 0)
                    {
                        return -1;
                    }
                }
            }
            return targetValue;
        }
    }
}
