namespace Scheduling.Hangfire.Domain.Helpers
{
	public interface IInternalEventHandler
	{
		void Handle(object @event);
	}
}
