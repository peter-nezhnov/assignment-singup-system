using Newtonsoft.Json;
using SignUpSystem.Domain.Models.Commands;
using SingUpSystem.Infrastructure.Utils;

namespace SignUpSystem.QueueInfrastructure.Manager
{
    internal interface ICommandsSerializer
    {
        string SerializerMessage(IBaseSignUpSystemCommand command);
    }

    /// <summary>
    /// Can be as well in BusSender Implementation. Depends which part dictates rules for serialization.
    /// </summary>
    class CommandsSerializer : ICommandsSerializer
    {
        public string SerializerMessage(IBaseSignUpSystemCommand command)
        {
            HolyGuard.ThrowExceptionIfObjectIsNull(command);

            return JsonConvert.SerializeObject(command);
        }
    }
}
