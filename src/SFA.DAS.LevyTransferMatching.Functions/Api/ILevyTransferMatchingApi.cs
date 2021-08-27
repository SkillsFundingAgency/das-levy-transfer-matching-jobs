﻿using System.Threading.Tasks;
using RestEase;

namespace SFA.DAS.LevyTransferMatching.Functions.Api
{
    public interface ILevyTransferMatchingApi
    {
        [Post("functions/application-approved")]
        Task ApplicationApproved([Body]ApplicationApprovedRequest request);

        [Post("functions/pledge-debit-failed")]
        Task PledgeDebitFailed([Body] PledgeDebitFailedRequest request);
    }
}
