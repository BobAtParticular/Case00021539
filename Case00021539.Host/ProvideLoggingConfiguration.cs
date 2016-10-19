using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Case00021539.Host
{
    public class ProvideLoggingConfiguration :
        IProvideConfiguration<Logging>
    {
        public Logging GetConfiguration()
        {
            return new Logging
            {
                Threshold = "TRACE"
            };
        }
    }
}