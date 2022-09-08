using System.ComponentModel.DataAnnotations;

namespace etickets.Models
{
    public class Actor_Movie
    {
       
        
        public int MovieId { get; set; }
        //References
        public Movie Movie { get; set; }
        
        
        public int ActorId { get; set; }
        //References
        public Actor Actor { get; set; }



    }
}
