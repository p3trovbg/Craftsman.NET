namespace Craftsmen.Domain.Models;

using Common.Domain;
using Common.Domain.Contracts;
using Common.Domain.Models;
using Exceptions;

public class Craftsman : Entity<int>, IAggregateRoot
{
    private readonly ICollection<Project> projects;
    private readonly ICollection<Resource> resources;
    private readonly ICollection<Feedback> feedbacks;

    internal Craftsman(
        string name,
        string description,
        string userId,
        string location,
        Category category)
    {
        this.Validate(name, description, userId, location);
        
        this.Name = name;
        this.Description = description;
        this.UserId = userId;
        this.Location = location;
        this.Category = category;
        
        this.projects = new HashSet<Project>();
        this.resources = new HashSet<Resource>();
        this.feedbacks = new HashSet<Feedback>();
    }

    public string Name { get; private set; }
    
    public string Description { get; private set; }

    public string UserId { get; private set; }
    
    public string Location { get; private set; }
    
    public Category Category { get; private set; }
    
    public IReadOnlyCollection<Project> Projects => this.projects.ToList().AsReadOnly();
    
    public IReadOnlyCollection<Resource> Resources => this.resources.ToList().AsReadOnly();
    
    public IReadOnlyCollection<Feedback> Feedbacks => this.feedbacks.ToList().AsReadOnly();

    public void AddProject(Project project) => this.projects.Add(project);

    public void AddResource(Resource resource) => this.resources.Add(resource);

    public void AddFeedback(Feedback feedback) => this.feedbacks.Add(feedback);

    public Craftsman UpdateName(string newName)
    {
        this.ValidateName(newName);

        this.Name = newName;
        return this;
    }

    public Craftsman UpdateDescription(string newDescription)
    {
        this.ValidateDescription(newDescription);

        this.Description = newDescription;
        return this;
    }

    public Craftsman UpdateLocation(string newLocation)
    {
        this.ValidateLocation(newLocation);

        this.Location = newLocation;
        return this;
    }

    public Craftsman UpdateCategory(Category newCategory)
    {
        if (newCategory != this.Category)
        {
            this.Category = Category;
        }

        return this;
    }

    private void Validate(
        string name,
        string description,
        string userId,
        string location)
    {
        this.ValidateName(name);
        this.ValidateDescription(description);
        this.ValidateUserId(userId);
        this.ValidateLocation(location);
    }

    private void ValidateName(string name)
        => Guard.ForStringLength<InvalidCraftsmanException>(name, 3, 150, nameof(this.Name));

    private void ValidateDescription(string description)
        => Guard.ForStringLength<InvalidCraftsmanException>(description, 3, 1000, nameof(this.Description));

    private void ValidateUserId(string userId)
        => Guard.AgainstEmptyString<InvalidCraftsmanException>(userId, nameof(this.UserId));

    private void ValidateLocation(string location)
        => Guard.ForStringLength<InvalidCraftsmanException>(location, 4, 100, nameof(this.Location));
}