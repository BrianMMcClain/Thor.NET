using Thor.Net.Models;

namespace Thor.Net.Properties
{
    public interface ICuzSettingsIsSealedWrapper
    {
        Foundry Get();
        void Save(Foundry foundry);
        void Delete(Foundry foundry);
    }
}