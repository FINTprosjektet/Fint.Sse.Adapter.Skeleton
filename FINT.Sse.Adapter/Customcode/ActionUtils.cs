﻿using System;
using Fint.Pwfa.Model;

namespace Fint.SSE.Customcode
{
    public class ActionUtils
    {
        public static bool IsValidAction(string eventAction)
        {
            if(Enum.TryParse(eventAction, true, out PwfaActions action))
            {
                if (Enum.IsDefined(typeof(PwfaActions), action))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
