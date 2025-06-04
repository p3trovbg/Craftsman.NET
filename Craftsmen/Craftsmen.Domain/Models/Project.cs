namespace Craftsmen.Domain.Models;

using Common.Domain;
using Common.Domain.Models;
using Exceptions;

using static Common.Domain.Constants.Project;

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

    public void AddResource(Resource resource) => this.resources.Add(resource);
    
    public void AddFeedback(Feedback feedback) => this.feedbacks.Add(feedback);

    public void AddTag(Tag tag) => this.tags.Add(tag);

    private void Validate(string name, string description, int durationInWeeks)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
        this.ValidateDurationInWeeks(durationInWeeks);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidProjectException>(name, NameMinLength, NameMaxLength, nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidProjectException>(description, DescriptionMinLength, DescriptionMaxLength, nameof(this.Description));

    private void ValidateDurationInWeeks(int durationInWeeks)
        => Guard.AgainstOutOfRange<InvalidProjectException>(durationInWeeks, DurationMinWeeks, DurationMaxWeeks, nameof(this.DurationInWeeks));
}