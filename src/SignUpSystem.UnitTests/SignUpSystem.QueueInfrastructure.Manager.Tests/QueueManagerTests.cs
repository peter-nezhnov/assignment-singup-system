using System.Threading.Tasks;
using NSubstitute;
using SignUpSystem.Domain.Models.Commands;
using SignUpSystem.QueueInfrastructure.AbstractSender;
using SignUpSystem.QueueInfrastructure.Manager;
using Xunit;

namespace SignUpSystem.UnitTests.SignUpSystem.QueueInfrastructure.Manager.Tests
{
    public class QueueManagerTests
    {
        IQueueSender _queueSenderMock;
        ICommandsSerializer _commandsSerializerMock;
        QueueManagerSettings _settings;
        QueuesManager _queuesManager;


        public QueueManagerTests()
        {
            _queueSenderMock = Substitute.For<IQueueSender>();
            _commandsSerializerMock = Substitute.For<ICommandsSerializer>();
            _settings = new QueueManagerSettings("1");

           _queuesManager = new QueuesManager(_queueSenderMock, _commandsSerializerMock, _settings);
        }

        public class SendSignUpMessageAsyncMethod : QueueManagerTests
        {
            [Fact]
            public async Task some_test()
            {
                var command = new SignUpCommand();
                await _queuesManager.SendSignUpCommandAsync(command);

                _commandsSerializerMock.Received().SerializerMessage(Arg.Is(command));
                //check the calls to whatever
            }

            //Long list of tests
        }
    }
}
