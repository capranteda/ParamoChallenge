using System;
using Sat.Recruitment.Domain.Models;
using Sat.Recruitment.Model.DTOs;
using Sat.Recruitment.Service.Interfaces;

namespace Sat.Recruitment.Service.Utils
{
    public  class Functions :IFunctions
    {
        public  decimal CalculateMoney(int userType, decimal money)
        {
            decimal percentage = 0;

            switch (userType)
            {
                case (int)UserTypes.Normal:
                    if (money <= 10) break;
                    if (money > 100)
                    {
                        percentage = (decimal)0.12;
                        money = calculateNewMoney(money, percentage);
                        break;
                    }

                    if (money > 10)
                    {
                        percentage = (decimal)0.8;
                        money = calculateNewMoney(money, percentage);
                    }

                    break;
                case (int)UserTypes.SuperUser:
                    if (money > 100)
                    {
                        percentage = (decimal)0.20;
                        money = calculateNewMoney(money, percentage);
                    }

                    ;
                    break;
                case (int)UserTypes.Premium:
                {
                    if (money > 100)
                    {
                        percentage = (decimal)2;
                        money = calculateNewMoney(money, percentage);
                    }
                    
                }
                    
                    break;
            }

            return money;
        }

        private static decimal calculateNewMoney(decimal money, decimal percentage)
        {
            return (money * percentage) + money;
        }
    }
}