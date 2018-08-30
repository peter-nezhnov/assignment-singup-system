using SignUpSystem.QueueInfrastructure.Manager;
using System;
using SignUpSystem.Domain.Models.Commands;
using Xunit;

namespace SignUpSystem.UnitTests
{
    public class MessageSerializerTests
    {
        readonly CommandsSerializer _commandsSerializer = new CommandsSerializer();

        public class SerializerMessageMethod : MessageSerializerTests
        {
            [Fact]
            public void can_serialize_valid_message()
            {
                var command = new SignUpCommand();

                var result = _commandsSerializer. SerializerMessage(command);

                Assert.Equal("{}", result);
            }

            [Fact]
            public void can_not_serialize_null_value()
            {
                Assert.Throws<ArgumentException>(() => _commandsSerializer.SerializerMessage(null));
            }
        }
    }
}
