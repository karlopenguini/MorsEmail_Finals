using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorsEmail.Views.AccountControls.Controls.Validation
{
    public static class ControlValidation
    {
        public static bool InAvailableAccounts(string accEmail, List<string> availableAccounts)
        {
            if (availableAccounts.Contains(accEmail))
            {
                return true;
            }
            return false;
        }
    }
}
