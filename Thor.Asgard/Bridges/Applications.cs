using Thor.Asgard.Mjolner;

namespace Thor.Asgard.Bridges
{
    public class Applications 
    {
       private readonly ICuzSettingsIsSealedWrapper _wrapper;
        
        public Applications(ICuzSettingsIsSealedWrapper wrapper)
        {
            _wrapper = wrapper;
        }
    }
}