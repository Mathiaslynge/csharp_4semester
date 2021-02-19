using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    public static class Palindrom
    {
        public static bool IsPalindrom(this string s)
        {
            bool palidrom = false;
            if (s.Length <= 1)
            {
                return true;
            }
            else
            {
                if (s[0] != s[s.Length - 1])
                {
                    return false;
                }
                else
                {
                    return palidrom = IsPalindrom(s.Substring(1, s.Length - 2));
                }

            }
        }
    }
}