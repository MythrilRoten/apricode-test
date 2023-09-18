using System.ComponentModel.DataAnnotations.Schema;
using Apricode.App.Infrastructure.Common;

namespace Apricode.App.Infrastructure.Entities
{
    [Table("game_developers")]
    public partial class GameDeveloper: BaseEntity
    {
        public GameDeveloper()
        {
            Games = new HashSet<Game>();
        }
        
        [Column("name", TypeName = "character varying")]
        public string Name { get; set; } = null!;

        [InverseProperty("DeveloperNavigation")]
        public virtual ICollection<Game> Games { get; set; }
    }
}
