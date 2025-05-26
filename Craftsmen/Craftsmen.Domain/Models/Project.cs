using Common.Domain.Models;

namespace Craftsmen.Domain.Models;

public class Project : Entity<int>
{
    private readonly ICollection<Resource> resources;
    private readonly ICollection<Feedback> feedbacks;
    private readonly ICollection<Tag> tags;

    internal Project(string name, string description, int durationInWeeks)
    {
        this.Validate(name, description, durationInWeeks);

        this.Name = name;
        this.Description = description;
        this.DurationInWeeks = durationInWeeks;

        this.resources = new HashSet<Resource>();
        this.feedbacks = new HashSet<Feedback>();
        this.tags = new HashSet<Tag>();
    }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public int DurationInWeeks { get; set; }

    public IReadOnlyCollection<Resource> Resources => this.resources.ToList().AsReadOnly();

    public IReadOnlyCollection<Feedback> Feedbacks => this.feedbacks.ToList().AsReadOnly();
    
    public IReadOnlyCollection<Tag> Tags => this.tags.ToList().AsReadOnly();

    private void Validate(string name, string description, int durationInWeeks)
    {
        throw new NotImplementedException();
    }

}