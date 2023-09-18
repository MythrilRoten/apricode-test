using System.ComponentModel.DataAnnotations.Schema;
using Apricode.App.Infrastructure.Common;

namespace Apricode.App.Infrastructure.Entities
{
    [Table("games")]
    public partial class Game: BaseEntity
    {
        public Game()
        {
            Genres = new HashSet<Genre>();
        }
        
        [Column("developer")]
        public Guid Developer { get; set; }
        [Column("name", TypeName = "character varying")]
        public string Name { get; set; } = null!;
        
        [ForeignKey("Developer")]
        [InverseProperty("Games")]
        public virtual GameDeveloper DeveloperNavigation { get; set; } = null!;
        [InverseProperty("GameNavigation")]
        public virtual ICollection<Genre> Genres { get; set; }
    }
}
