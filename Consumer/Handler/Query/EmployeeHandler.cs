using MediatR;

namespace Consumer.Handler.Query
{

    public class EmployeeCommand : IRequest<bool>
    {
        public int? Number { get; set; }
        public string? Phone { get; set; }
    }

    public class EmployeeCommandHandler : IRequestHandler<EmployeeCommand, bool>
    {
        public Task<bool> Handle(EmployeeCommand request, CancellationToken cancellationToken)
        {
            // Handle the command logic here
            // For example, you can return true if the command is successful
            return Task.FromResult(true);
        }
    }
}
