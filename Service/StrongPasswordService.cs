using Entities;
using System.Text.Json;
using Zxcvbn;

namespace Services
{
    public class StrongPasswordService: IStrongPasswordService
    {
        public Result GetStrongPassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password);
        }

    }
}
