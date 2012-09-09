using Thor.Models;

namespace Thor.Asgard
{
    public interface ICuzSettingsIsSealedWrapper
    {
        Foundry Get();
        void Save(Foundry foundry);
        void Delete(Foundry foundry);
    }
}