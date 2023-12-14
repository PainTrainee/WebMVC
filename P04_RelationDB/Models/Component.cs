using System.ComponentModel.DataAnnotations;

namespace P04_RelationDB.Models
{
    public class Component
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
