namespace ASPApp.Models
{
    public class MaskedTextResultRenameIt
    {
        public CrdcDistribution CrdcDistribution { get; private set; }

        public MaskFilledText MaskFilledText { get; private set; }

        public List<NerKsToken> NerKsTokens { get; private set; }

        public MaskedTextResultRenameIt(
            CrdcDistribution crdcDistribution,
            MaskFilledText maskFilledText,
            List<NerKsToken> nerKsTokens)
        {
            CrdcDistribution = crdcDistribution;
            MaskFilledText = maskFilledText;
            NerKsTokens = nerKsTokens;
        }
    }
}
