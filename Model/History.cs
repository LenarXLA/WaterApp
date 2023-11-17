using System.ComponentModel.DataAnnotations.Schema;

namespace WaterApp.Model
{
    public class History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Volume { get; set; }
        public string CurrentDate { get; set; }
        
    }
}
