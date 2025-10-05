using System.Threading.Channels;

namespace QuartzWatcher.Outboxes.InMemory;

internal sealed class InMemoryMessageQueue
{
    private readonly Channel<QuartzMessage> _channel
        = Channel.CreateUnbounded<QuartzMessage>();

    //private readonly Channel<QuartzMessage> _channel
    //    = Channel.CreateBounded<QuartzMessage>(new BoundedChannelOptions(10000)
    //    {
    //        FullMode = BoundedChannelFullMode.Wait
    //    });

    public ChannelReader<QuartzMessage> Reader => _channel.Reader;
    public ChannelWriter<QuartzMessage> Writer => _channel.Writer;
}
