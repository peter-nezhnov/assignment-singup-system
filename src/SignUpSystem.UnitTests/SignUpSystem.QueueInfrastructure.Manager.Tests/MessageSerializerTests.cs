using SignUpSystem.QueueInfrastructure.Manager;
using System;
using Xunit;

namespace SignUpSystem.UnitTests
{
    public class MessageSerializerTests
    {
        MessageSerializer _messageSerializer = new MessageSerializer();

        public class SerializerMessageMethod : MessageSerializerTests
        {
            [Fact]
            public void can_serialize_valid_message()
            {
                var validaMessage = new SignUpMessage();

                var result = _messageSerializer.SerializerMessage(validaMessage);

                Assert.Equal("{}", result);
            }

            [Fact]
            public void can_not_serialize_null_value()
            {
                Assert.Throws<ArgumentException>(() => _messageSerializer.SerializerMessage(null));
            }
        }
    }
}
