namespace ASPApp.Models
{
    public class ContainerForResultRenameIt
    {
        public string MaskedRequest { get; private set; }

        public CrdcDistribution RequestCrdc { get; private set; }

        public List<MaskedTextResultRenameIt> MaskedTextResultsRenameIt { get; private set; }

        public ContainerForResultRenameIt(
            string maskedRequest,
            CrdcDistribution requestCrdc,
            List<MaskedTextResultRenameIt> maskedTextResults) 
        { 
            MaskedRequest = maskedRequest;
            RequestCrdc = requestCrdc;
            MaskedTextResultsRenameIt = maskedTextResults;
        }
    }
}
