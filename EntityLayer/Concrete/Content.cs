using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        // Content Yazar

        // Content Başlık

        [ForeignKey("Heading")]
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }


        [ForeignKey("Writer")]
        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
