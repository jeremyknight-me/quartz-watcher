using System.Threading.Channels;

namespace QuartzWatcher.Outboxes.InMemory;

internal sealed class InMemoryMessageQueue
{
    private readonly Channel<QuartzMessage> _channel
        = Channel.CreateUnbounded<QuartzMessage>();

    public ChannelReader<QuartzMessage> Reader => _channel.Reader;
    public ChannelWriter<QuartzMessage> Writer => _channel.Writer;
}
