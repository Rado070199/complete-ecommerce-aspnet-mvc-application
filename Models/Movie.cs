using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace eTickets.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Movie name")]
        public string Name { get; set; }
        [Display(Name = "description")]
        public string Description { get; set; }
        [Display(Name = "Movie price")]
        public double Price { get; set; }
        [Display(Name = "Movie image")]
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }  
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }

        //Cinema
        public int CinemaId { get; set; }
        [ForeignKey("CinemaId")]
        public Cinema Cinema { get; set; }

        //Producer
        public int ProducerId { get; set; }
        [ForeignKey("ProducerId")]
        public Producer Producer{ get; set; }
    }
}
