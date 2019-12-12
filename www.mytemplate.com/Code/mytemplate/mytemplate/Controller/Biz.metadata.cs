
namespace mytemplate.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using mytemplate.Controller.Library;
    using DynamicDataExtensions.Attributes;
    using DynamicDataExtensions.Attributes.Enums;

    #region Comment
    // The MetadataTypeAttribute identifies CommentMetadata as the class
    // that carries additional metadata for the Comment class.
    [MetadataTypeAttribute(typeof(Comment.CommentMetadata))]
    public partial class Comment
    {

        // This class allows you to attach custom attributes to properties
        // of the Comment class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class CommentMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private CommentMetadata()
            {
            }

            [Display(Name = "Comment Text", Order = 1)]
            [UIHint("MultilineText")]
            public string CommentText { get; set; }

            [HideColumnIn(PageTemplate.List | PageTemplate.Insert | PageTemplate.Edit | PageTemplate.Details | PageTemplate.Unknown)]
            public string CreatedBy { get; set; }

            [HideColumnIn(PageTemplate.List | PageTemplate.Insert | PageTemplate.Edit | PageTemplate.Details | PageTemplate.Unknown)]
            public Nullable<DateTime> CreatedOn { get; set; }

            public int EntityId { get; set; }

            [EnumDataType(typeof(EntityType))]
            public int EntityType { get; set; }

            [ScaffoldColumn(false)]
            public int Id { get; set; }

            [HideColumnIn(PageTemplate.List | PageTemplate.Insert | PageTemplate.Edit | PageTemplate.Details | PageTemplate.Unknown)]
            public string LastModeratedBy { get; set; }

            [HideColumnIn(PageTemplate.List | PageTemplate.Insert | PageTemplate.Edit | PageTemplate.Details | PageTemplate.Unknown)]
            public Nullable<DateTime> LastModeratedOn { get; set; }

            [UIHint("Milestone")]
            [DefaultValue("Submitted")]
            public string Milestone { get; set; }

            [Display(Name = " Date ")]
            public DateTime SubmitDate { get; set; }

            [Display(Name = "Email")]
            public string SubmitterEmail { get; set; }

            [Display(Name = "Name")]
            public string SubmitterName { get; set; }

            [Display(Name = "Website")]
            public string SubmitterWebsite { get; set; }
        }
    }
    #endregion

    #region Feedback
    // The MetadataTypeAttribute identifies FeedbackMetadata as the class
    // that carries additional metadata for the Feedback class.
    [MetadataTypeAttribute(typeof(Feedback.FeedbackMetadata))]
	[DisplayName("Feed back")]
    public partial class Feedback
    {

        // This class allows you to attach custom attributes to properties
        // of the Feedback class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class FeedbackMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private FeedbackMetadata()
            {
            }

            public string City { get; set; }

            public string ContactNo { get; set; }

            public string CorrectIt { get; set; }

            public string DissatisfiedWith { get; set; }

            public string EmailAddress { get; set; }

            public int Id { get; set; }

            public string Name { get; set; }

            public string OverallExperience { get; set; }

            public string Rating { get; set; }

            public string Suggestions { get; set; }

            public string WebsiteComparison { get; set; }
        }
    }
    #endregion
}