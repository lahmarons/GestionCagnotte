using CagnotteEntity = global::Cagnotte.Domain.Entites.Cagnotte;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cagnotte.Domain.Entites
{
    public class Entreprise
    { 
        public int EntrepriseId { get; set; }
        
        //raison sociale de entreprise
        [Required(ErrorMessage ="la raison sociale est obligatoire")]
        [StringLength(200,ErrorMessage ="la raison sociale ne peux pas dépasser 200 caractére ")]
        public string RaisonSociale { get; set; }
        
        //description de l'entreprise (optionnelle)
        [Required(ErrorMessage ="la description est obligatoire")]
        [StringLength(500,ErrorMessage ="la description ne peux pas dépasser 500 caractére ")]
        public string Description { get; set; }

        //email de l'entreprise
        [Required(ErrorMessage ="l'email est obligatoire")]
        [EmailAddress(ErrorMessage ="l'email n'est pas valide")]
        [StringLength(100,ErrorMessage ="l'email ne peux pas dépasser 100 caractére ")]
        [Display(Name ="Email de l'entreprise")]
        public string Email { get; set; }
        
        public ICollection<CagnotteEntity>cagnottes { get; set; }    
    }
}
