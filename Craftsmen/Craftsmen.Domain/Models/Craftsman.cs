using Common.Domain.Contracts;
using Common.Domain.Models;

namespace Craftsmen.Domain.Models;

public class Craftsman : Entity<int>, IAggregateRoot
{
    private readonly ICollection<Project> projects;
    private readonly ICollection<Resource> resources;
    private readonly ICollection<Feedback> feedbacks;
    private readonly ICollection<Tag> tags;

    internal Craftsman(
        string name,
        string description,
        string userId,
        string city,
        Category category)
    {
        this.Validate(name, description, userId, city);
        
        this.Name = name;
        this.Description = description;
        this.UserId = userId;
        this.City = city;
        
        this.projects = new HashSet<Project>();
        this.resources = new HashSet<Resource>();
        this.feedbacks = new HashSet<Feedback>();
        this.tags = new HashSet<Tag>();
    }

    public string Name { get; private set; }
    
    public string City { get; private set; }

    public string Description { get; private set; }
    
    public string UserId { get; private set; }
    
    public Category Category { get; private set; }
    
    public IReadOnlyCollection<Project> Projects
        => this.projects.ToList().AsReadOnly();
    
    public IReadOnlyCollection<Resource> Resources
        => this.resources.ToList().AsReadOnly();
    
    public IReadOnlyCollection<Feedback> Feedbacks
        => this.feedbacks.ToList().AsReadOnly();
    
    public void AddProject(Project project)
        => this.projects.Add(project);
    
    public void AddResource(Resource resource)
        => this.resources.Add(resource);
    
    private void Validate(
        string name,
        string description,
        string userId,
        string city)
    {
        throw new NotImplementedException();
    }
}