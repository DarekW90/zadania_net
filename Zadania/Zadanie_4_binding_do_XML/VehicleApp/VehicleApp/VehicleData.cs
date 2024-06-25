using System.Collections.Generic;
using System.Xml.Serialization;

[XmlRoot("Vehicles")]
public class Vehicles
{
    public Vehicles()
    {
        Categories = new List<Category>();
    }

    [XmlElement("Category")]
    public List<Category> Categories { get; set; }
}

public class Category
{
    public Category()
    {
        SubCategories = new List<SubCategory>();
    }

    [XmlAttribute("name")]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [XmlElement("SubCategory")]
    public List<SubCategory> SubCategories { get; set; }
}

public class SubCategory
{
    public SubCategory()
    {
        Elements = new List<Element>();
    }

    [XmlAttribute("name")]
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ParentCompany { get; set; } = string.Empty;
    public string Founded { get; set; } = string.Empty;
    public string Countries { get; set; } = string.Empty;

    [XmlArray("Elements")]
    [XmlArrayItem("Element")]
    public List<Element> Elements { get; set; }
}

public class Element
{
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public string EngineCapacity { get; set; } = string.Empty;
    public string DriveType { get; set; } = string.Empty;
}
