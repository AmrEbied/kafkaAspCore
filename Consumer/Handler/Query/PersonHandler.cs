using MediatR;

namespace Consumer.Handler.Query
{

    public class PersonCommand : IRequest<bool>
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonCommandHandler : IRequestHandler<PersonCommand, bool>
    {
        public Task<bool> Handle(PersonCommand request, CancellationToken cancellationToken)
        {
            // Handle the command logic here
            // For example, you can return true if the command is successful
            return Task.FromResult(true);
        }
    }

}
