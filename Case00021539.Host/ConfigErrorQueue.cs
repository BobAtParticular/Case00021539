using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;

namespace Case00021539.Host
{
    class ConfigErrorQueue :
        IProvideConfiguration<MessageForwardingInCaseOfFaultConfig>
    {
        public MessageForwardingInCaseOfFaultConfig GetConfiguration()
        {
            return new MessageForwardingInCaseOfFaultConfig
            {
                ErrorQueue = "error"
            };
        }
    }
}