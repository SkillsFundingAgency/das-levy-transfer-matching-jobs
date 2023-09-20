﻿namespace SFA.DAS.LevyTransferMatching.Functions.Api
{
    public class ApplicationCreatedEmailRequest
    {
        public int ApplicationId { get; set; }
        public int PledgeId { get; set; }
        public long ReceiverId { get; set; }
        public string BaseUrl { get; set; }
        public string ReceiverEncodedAccountId { get; set; }
    }
}
