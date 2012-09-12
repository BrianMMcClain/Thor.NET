using Thor.Asgard.Mjolner;

namespace Thor.Asgard.Bridges
{
    public class Applications 
    {
       private readonly ICuzSettingsIsSealedWrapper _wrapper;
        private readonly ILightning _lightning;

        public Applications(ICuzSettingsIsSealedWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        public Applications(ICuzSettingsIsSealedWrapper wrapper, ILightning lightning)
        {
            _wrapper = wrapper;
            _lightning = lightning;
        }
    }
}