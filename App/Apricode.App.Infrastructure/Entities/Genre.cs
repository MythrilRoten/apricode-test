using System.ComponentModel.DataAnnotations.Schema;
using Apricode.App.Infrastructure.Common;

namespace Apricode.App.Infrastructure.Entities
{
    [Table("genres")]
    public partial class Genre: BaseEntity
    {
        [Column("game")]
        public Guid Game { get; set; }
        [Column("name", TypeName = "character varying")]
        public string Name { get; set; } = null!;

        [ForeignKey("Game")]
        [InverseProperty("Genres")]
        public virtual Game GameNavigation { get; set; } = null!;
    }
}
