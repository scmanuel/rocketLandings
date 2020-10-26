using Zartis.RocketLanding.Enums;
using Zartis.RocketLanding.Contracts;

namespace Zartis.RocketLanding.Mappers
{
    public class ApproachCheckResultMapper
        : IApproachCheckResultMapper
    {
        private const string ClashMessage = "clash";
        private const string OutMessage = "out of platform";
        private const string OkMessage = "ok for landing";

        public string Map(ApproachCheckResult approachCheckResult)
        {
            string approachCheckResultMapped;

            switch (approachCheckResult)
            {
                case ApproachCheckResult.Clash:
                    approachCheckResultMapped = ClashMessage;
                    break;
                case ApproachCheckResult.Out:
                    approachCheckResultMapped = OutMessage;
                    break;
                default:
                    approachCheckResultMapped = OkMessage;
                    break;
            }

            return approachCheckResultMapped;
        }
    }
}
