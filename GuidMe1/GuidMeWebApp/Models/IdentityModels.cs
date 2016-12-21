using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Data.Entity;

namespace GuidMeWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(30), MinLength(2)]
        public String FirstName { get; set; }
        [Required]
        [MaxLength(30), MinLength(2)]
        public String LastName { get; set; }
        [Required]
        public Boolean Sex { get; set; }
        [Required]
        [MaxLength(20), MinLength(3)]
        public String Nationality { get; set; }
        [Required]
        public Boolean TypeRole { get; set; }
        [Required]
        public Boolean IsOnline { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "5")]
        public decimal RankGuid { get; set; }

       
        public virtual Avatar avatar { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Want_To_Visit> Want_To_Visit { get; set; }

        public System.Data.Entity.DbSet<Place> Places { get; set; }

        public System.Data.Entity.DbSet<Want_To_Guid> Want_To_Guid { get; set; }

        public System.Data.Entity.DbSet<TranslationPlace> TranslationPlaces { get; set; }

        public System.Data.Entity.DbSet<Translation_Nationality> Translation_Nationality { get; set; }

        public System.Data.Entity.DbSet<Speak> Speaks { get; set; }

        public System.Data.Entity.DbSet<Avatar> Avatars { get; set; }

        public System.Data.Entity.DbSet<MatchVisitorGuide> MatchVisitorGuides { get; set; }

        public System.Data.Entity.DbSet<LanguagePerson> LanguagePersons { get; set; }

        public System.Data.Entity.DbSet<Evaluation> Evaluations { get; set; }
    }

    public class Avatar
    {
        [Key]
        public String IdPicture { get; set; }
        [Required]
        [MaxLength(50), MinLength(4)]
        public String Name { get; set; }
        [Required]
        [MaxLength(200), MinLength(10)]
        public String UrlPicture { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class Evaluation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEvaluation { get; set; }

        public ApplicationUser PseudoGuide { get; set; }

        public ApplicationUser PseudoVisitor { get; set; }

        [Range(typeof(decimal), "0", "5")]
        public decimal Eval { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class LanguagePerson
    {
        [Key]
        public String CodeLanguage { get; set; }
        [Required]
        [MaxLength(10), MinLength(1)]
        public String Name { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class MatchVisitorGuide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMatchVisitorGuide { get; set; }

        public ApplicationUser PseudoGuide { get; set; }

        public ApplicationUser PseudoVisitor { get; set; }

        [Required]
        public DateTime DateRelation { get; set; }

        [Required]
        [MaxLength(30), MinLength(1)]
        public String NamePlace { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class Place
    {
        [Key]
        public String IdPlace { get; set; }

        [Required]
        [MaxLength(100), MinLength(1)]
        public String Address { get; set; }

        [Required]
        public DbGeography Position { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }

    public class Speak
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSpeak { get; set; }

        public virtual LanguagePerson CodeLanguage { get; set; }

        public ApplicationUser person { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class Translation_Nationality
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTranslationNationality { get; set; }

        [Required]
        [MaxLength(15), MinLength(1)]
        public String TranslationNationatity { get; set; }

        public virtual LanguagePerson CodeLanguage { get; set; }

        public ApplicationUser person { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class TranslationPlace
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTranslationPlace { get; set; }

        [Required]
        [MaxLength(30), MinLength(1)]
        public String TranslationNamePlace { get; set; }

        public virtual LanguagePerson CodeLanguage { get; set; }

        public virtual Place Place { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }

    public class Want_To_Guid
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWantToGuid { get; set; }

        public ApplicationUser Person { get; set; }

        public virtual Place Place { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }

    public class Want_To_GuidCreateModel
    {
        public string Id { get; set; }
        public String Address { get; set; }
        public DbGeography Position { get; set; }

    }

    public class Want_To_Visit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdWantToVisit { get; set; }

        public ApplicationUser person { get; set; }

        public virtual Place place { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}