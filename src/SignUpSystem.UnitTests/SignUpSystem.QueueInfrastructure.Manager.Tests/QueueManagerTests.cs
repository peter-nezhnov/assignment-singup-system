using SignUpSystem.QueueInfrastructure.Manager;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;
using SignUpSystem.QueueInfrastructure.AbstractSender;

namespace SignUpSystem.UnitTests
{
    public class QueueManagerTests
    {
        IQueueSender _queueSenderMock;
        IMessageSerializer _messageSerializerMock;
        QueueManagerSettings _settings;
        QueuesManager _queuesManager;


        public QueueManagerTests()
        {
            _queueSenderMock = Substitute.For<IQueueSender>();
            _messageSerializerMock = Substitute.For<IMessageSerializer>();
            _settings = new QueueManagerSettings("1", "2");

           _queuesManager = new QueuesManager(_queueSenderMock, _messageSerializerMock, _settings);
        }

        public class SendSignUpMessageAsyncMethod : QueueManagerTests
        {
            [Fact]
            public async Task some_test()
            {
                var message = new SignUpMessage();
                await _queuesManager.SendSignUpMessageAsync(message);

                _messageSerializerMock.Received().SerializerMessage(Arg.Is(message));
                //check the calls to whatever
            }


            //Long list of tests
        }
    }
}
