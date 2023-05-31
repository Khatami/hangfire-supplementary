namespace Scheduling.Domain.Domain.Helpers
{
	public interface IInternalEventHandler
	{
		void Handle(object @event);
	}
}
