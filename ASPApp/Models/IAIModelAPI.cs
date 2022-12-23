namespace ASPApp.Models
{
    public interface IAIModelAPI
    {
        public ContainerForResultRenameIt GetContainerForResultRenameIt(
            string request,
            string crdcModelName,
            string nerModelName,
            string maskModelName,
            int resultCount);
    }
}
