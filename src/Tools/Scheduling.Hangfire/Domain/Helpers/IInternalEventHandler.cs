namespace Scheduling.Hangfire.Domain.Domain.Helpers
{
	public interface IInternalEventHandler
	{
		void Handle(object @event);
	}
}
